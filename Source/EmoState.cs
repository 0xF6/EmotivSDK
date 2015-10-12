using System;
public class EmoState : ICloneable
{
	public IntPtr hEmoState;
	public EmoState(EmoState es)
	{
		this.hEmoState = EdkDll.ES_Create();
		EdkDll.ES_Copy(this.hEmoState, es.GetHandle());
	}
	public EmoState()
	{
		this.hEmoState = EdkDll.ES_Create();
	}
	~EmoState()
	{
		EdkDll.ES_Free(this.hEmoState);
	}
	public IntPtr GetHandle()
	{
		return this.hEmoState;
	}
	public object Clone()
	{
		return new EmoState(this);
	}
	public float GetTimeFromStart()
	{
		return EdkDll.ES_GetTimeFromStart(this.hEmoState);
	}
	public int GetHeadsetOn()
	{
		return EdkDll.ES_GetHeadsetOn(this.hEmoState);
	}
	public int GetNumContactQualityChannels()
	{
		return EdkDll.ES_GetNumContactQualityChannels(this.hEmoState);
	}
	public EdkDll.EE_EEG_ContactQuality_t GetContactQuality(int electroIdx)
	{
		return EdkDll.ES_GetContactQuality(this.hEmoState, electroIdx);
	}
	public EdkDll.EE_EEG_ContactQuality_t[] GetContactQualityFromAllChannels()
	{
		EdkDll.EE_EEG_ContactQuality_t[] result;
		EdkDll.ES_GetContactQualityFromAllChannels(this.hEmoState, out result);
		return result;
	}
	public bool ExpressivIsBlink()
	{
		return EdkDll.ES_ExpressivIsBlink(this.hEmoState);
	}
	public bool ExpressivIsLeftWink()
	{
		return EdkDll.ES_ExpressivIsLeftWink(this.hEmoState);
	}
	public bool ExpressivIsRightWink()
	{
		return EdkDll.ES_ExpressivIsRightWink(this.hEmoState);
	}
	public bool ExpressivIsEyesOpen()
	{
		return EdkDll.ES_ExpressivIsEyesOpen(this.hEmoState);
	}
	public bool ExpressivIsLookingUp()
	{
		return EdkDll.ES_ExpressivIsLookingUp(this.hEmoState);
	}
	public bool ExpressivIsLookingDown()
	{
		return EdkDll.ES_ExpressivIsLookingDown(this.hEmoState);
	}
	public bool ExpressivIsLookingLeft()
	{
		return EdkDll.ES_ExpressivIsLookingLeft(this.hEmoState);
	}
	public bool ExpressivIsLookingRight()
	{
		return EdkDll.ES_ExpressivIsLookingRight(this.hEmoState);
	}
	public void ExpressivGetEyelidState(out float leftEye, out float rightEye)
	{
		EdkDll.ES_ExpressivGetEyelidState(this.hEmoState, out leftEye, out rightEye);
	}
	public void ExpressivGetEyeLocation(out float x, out float y)
	{
		EdkDll.ES_ExpressivGetEyeLocation(this.hEmoState, out x, out y);
	}
	public float ExpressivGetEyebrowExtent()
	{
		return EdkDll.ES_ExpressivGetEyebrowExtent(this.hEmoState);
	}
	public float ExpressivGetSmileExtent()
	{
		return EdkDll.ES_ExpressivGetSmileExtent(this.hEmoState);
	}
	public float ExpressivGetClenchExtent()
	{
		return EdkDll.ES_ExpressivGetClenchExtent(this.hEmoState);
	}
	public EdkDll.EE_ExpressivAlgo_t ExpressivGetUpperFaceAction()
	{
		return EdkDll.ES_ExpressivGetUpperFaceAction(this.hEmoState);
	}
	public float ExpressivGetUpperFaceActionPower()
	{
		return EdkDll.ES_ExpressivGetUpperFaceActionPower(this.hEmoState);
	}
	public EdkDll.EE_ExpressivAlgo_t ExpressivGetLowerFaceAction()
	{
		return EdkDll.ES_ExpressivGetLowerFaceAction(this.hEmoState);
	}
	public float ExpressivGetLowerFaceActionPower()
	{
		return EdkDll.ES_ExpressivGetLowerFaceActionPower(this.hEmoState);
	}
	public bool ExpressivIsActive(EdkDll.EE_ExpressivAlgo_t type)
	{
		return EdkDll.ES_ExpressivIsActive(this.hEmoState, type);
	}
	public float AffectivGetExcitementLongTermScore()
	{
		return EdkDll.ES_AffectivGetExcitementLongTermScore(this.hEmoState);
	}
	public float AffectivGetExcitementShortTermScore()
	{
		return EdkDll.ES_AffectivGetExcitementShortTermScore(this.hEmoState);
	}
	public bool AffectivIsActive(EdkDll.EE_AffectivAlgo_t type)
	{
		return EdkDll.ES_AffectivIsActive(this.hEmoState, type);
	}
	public float AffectivGetMeditationScore()
	{
		return EdkDll.ES_AffectivGetMeditationScore(this.hEmoState);
	}
	public float AffectivGetFrustrationScore()
	{
		return EdkDll.ES_AffectivGetFrustrationScore(this.hEmoState);
	}
	public float AffectivGetEngagementBoredomScore()
	{
		return EdkDll.ES_AffectivGetEngagementBoredomScore(this.hEmoState);
	}
	public EdkDll.EE_CognitivAction_t CognitivGetCurrentAction()
	{
		return EdkDll.ES_CognitivGetCurrentAction(this.hEmoState);
	}
	public float CognitivGetCurrentActionPower()
	{
		return EdkDll.ES_CognitivGetCurrentActionPower(this.hEmoState);
	}
	public bool CognitivIsActive()
	{
		return EdkDll.ES_CognitivIsActive(this.hEmoState);
	}
	public EdkDll.EE_SignalStrength_t GetWirelessSignalStatus()
	{
		return EdkDll.ES_GetWirelessSignalStatus(this.hEmoState);
	}
	public void GetBatteryChargeLevel(out int chargeLevel, out int maxChargeLevel)
	{
		EdkDll.ES_GetBatteryChargeLevel(this.hEmoState, out chargeLevel, out maxChargeLevel);
	}
	public bool AffectivEqual(EmoState state)
	{
		return EdkDll.ES_AffectivEqual(this.GetHandle(), state.GetHandle());
	}
	public bool ExpressivEqual(EmoState state)
	{
		return EdkDll.ES_ExpressivEqual(this.GetHandle(), state.GetHandle());
	}
	public bool CognitivEqual(EmoState state)
	{
		return EdkDll.ES_CognitivEqual(this.GetHandle(), state.GetHandle());
	}
	public bool EmoEngineEqual(EmoState state)
	{
		return EdkDll.ES_EmoEngineEqual(this.GetHandle(), state.GetHandle());
	}
	public bool Equals(EmoState a, EmoState b)
	{
		return EdkDll.ES_Equal(a.GetHandle(), b.GetHandle());
	}
}
