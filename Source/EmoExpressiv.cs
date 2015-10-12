using System;
using UnityEngine;
public class EmoExpressiv : MonoBehaviour
{
	private EmoEngine engine = EmoEngine.Instance;
	public static bool isBlink = false;
	public static bool isLeftWink = false;
	public static bool isRightWink = false;
	public static bool isEyesOpen = false;
	public static bool isLookingUp = false;
	public static bool isLookingDown = false;
	public static bool isLookingLeft = false;
	public static bool isLookingRight = false;
	public static float eyelidStateLeft = 0f;
	public static float eyelidStateRight = 0f;
	public static float eyeLocationX = 0f;
	public static float eyeLocationY = 0f;
	public static float eyebrowExtent = 0f;
	public static float smileExtent = 0f;
	public static float clenchExtent = 0f;
	public static EdkDll.EE_ExpressivAlgo_t upperFaceAction;
	public static EdkDll.EE_ExpressivAlgo_t lowerFaceAction;
	public static float upperFacePower = 0f;
	public static float lowerFacePower = 0f;
	public static EdkDll.EE_ExpressivAlgo_t[] expAlgoList = new EdkDll.EE_ExpressivAlgo_t[]
	{
		EdkDll.EE_ExpressivAlgo_t.EXP_BLINK,
		EdkDll.EE_ExpressivAlgo_t.EXP_CLENCH,
		EdkDll.EE_ExpressivAlgo_t.EXP_EYEBROW,
		EdkDll.EE_ExpressivAlgo_t.EXP_FURROW,
		EdkDll.EE_ExpressivAlgo_t.EXP_HORIEYE,
		EdkDll.EE_ExpressivAlgo_t.EXP_LAUGH,
		EdkDll.EE_ExpressivAlgo_t.EXP_NEUTRAL,
		EdkDll.EE_ExpressivAlgo_t.EXP_SMILE,
		EdkDll.EE_ExpressivAlgo_t.EXP_SMIRK_LEFT,
		EdkDll.EE_ExpressivAlgo_t.EXP_SMIRK_RIGHT,
		EdkDll.EE_ExpressivAlgo_t.EXP_WINK_LEFT,
		EdkDll.EE_ExpressivAlgo_t.EXP_WINK_RIGHT
	};
	public static bool[] isExpActiveList = new bool[EmoExpressiv.expAlgoList.Length];
	public static bool IsStarted = false;
	private void Update()
	{
	}
	private void Start()
	{
		if (!EmoExpressiv.IsStarted)
		{
			this.engine.ExpressivEmoStateUpdated += new EmoEngine.ExpressivEmoStateUpdatedEventHandler(EmoExpressiv.engine_ExpressivEmoStateUpdated);
			this.engine.ExpressivTrainingStarted += new EmoEngine.ExpressivTrainingStartedEventEventHandler(EmoExpressiv.engine_ExpressivTrainingStarted);
			this.engine.ExpressivTrainingSucceeded += new EmoEngine.ExpressivTrainingSucceededEventHandler(EmoExpressiv.engine_ExpressivTrainingSucceeded);
			this.engine.ExpressivTrainingCompleted += new EmoEngine.ExpressivTrainingCompletedEventHandler(EmoExpressiv.engine_ExpressivTrainingCompleted);
			this.engine.ExpressivTrainingRejected += new EmoEngine.ExpressivTrainingRejectedEventHandler(EmoExpressiv.engine_ExpressivTrainingRejected);
			EmoExpressiv.IsStarted = true;
		}
	}
	private static void engine_ExpressivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
	{
		EmoState emoState = e.emoState;
		EmoExpressiv.isBlink = emoState.ExpressivIsBlink();
		EmoExpressiv.isLeftWink = emoState.ExpressivIsLeftWink();
		EmoExpressiv.isRightWink = emoState.ExpressivIsRightWink();
		EmoExpressiv.isEyesOpen = emoState.ExpressivIsEyesOpen();
		EmoExpressiv.isLookingUp = emoState.ExpressivIsLookingUp();
		EmoExpressiv.isLookingDown = emoState.ExpressivIsLookingDown();
		EmoExpressiv.isLookingLeft = emoState.ExpressivIsLookingLeft();
		EmoExpressiv.isLookingRight = emoState.ExpressivIsLookingRight();
		emoState.ExpressivGetEyelidState(out EmoExpressiv.eyelidStateLeft, out EmoExpressiv.eyelidStateRight);
		emoState.ExpressivGetEyeLocation(out EmoExpressiv.eyeLocationX, out EmoExpressiv.eyeLocationY);
		EmoExpressiv.eyebrowExtent = emoState.ExpressivGetEyebrowExtent();
		EmoExpressiv.smileExtent = emoState.ExpressivGetSmileExtent();
		EmoExpressiv.clenchExtent = emoState.ExpressivGetClenchExtent();
		EmoExpressiv.upperFaceAction = emoState.ExpressivGetUpperFaceAction();
		EmoExpressiv.upperFacePower = emoState.ExpressivGetUpperFaceActionPower();
		EmoExpressiv.lowerFaceAction = emoState.ExpressivGetLowerFaceAction();
		EmoExpressiv.lowerFacePower = emoState.ExpressivGetLowerFaceActionPower();
		for (int i = 0; i < EmoExpressiv.expAlgoList.Length; i++)
		{
			EmoExpressiv.isExpActiveList[i] = emoState.ExpressivIsActive(EmoExpressiv.expAlgoList[i]);
		}
	}
	private static void engine_ExpressivTrainingStarted(object sender, EmoEngineEventArgs e)
	{
	}
	private static void engine_ExpressivTrainingSucceeded(object sender, EmoEngineEventArgs e)
	{
		EmoEngine.Instance.ExpressivSetTrainingControl(0u, EdkDll.EE_ExpressivTrainingControl_t.EXP_ACCEPT);
	}
	private static void engine_ExpressivTrainingCompleted(object sender, EmoEngineEventArgs e)
	{
	}
	private static void engine_ExpressivTrainingRejected(object sender, EmoEngineEventArgs e)
	{
	}
	public void StartTrainExpressiv(EdkDll.EE_ExpressivAlgo_t expressivAlg)
	{
		this.engine.ExpressivSetTrainingAction((uint)EmoUserManagement.currentUser, expressivAlg);
		this.engine.ExpressivSetTrainingControl((uint)EmoUserManagement.currentUser, EdkDll.EE_ExpressivTrainingControl_t.EXP_START);
	}
}
