using System;
using UnityEngine;
public class EmoAffectiv : MonoBehaviour
{
	private EmoEngine engine = EmoEngine.Instance;
	public static float longTermExcitementScore = 0f;
	public static float shortTermExcitementScore = 0f;
	public static float meditationScore = 0f;
	public static float frustrationScore = 0f;
	public static float boredomScore = 0f;
	public static EdkDll.EE_AffectivAlgo_t[] affAlgoList = new EdkDll.EE_AffectivAlgo_t[]
	{
		EdkDll.EE_AffectivAlgo_t.AFF_ENGAGEMENT_BOREDOM,
		EdkDll.EE_AffectivAlgo_t.AFF_EXCITEMENT,
		EdkDll.EE_AffectivAlgo_t.AFF_FRUSTRATION,
		EdkDll.EE_AffectivAlgo_t.AFF_MEDITATION
	};
	public static bool[] isAffActiveList = new bool[EmoAffectiv.affAlgoList.Length];
	private void Update()
	{
	}
	private void Start()
	{
		this.engine.AffectivEmoStateUpdated += new EmoEngine.AffectivEmoStateUpdatedEventHandler(EmoAffectiv.engine_AffectivEmoStateUpdated);
	}
	private static void engine_AffectivEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
	{
		EmoState emoState = e.emoState;
		EmoAffectiv.longTermExcitementScore = emoState.AffectivGetExcitementLongTermScore();
		EmoAffectiv.shortTermExcitementScore = emoState.AffectivGetExcitementShortTermScore();
		for (int i = 0; i < EmoAffectiv.affAlgoList.Length; i++)
		{
			EmoAffectiv.isAffActiveList[i] = emoState.AffectivIsActive(EmoAffectiv.affAlgoList[i]);
		}
		EmoAffectiv.meditationScore = emoState.AffectivGetMeditationScore();
		EmoAffectiv.frustrationScore = emoState.AffectivGetFrustrationScore();
		EmoAffectiv.boredomScore = emoState.AffectivGetEngagementBoredomScore();
	}
}
