using System;
using UnityEngine;
public class EmoCognitiv : MonoBehaviour
{
	private EmoEngine engine = EmoEngine.Instance;
	public static EdkDll.EE_CognitivAction_t[] cognitivActionList = new EdkDll.EE_CognitivAction_t[]
	{
		EdkDll.EE_CognitivAction_t.COG_NEUTRAL,
		EdkDll.EE_CognitivAction_t.COG_PUSH,
		EdkDll.EE_CognitivAction_t.COG_PULL,
		EdkDll.EE_CognitivAction_t.COG_LIFT,
		EdkDll.EE_CognitivAction_t.COG_DROP,
		EdkDll.EE_CognitivAction_t.COG_LEFT,
		EdkDll.EE_CognitivAction_t.COG_RIGHT,
		EdkDll.EE_CognitivAction_t.COG_ROTATE_LEFT,
		EdkDll.EE_CognitivAction_t.COG_ROTATE_RIGHT,
		EdkDll.EE_CognitivAction_t.COG_ROTATE_CLOCKWISE,
		EdkDll.EE_CognitivAction_t.COG_ROTATE_COUNTER_CLOCKWISE,
		EdkDll.EE_CognitivAction_t.COG_ROTATE_FORWARDS,
		EdkDll.EE_CognitivAction_t.COG_ROTATE_REVERSE,
		EdkDll.EE_CognitivAction_t.COG_DISAPPEAR
	};
	public static bool[] cognitivActionsEnabled = new bool[EmoCognitiv.cognitivActionList.Length];
	public static float[] CognitivActionPower = new float[EmoCognitiv.cognitivActionList.Length];
	public static int cognitivActionLever = 0;
	public static bool IsStarted = false;
	private void Start()
	{
		if (!EmoCognitiv.IsStarted)
		{
			EmoCognitiv.cognitivActionsEnabled[0] = true;
			for (int i = 1; i < EmoCognitiv.cognitivActionList.Length; i++)
			{
				EmoCognitiv.cognitivActionsEnabled[i] = false;
			}
			this.engine.CognitivEmoStateUpdated += new EmoEngine.CognitivEmoStateUpdatedEventHandler(EmoCognitiv.engine_CognitivEmoStateUpdated);
			this.engine.CognitivTrainingStarted += new EmoEngine.CognitivTrainingStartedEventEventHandler(EmoCognitiv.engine_CognitivTrainingStarted);
			this.engine.CognitivTrainingSucceeded += new EmoEngine.CognitivTrainingSucceededEventHandler(EmoCognitiv.engine_CognitivTrainingSucceeded);
			this.engine.CognitivTrainingCompleted += new EmoEngine.CognitivTrainingCompletedEventHandler(EmoCognitiv.engine_CognitivTrainingCompleted);
			this.engine.CognitivTrainingRejected += new EmoEngine.CognitivTrainingRejectedEventHandler(EmoCognitiv.engine_CognitivTrainingRejected);
			EmoCognitiv.IsStarted = true;
		}
	}
	private void Update()
	{
	}
	private static void engine_CognitivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
	{
		EmoState emoState = e.emoState;
		EdkDll.EE_CognitivAction_t eE_CognitivAction_t = emoState.CognitivGetCurrentAction();
		float num = emoState.CognitivGetCurrentActionPower();
		for (int i = 1; i < EmoCognitiv.cognitivActionList.Length; i++)
		{
			if (eE_CognitivAction_t == EmoCognitiv.cognitivActionList[i])
			{
				EmoCognitiv.CognitivActionPower[i] = num;
			}
		}
	}
	private static void engine_CognitivTrainingStarted(object sender, EmoEngineEventArgs e)
	{
		Debug.Log("Start Cognitiv Training");
	}
	private static void engine_CognitivTrainingSucceeded(object sender, EmoEngineEventArgs e)
	{
		EmoEngine.Instance.CognitivSetTrainingControl(0u, EdkDll.EE_CognitivTrainingControl_t.COG_ACCEPT);
		Debug.Log("Cognitiv Training Succeeded");
	}
	private static void engine_CognitivTrainingCompleted(object sender, EmoEngineEventArgs e)
	{
	}
	private static void engine_CognitivTrainingRejected(object sender, EmoEngineEventArgs e)
	{
	}
	public static void StartTrainingCognitiv(EdkDll.EE_CognitivAction_t cognitivAction)
	{
		if (cognitivAction == EdkDll.EE_CognitivAction_t.COG_NEUTRAL)
		{
			EmoEngine.Instance.CognitivSetTrainingAction((uint)EmoUserManagement.currentUser, cognitivAction);
			EmoEngine.Instance.CognitivSetTrainingControl((uint)EmoUserManagement.currentUser, EdkDll.EE_CognitivTrainingControl_t.COG_START);
		}
		else
		{
			for (int i = 1; i < EmoCognitiv.cognitivActionList.Length; i++)
			{
				if (cognitivAction == EmoCognitiv.cognitivActionList[i])
				{
					Debug.Log("Action compare");
					if (EmoCognitiv.cognitivActionsEnabled[i])
					{
						Debug.Log("Action is enabled");
						EmoEngine.Instance.CognitivSetTrainingAction((uint)EmoUserManagement.currentUser, cognitivAction);
						EmoEngine.Instance.CognitivSetTrainingControl((uint)EmoUserManagement.currentUser, EdkDll.EE_CognitivTrainingControl_t.COG_START);
					}
					else
					{
						Debug.Log("Action is not enabled");
					}
				}
			}
		}
	}
	public static void EnableCognitivAction(EdkDll.EE_CognitivAction_t cognitivAction, bool iBool)
	{
		for (int i = 1; i < EmoCognitiv.cognitivActionList.Length; i++)
		{
			if (cognitivAction == EmoCognitiv.cognitivActionList[i])
			{
				EmoCognitiv.cognitivActionsEnabled[i] = iBool;
				Debug.Log("CognitivEnabledList has changed");
			}
		}
	}
	public static void EnableCognitivActionsListEx()
	{
		Debug.Log("Set CognitivList Enable");
		EmoCognitiv.cognitivActionLever = 0;
		for (int i = 1; i < EmoCognitiv.cognitivActionList.Length; i++)
		{
			if (EmoCognitiv.cognitivActionsEnabled[i])
			{
				EmoCognitiv.cognitivActionLever++;
			}
		}
		EdkDll.EE_CognitivAction_t[] array = new EdkDll.EE_CognitivAction_t[EmoCognitiv.cognitivActionLever];
		int num = 0;
		for (int j = 1; j < EmoCognitiv.cognitivActionList.Length; j++)
		{
			if (EmoCognitiv.cognitivActionsEnabled[j])
			{
				array[num] = EmoCognitiv.cognitivActionList[j];
				num++;
			}
		}
		EdkDll.SetMultiActiveActions(EmoUserManagement.currentUser, array, EmoCognitiv.cognitivActionLever);
	}
	public static void EnableCognitivActionsList()
	{
		Debug.Log("Set CognitivList Enable");
		EmoCognitiv.cognitivActionLever = 0;
		uint num = 0u;
		for (int i = 1; i < EmoCognitiv.cognitivActionList.Length; i++)
		{
			if (EmoCognitiv.cognitivActionsEnabled[i])
			{
				num |= (uint)EmoCognitiv.cognitivActionList[i];
				EmoCognitiv.cognitivActionLever++;
			}
		}
		EdkDll.EE_CognitivSetActiveActions((uint)EmoUserManagement.currentUser, num);
	}
	public static float[] GetCognitivActionPower()
	{
		return EmoCognitiv.CognitivActionPower;
	}
	public static void ResetAllCognitivPower()
	{
		for (int i = 0; i < EmoCognitiv.cognitivActionList.Length; i++)
		{
			EmoCognitiv.CognitivActionPower[i] = 0f;
		}
	}
	public static void ResetCognitivPower(EdkDll.EE_CognitivAction_t cognitivAction)
	{
		EmoCognitiv.CognitivActionPower[(int)cognitivAction] = 0f;
	}
}
