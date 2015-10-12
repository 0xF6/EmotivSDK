using System;
using System.Runtime.InteropServices;
using System.Text;
public class EdkDll
{
	public enum EE_ExpressivThreshold_t
	{
		EXP_SENSITIVITY
	}
	public enum EE_ExpressivTrainingControl_t
	{
		EXP_NONE,
		EXP_START,
		EXP_ACCEPT,
		EXP_REJECT,
		EXP_ERASE,
		EXP_RESET
	}
	public enum EE_ExpressivSignature_t
	{
		EXP_SIG_UNIVERSAL,
		EXP_SIG_TRAINED
	}
	public enum EE_CognitivTrainingControl_t
	{
		COG_NONE,
		COG_START,
		COG_ACCEPT,
		COG_REJECT,
		COG_ERASE,
		COG_RESET
	}
	public enum EE_Event_t
	{
		EE_UnknownEvent,
		EE_EmulatorError,
		EE_ReservedEvent,
		EE_UserAdded = 16,
		EE_UserRemoved = 32,
		EE_EmoStateUpdated = 64,
		EE_ProfileEvent = 128,
		EE_CognitivEvent = 256,
		EE_ExpressivEvent = 512,
		EE_InternalStateChanged = 1024,
		EE_AllEvent = 2032
	}
	public enum EE_ExpressivEvent_t
	{
		EE_ExpressivNoEvent,
		EE_ExpressivTrainingStarted,
		EE_ExpressivTrainingSucceeded,
		EE_ExpressivTrainingFailed,
		EE_ExpressivTrainingCompleted,
		EE_ExpressivTrainingDataErased,
		EE_ExpressivTrainingRejected,
		EE_ExpressivTrainingReset
	}
	public enum EE_CognitivEvent_t
	{
		EE_CognitivNoEvent,
		EE_CognitivTrainingStarted,
		EE_CognitivTrainingSucceeded,
		EE_CognitivTrainingFailed,
		EE_CognitivTrainingCompleted,
		EE_CognitivTrainingDataErased,
		EE_CognitivTrainingRejected,
		EE_CognitivTrainingReset,
		EE_CognitivAutoSamplingNeutralCompleted,
		EE_CognitivSignatureUpdated
	}
	public enum EE_DataChannel_t
	{
		COUNTER,
		INTERPOLATED,
		RAW_CQ,
		AF3,
		F7,
		F3,
		FC5,
		T7,
		P7,
		O1,
		O2,
		P8,
		T8,
		FC6,
		F4,
		F8,
		AF4,
		GYROX,
		GYROY,
		TIMESTAMP,
		ES_TIMESTAMP,
		FUNC_ID,
		FUNC_VALUE,
		MARKER,
		SYNC_SIGNAL
	}
	[StructLayout(LayoutKind.Sequential)]
	public class InputSensorDescriptor_t
	{
		public EdkDll.EE_InputChannels_t channelId;
		public int fExists;
		public string pszLabel;
		public double xLoc;
		public double yLoc;
		public double zLoc;
	}
	public enum EE_EmotivSuite_t
	{
		EE_EXPRESSIV,
		EE_AFFECTIV,
		EE_COGNITIV
	}
	public enum EE_ExpressivAlgo_t
	{
		EXP_NEUTRAL = 1,
		EXP_BLINK,
		EXP_WINK_LEFT = 4,
		EXP_WINK_RIGHT = 8,
		EXP_HORIEYE = 16,
		EXP_EYEBROW = 32,
		EXP_FURROW = 64,
		EXP_SMILE = 128,
		EXP_CLENCH = 256,
		EXP_LAUGH = 512,
		EXP_SMIRK_LEFT = 1024,
		EXP_SMIRK_RIGHT = 2048
	}
	public enum EE_AffectivAlgo_t
	{
		AFF_EXCITEMENT = 1,
		AFF_MEDITATION,
		AFF_FRUSTRATION = 4,
		AFF_ENGAGEMENT_BOREDOM = 8
	}
	public enum EE_CognitivAction_t
	{
		COG_NEUTRAL = 1,
		COG_PUSH,
		COG_PULL = 4,
		COG_LIFT = 8,
		COG_DROP = 16,
		COG_LEFT = 32,
		COG_RIGHT = 64,
		COG_ROTATE_LEFT = 128,
		COG_ROTATE_RIGHT = 256,
		COG_ROTATE_CLOCKWISE = 512,
		COG_ROTATE_COUNTER_CLOCKWISE = 1024,
		COG_ROTATE_FORWARDS = 2048,
		COG_ROTATE_REVERSE = 4096,
		COG_DISAPPEAR = 8192
	}
	public enum EE_CognitivLevel_t
	{
		COG_LEVEL1 = 1,
		COG_LEVEL2,
		COG_LEVEL3,
		COG_LEVEL4
	}
	public enum EE_SignalStrength_t
	{
		NO_SIGNAL,
		BAD_SIGNAL,
		GOOD_SIGNAL
	}
	public enum EE_InputChannels_t
	{
		EE_CHAN_CMS,
		EE_CHAN_DRL,
		EE_CHAN_FP1,
		EE_CHAN_AF3,
		EE_CHAN_F7,
		EE_CHAN_F3,
		EE_CHAN_FC5,
		EE_CHAN_T7,
		EE_CHAN_P7,
		EE_CHAN_O1,
		EE_CHAN_O2,
		EE_CHAN_P8,
		EE_CHAN_T8,
		EE_CHAN_FC6,
		EE_CHAN_F4,
		EE_CHAN_F8,
		EE_CHAN_AF4,
		EE_CHAN_FP2
	}
	public enum EE_EEG_ContactQuality_t
	{
		EEG_CQ_NO_SIGNAL,
		EEG_CQ_VERY_BAD,
		EEG_CQ_POOR,
		EEG_CQ_FAIR,
		EEG_CQ_GOOD
	}
	public const int EDK_OK = 0;
	public const int EDK_UNKNOWN_ERROR = 1;
	public const int EDK_INVALID_PROFILE_ARCHIVE = 257;
	public const int EDK_NO_USER_FOR_BASEPROFILE = 258;
	public const int EDK_CANNOT_ACQUIRE_DATA = 512;
	public const int EDK_BUFFER_TOO_SMALL = 768;
	public const int EDK_OUT_OF_RANGE = 769;
	public const int EDK_INVALID_PARAMETER = 770;
	public const int EDK_PARAMETER_LOCKED = 771;
	public const int EDK_COG_INVALID_TRAINING_ACTION = 772;
	public const int EDK_COG_INVALID_TRAINING_CONTROL = 773;
	public const int EDK_COG_INVALID_ACTIVE_ACTION = 774;
	public const int EDK_COG_EXCESS_MAX_ACTIONS = 775;
	public const int EDK_EXP_NO_SIG_AVAILABLE = 776;
	public const int EDK_FILESYSTEM_ERROR = 777;
	public const int EDK_INVALID_USER_ID = 1024;
	public const int EDK_EMOENGINE_UNINITIALIZED = 1280;
	public const int EDK_EMOENGINE_DISCONNECTED = 1281;
	public const int EDK_EMOENGINE_PROXY_ERROR = 1282;
	public const int EDK_NO_EVENT = 1536;
	public const int EDK_GYRO_NOT_CALIBRATED = 1792;
	public const int EDK_OPTIMIZATION_IS_ON = 2048;
	public const int EDK_RESERVED1 = 2304;
	[DllImport("edk.dll", EntryPoint = "EE_EngineConnect")]
	private static extern int Unmanged_EE_EngineConnect(string security);
	[DllImport("edk.dll", EntryPoint = "EE_EngineRemoteConnect")]
	private static extern int Unmanged_EE_EngineRemoteConnect(string szHost, ushort port);
	[DllImport("edk.dll", EntryPoint = "EE_EngineDisconnect")]
	private static extern int Unmanged_EE_EngineDisconnect();
	[DllImport("edk.dll", EntryPoint = "EE_EnableDiagnostics")]
	private static extern int Unmanged_EE_EnableDiagnostics(string szFilename, int fEnable, int nReserved);
	[DllImport("edk.dll", EntryPoint = "EE_EmoEngineEventCreate")]
	private static extern IntPtr Unmanged_EE_EmoEngineEventCreate();
	[DllImport("edk.dll", EntryPoint = "EE_ProfileEventCreate")]
	private static extern IntPtr Unmanged_EE_ProfileEventCreate();
	[DllImport("edk.dll", EntryPoint = "EE_EmoEngineEventFree")]
	private static extern void Unmanged_EE_EmoEngineEventFree(IntPtr hEvent);
	[DllImport("edk.dll", EntryPoint = "EE_EmoStateCreate")]
	private static extern IntPtr Unmanged_EE_EmoStateCreate();
	[DllImport("edk.dll", EntryPoint = "EE_EmoStateFree")]
	private static extern void Unmanged_EE_EmoStateFree(IntPtr hState);
	[DllImport("edk.dll", EntryPoint = "EE_EmoEngineEventGetType")]
	private static extern EdkDll.EE_Event_t Unmanged_EE_EmoEngineEventGetType(IntPtr hEvent);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivEventGetType")]
	private static extern EdkDll.EE_CognitivEvent_t Unmanged_EE_CognitivEventGetType(IntPtr hEvent);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivEventGetType")]
	private static extern EdkDll.EE_ExpressivEvent_t Unmanged_EE_ExpressivEventGetType(IntPtr hEvent);
	[DllImport("edk.dll", EntryPoint = "EE_EmoEngineEventGetUserId")]
	private static extern int Unmanged_EE_EmoEngineEventGetUserId(IntPtr hEvent, out uint pUserIdOut);
	[DllImport("edk.dll", EntryPoint = "EE_EmoEngineEventGetEmoState")]
	private static extern int Unmanged_EE_EmoEngineEventGetEmoState(IntPtr hEvent, IntPtr hEmoState);
	[DllImport("edk.dll", EntryPoint = "EE_EngineGetNextEvent")]
	private static extern int Unmanged_EE_EngineGetNextEvent(IntPtr hEvent);
	[DllImport("edk.dll", EntryPoint = "EE_EngineClearEventQueue")]
	private static extern int Unmanged_EE_EngineClearEventQueue(int eventTypes);
	[DllImport("edk.dll", EntryPoint = "EE_EngineGetNumUser")]
	private static extern int Unmanged_EE_EngineGetNumUser(out uint pNumUserOut);
	[DllImport("edk.dll", EntryPoint = "EE_SetHardwarePlayerDisplay")]
	private static extern int Unmanged_EE_SetHardwarePlayerDisplay(uint userId, uint playerNum);
	[DllImport("edk.dll", EntryPoint = "EE_SetUserProfile")]
	private static extern int Unmanged_EE_SetUserProfile(uint userId, byte[] profileBuffer, uint length);
	[DllImport("edk.dll", EntryPoint = "EE_GetUserProfile")]
	private static extern int Unmanged_EE_GetUserProfile(uint userId, IntPtr hEvent);
	[DllImport("edk.dll", EntryPoint = "EE_GetBaseProfile")]
	private static extern int Unmanged_EE_GetBaseProfile(IntPtr hEvent);
	[DllImport("edk.dll", EntryPoint = "EE_GetUserProfileSize")]
	private static extern int Unmanged_EE_GetUserProfileSize(IntPtr hEvt, out uint pProfileSizeOut);
	[DllImport("edk.dll", EntryPoint = "EE_GetUserProfileBytes")]
	private static extern int Unmanged_EE_GetUserProfileBytes(IntPtr hEvt, byte[] destBuffer, uint length);
	[DllImport("edk.dll", EntryPoint = "EE_LoadUserProfile")]
	private static extern int Unmanged_EE_LoadUserProfile(uint userID, string szInputFilename);
	[DllImport("edk.dll", EntryPoint = "EE_SaveUserProfile")]
	private static extern int Unmanged_EE_SaveUserProfile(uint userID, string szOutputFilename);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivSetThreshold")]
	private static extern int Unmanged_EE_ExpressivSetThreshold(uint userId, EdkDll.EE_ExpressivAlgo_t algoName, EdkDll.EE_ExpressivThreshold_t thresholdName, int value);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivGetThreshold")]
	private static extern int Unmanged_EE_ExpressivGetThreshold(uint userId, EdkDll.EE_ExpressivAlgo_t algoName, EdkDll.EE_ExpressivThreshold_t thresholdName, out int pValueOut);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivSetTrainingAction")]
	private static extern int Unmanged_EE_ExpressivSetTrainingAction(uint userId, EdkDll.EE_ExpressivAlgo_t action);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivSetTrainingControl")]
	private static extern int Unmanged_EE_ExpressivSetTrainingControl(uint userId, EdkDll.EE_ExpressivTrainingControl_t control);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivGetTrainingAction")]
	private static extern int Unmanged_EE_ExpressivGetTrainingAction(uint userId, out EdkDll.EE_ExpressivAlgo_t pActionOut);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivGetTrainingTime")]
	private static extern int Unmanged_EE_ExpressivGetTrainingTime(uint userId, out uint pTrainingTimeOut);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivGetTrainedSignatureActions")]
	private static extern int Unmanged_EE_ExpressivGetTrainedSignatureActions(uint userId, out uint pTrainedActionsOut);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivGetTrainedSignatureAvailable")]
	private static extern int Unmanged_EE_ExpressivGetTrainedSignatureAvailable(uint userId, out int pfAvailableOut);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivSetSignatureType")]
	private static extern int Unmanged_EE_ExpressivSetSignatureType(uint userId, EdkDll.EE_ExpressivSignature_t sigType);
	[DllImport("edk.dll", EntryPoint = "EE_ExpressivGetSignatureType")]
	private static extern int Unmanged_EE_ExpressivGetSignatureType(uint userId, out EdkDll.EE_ExpressivSignature_t pSigTypeOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivSetActiveActions")]
	private static extern int Unmanged_EE_CognitivSetActiveActions(uint userId, uint activeActions);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetActiveActions")]
	private static extern int Unmanged_EE_CognitivGetActiveActions(uint userId, out uint pActiveActionsOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetTrainingTime")]
	private static extern int Unmanged_EE_CognitivGetTrainingTime(uint userId, out uint pTrainingTimeOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivSetTrainingControl")]
	private static extern int Unmanged_EE_CognitivSetTrainingControl(uint userId, EdkDll.EE_CognitivTrainingControl_t control);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivSetTrainingAction")]
	private static extern int Unmanged_EE_CognitivSetTrainingAction(uint userId, EdkDll.EE_CognitivAction_t action);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetTrainingAction")]
	private static extern int Unmanged_EE_CognitivGetTrainingAction(uint userId, out EdkDll.EE_CognitivAction_t pActionOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetTrainedSignatureActions")]
	private static extern int Unmanged_EE_CognitivGetTrainedSignatureActions(uint userId, out uint pTrainedActionsOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetOverallSkillRating")]
	private static extern int Unmanged_EE_CognitivGetOverallSkillRating(uint userId, out float pOverallSkillRatingOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetActionSkillRating")]
	private static extern int Unmanged_EE_CognitivGetActionSkillRating(uint userId, EdkDll.EE_CognitivAction_t action, out float pActionSkillRatingOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivSetActivationLevel")]
	private static extern int Unmanged_EE_CognitivSetActivationLevel(uint userId, int level);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivSetActionSensitivity")]
	private static extern int Unmanged_EE_CognitivSetActionSensitivity(uint userId, int action1Sensitivity, int action2Sensitivity, int action3Sensitivity, int action4Sensitivity);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetActivationLevel")]
	private static extern int Unmanged_EE_CognitivGetActivationLevel(uint userId, out int pLevelOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetActionSensitivity")]
	private static extern int Unmanged_EE_CognitivGetActionSensitivity(uint userId, out int pAction1SensitivityOut, out int pAction2SensitivityOut, out int pAction3SensitivityOut, out int pAction4SensitivityOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivStartSamplingNeutral")]
	private static extern int Unmanged_EE_CognitivStartSamplingNeutral(uint userId);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivStopSamplingNeutral")]
	private static extern int Unmanged_EE_CognitivStopSamplingNeutral(uint userId);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivSetSignatureCaching")]
	private static extern int Unmanged_EE_CognitivSetSignatureCaching(uint userId, uint enabled);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetSignatureCaching")]
	private static extern int Unmanged_EE_CognitivGetSignatureCaching(uint userId, out uint pEnabledOut);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivSetSignatureCacheSize")]
	private static extern int Unmanged_EE_CognitivSetSignatureCacheSize(uint userId, uint size);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivGetSignatureCacheSize")]
	private static extern int Unmanged_EE_CognitivGetSignatureCacheSize(uint userId, out uint pSizeOut);
	[DllImport("edk.dll", EntryPoint = "EE_HeadsetGetSensorDetails")]
	private static extern int Unmanged_EE_HeadsetGetSensorDetails(EdkDll.EE_InputChannels_t channelId, out EdkDll.InputSensorDescriptor_t pDescriptorOut);
	[DllImport("edk.dll", EntryPoint = "EE_HardwareGetVersion")]
	private static extern int Unmanged_EE_HardwareGetVersion(uint userId, out uint pHwVersionOut);
	[DllImport("edk.dll", EntryPoint = "EE_SoftwareGetVersion")]
	private static extern int Unmanged_EE_SoftwareGetVersion(StringBuilder pszVersionOut, uint nVersionChars, out uint pBuildNumOut);
	[DllImport("edk.dll", EntryPoint = "EE_HeadsetGetGyroDelta")]
	private static extern int Unmanged_EE_HeadsetGetGyroDelta(uint userId, out int pXOut, out int pYOut);
	[DllImport("edk.dll", EntryPoint = "EE_HeadsetGyroRezero")]
	private static extern int Unmanged_EE_HeadsetGyroRezero(uint userId);
	[DllImport("edk.dll", EntryPoint = "EE_OptimizationParamCreate")]
	private static extern IntPtr Unmanged_EE_OptimizationParamCreate();
	[DllImport("edk.dll", EntryPoint = "EE_OptimizationParamFree")]
	private static extern void Unmanged_EE_OptimizationParamFree(IntPtr hParam);
	[DllImport("edk.dll", EntryPoint = "EE_OptimizationEnable")]
	private static extern int Unmanged_EE_OptimizationEnable(IntPtr hParam);
	[DllImport("edk.dll", EntryPoint = "EE_OptimizationIsEnabled")]
	private static extern int Unmanged_EE_OptimizationIsEnabled(out bool pEnabledOut);
	[DllImport("edk.dll", EntryPoint = "EE_OptimizationDisable")]
	private static extern int Unmanged_EE_OptimizationDisable();
	[DllImport("edk.dll", EntryPoint = "EE_OptimizationGetParam")]
	private static extern int Unmanged_EE_OptimizationGetParam(IntPtr hParam);
	[DllImport("edk.dll", EntryPoint = "EE_OptimizationGetVitalAlgorithm")]
	private static extern int Unmanged_EE_OptimizationGetVitalAlgorithm(IntPtr hParam, EdkDll.EE_EmotivSuite_t suite, out uint pVitalAlgorithmBitVectorOut);
	[DllImport("edk.dll", EntryPoint = "EE_OptimizationSetVitalAlgorithm")]
	private static extern int Unmanged_EE_OptimizationSetVitalAlgorithm(IntPtr hParam, EdkDll.EE_EmotivSuite_t suite, uint vitalAlgorithmBitVector);
	[DllImport("edk.dll", EntryPoint = "EE_ResetDetection")]
	private static extern int Unmanged_EE_ResetDetection(uint userId, EdkDll.EE_EmotivSuite_t suite, uint detectionBitVector);
	[DllImport("edk.dll", EntryPoint = "EE_DataCreate")]
	private static extern IntPtr Unmanaged_EE_DataCreate();
	[DllImport("edk.dll", EntryPoint = "EE_DataFree")]
	private static extern void Unmanaged_EE_DataFree(IntPtr hData);
	[DllImport("edk.dll", EntryPoint = "EE_DataUpdateHandle")]
	private static extern int Unmanaged_EE_DataUpdateHandle(uint userId, IntPtr hData);
	[DllImport("edk.dll", EntryPoint = "EE_DataGet")]
	private static extern int Unmanaged_EE_DataGet(IntPtr hData, EdkDll.EE_DataChannel_t channel, double[] buffer, uint bufferSizeInSample);
	[DllImport("edk.dll", EntryPoint = "EE_DataGetNumberOfSample")]
	private static extern int Unmanaged_EE_DataGetNumberOfSample(IntPtr hData, out uint nSampleOut);
	[DllImport("edk.dll", EntryPoint = "EE_DataSetBufferSizeInSec")]
	private static extern int Unmanaged_EE_DataSetBufferSizeInSec(float bufferSizeInSec);
	[DllImport("edk.dll", EntryPoint = "EE_DataGetBufferSizeInSec")]
	private static extern int Unmanaged_EE_DataGetBufferSizeInSec(out float pBufferSizeInSecOut);
	[DllImport("edk.dll", EntryPoint = "EE_DataAcquisitionEnable")]
	private static extern int Unmanaged_EE_DataAcquisitionEnable(uint userId, bool enable);
	[DllImport("edk.dll", EntryPoint = "EE_DataAcquisitionIsEnabled")]
	private static extern int Unmanaged_EE_DataAcquisitionIsEnabled(uint userId, out bool pEnableOut);
	[DllImport("edk.dll", EntryPoint = "EE_DataSetSychronizationSignal")]
	private static extern int Unmanaged_EE_DataSetSychronizationSignal(uint userId, int signal);
	[DllImport("edk.dll", EntryPoint = "EE_DataSetMarker")]
	private static extern int Unmanaged_EE_DataSetMarker(uint userId, int marker);
	[DllImport("edk.dll", EntryPoint = "EE_DataGetSamplingRate")]
	private static extern int Unmanaged_EE_DataGetSamplingRate(uint userId, out uint pSamplingRate);
	[DllImport("edk.dll", EntryPoint = "ES_Create")]
	private static extern IntPtr Unmanaged_ES_Create();
	[DllImport("edk.dll", EntryPoint = "ES_Free")]
	private static extern void Unmanaged_ES_Free(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_Init")]
	private static extern void Unmanaged_ES_Init(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_GetTimeFromStart")]
	private static extern float Unmanaged_ES_GetTimeFromStart(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_GetHeadsetOn")]
	private static extern int Unmanaged_ES_GetHeadsetOn(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_GetNumContactQualityChannels")]
	private static extern int Unmanaged_ES_GetNumContactQualityChannels(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_GetContactQuality")]
	private static extern EdkDll.EE_EEG_ContactQuality_t Unmanaged_ES_GetContactQuality(IntPtr state, int electroIdx);
	[DllImport("edk.dll", EntryPoint = "ES_GetContactQualityFromAllChannels")]
	private static extern int Unmanaged_ES_GetContactQualityFromAllChannels(IntPtr state, EdkDll.EE_EEG_ContactQuality_t[] contactQuality, uint numChannels);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsBlink")]
	private static extern bool Unmanaged_ES_ExpressivIsBlink(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsLeftWink")]
	private static extern bool Unmanaged_ES_ExpressivIsLeftWink(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsRightWink")]
	private static extern bool Unmanaged_ES_ExpressivIsRightWink(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsEyesOpen")]
	private static extern bool Unmanaged_ES_ExpressivIsEyesOpen(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsLookingUp")]
	private static extern bool Unmanaged_ES_ExpressivIsLookingUp(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsLookingDown")]
	private static extern bool Unmanaged_ES_ExpressivIsLookingDown(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsLookingLeft")]
	private static extern bool Unmanaged_ES_ExpressivIsLookingLeft(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsLookingRight")]
	private static extern bool Unmanaged_ES_ExpressivIsLookingRight(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetEyelidState")]
	private static extern void Unmanaged_ES_ExpressivGetEyelidState(IntPtr state, out float leftEye, out float rightEye);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetEyeLocation")]
	private static extern void Unmanaged_ES_ExpressivGetEyeLocation(IntPtr state, out float x, out float y);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetEyebrowExtent")]
	private static extern float Unmanaged_ES_ExpressivGetEyebrowExtent(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetSmileExtent")]
	private static extern float Unmanaged_ES_ExpressivGetSmileExtent(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetClenchExtent")]
	private static extern float Unmanaged_ES_ExpressivGetClenchExtent(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetUpperFaceAction")]
	private static extern EdkDll.EE_ExpressivAlgo_t Unmanaged_ES_ExpressivGetUpperFaceAction(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetUpperFaceActionPower")]
	private static extern float Unmanaged_ES_ExpressivGetUpperFaceActionPower(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetLowerFaceAction")]
	private static extern EdkDll.EE_ExpressivAlgo_t Unmanaged_ES_ExpressivGetLowerFaceAction(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivGetLowerFaceActionPower")]
	private static extern float Unmanaged_ES_ExpressivGetLowerFaceActionPower(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivIsActive")]
	private static extern bool Unmanaged_ES_ExpressivIsActive(IntPtr state, EdkDll.EE_ExpressivAlgo_t type);
	[DllImport("edk.dll", EntryPoint = "ES_AffectivGetExcitementLongTermScore")]
	private static extern float Unmanaged_ES_AffectivGetExcitementLongTermScore(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_AffectivGetExcitementShortTermScore")]
	private static extern float Unmanaged_ES_AffectivGetExcitementShortTermScore(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_AffectivIsActive")]
	private static extern bool Unmanaged_ES_AffectivIsActive(IntPtr state, EdkDll.EE_AffectivAlgo_t type);
	[DllImport("edk.dll", EntryPoint = "ES_AffectivGetMeditationScore")]
	private static extern float Unmanaged_ES_AffectivGetMeditationScore(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_AffectivGetFrustrationScore")]
	private static extern float Unmanaged_ES_AffectivGetFrustrationScore(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_AffectivGetEngagementBoredomScore")]
	private static extern float Unmanaged_ES_AffectivGetEngagementBoredomScore(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_CognitivGetCurrentAction")]
	private static extern EdkDll.EE_CognitivAction_t Unmanaged_ES_CognitivGetCurrentAction(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_CognitivGetCurrentActionPower")]
	private static extern float Unmanaged_ES_CognitivGetCurrentActionPower(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_CognitivIsActive")]
	private static extern bool Unmanaged_ES_CognitivIsActive(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_CognitivGetCurrentLevelRating")]
	private static extern float Unmanaged_ES_CognitivGetCurrentLevelRating(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_GetWirelessSignalStatus")]
	private static extern EdkDll.EE_SignalStrength_t Unmanaged_ES_GetWirelessSignalStatus(IntPtr state);
	[DllImport("edk.dll", EntryPoint = "ES_Copy")]
	private static extern void Unmanaged_ES_Copy(IntPtr a, IntPtr b);
	[DllImport("edk.dll", EntryPoint = "ES_AffectivEqual")]
	private static extern bool Unmanaged_ES_AffectivEqual(IntPtr a, IntPtr b);
	[DllImport("edk.dll", EntryPoint = "ES_ExpressivEqual")]
	private static extern bool Unmanaged_ES_ExpressivEqual(IntPtr a, IntPtr b);
	[DllImport("edk.dll", EntryPoint = "ES_CognitivEqual")]
	private static extern bool Unmanaged_ES_CognitivEqual(IntPtr a, IntPtr b);
	[DllImport("edk.dll", EntryPoint = "ES_EmoEngineEqual")]
	private static extern bool Unmanaged_ES_EmoEngineEqual(IntPtr a, IntPtr b);
	[DllImport("edk.dll", EntryPoint = "ES_Equal")]
	private static extern bool Unmanaged_ES_Equal(IntPtr a, IntPtr b);
	[DllImport("edk.dll", EntryPoint = "ES_GetBatteryChargeLevel")]
	private static extern void Unmanaged_ES_GetBatteryChargeLevel(IntPtr state, out int chargeLevel, out int maxChargeLevel);
	[DllImport("edk.dll", EntryPoint = "EE_CognitivSetCurrentLevel")]
	private static extern int Unmanaged_EE_CognitivSetCurrentLevel(short userId, EdkDll.EE_CognitivLevel_t level, EdkDll.EE_CognitivAction_t level1Action, EdkDll.EE_CognitivAction_t level2Action, EdkDll.EE_CognitivAction_t level3Action, EdkDll.EE_CognitivAction_t level4Action);
	public static int EE_CognitivSetCurrentLevel(short userId, EdkDll.EE_CognitivLevel_t level, EdkDll.EE_CognitivAction_t level1Action, EdkDll.EE_CognitivAction_t level2Action, EdkDll.EE_CognitivAction_t level3Action, EdkDll.EE_CognitivAction_t level4Action)
	{
		return EdkDll.Unmanaged_EE_CognitivSetCurrentLevel(userId, level, level1Action, level2Action, level3Action, level4Action);
	}
	[DllImport("cognitivEX.dll", EntryPoint = "SetMultiActiveActions")]
	private static extern void Unmanaged_SetMultiActiveActions(int UserID, EdkDll.EE_CognitivAction_t[] activeActions, int numOfActions);
	public static void SetMultiActiveActions(int UserID, EdkDll.EE_CognitivAction_t[] activeActions, int numOfActions)
	{
		EdkDll.Unmanaged_SetMultiActiveActions(UserID, activeActions, numOfActions);
	}
	public static int EE_EngineConnect(string security)
	{
		if (EdkDll.Unmanged_EE_EngineConnect(security) != 0)
		{
			return EdkDll.Unmanged_EE_EngineConnect(security);
		}
		double x = CustomerSecurity.EE_GetSecurityCode();
		double x2 = CustomerSecurity.emotiv_func(x);
		int num = CustomerSecurity.EE_CheckSecurityCode(x2);
		if (num != 0)
		{
			return CustomerSecurity.EE_CheckSecurityCode(x2);
		}
		return 0;
	}
	public static int EE_EngineRemoteConnect(string szHost, ushort port)
	{
		return EdkDll.Unmanged_EE_EngineRemoteConnect(szHost, port);
	}
	public static int EE_EngineDisconnect()
	{
		return EdkDll.Unmanged_EE_EngineDisconnect();
	}
	public static int EE_EnableDiagnostics(string szFilename, int fEnable, int nReserved)
	{
		return EdkDll.Unmanged_EE_EnableDiagnostics(szFilename, fEnable, nReserved);
	}
	public static IntPtr EE_EmoEngineEventCreate()
	{
		return EdkDll.Unmanged_EE_EmoEngineEventCreate();
	}
	public static IntPtr EE_ProfileEventCreate()
	{
		return EdkDll.Unmanged_EE_ProfileEventCreate();
	}
	public static void EE_EmoEngineEventFree(IntPtr hEvent)
	{
		EdkDll.Unmanged_EE_EmoEngineEventFree(hEvent);
	}
	public static IntPtr EE_EmoStateCreate()
	{
		return EdkDll.Unmanged_EE_EmoStateCreate();
	}
	public static void EE_EmoStateFree(IntPtr hState)
	{
		EdkDll.Unmanged_EE_EmoStateFree(hState);
	}
	public static EdkDll.EE_Event_t EE_EmoEngineEventGetType(IntPtr hEvent)
	{
		return EdkDll.Unmanged_EE_EmoEngineEventGetType(hEvent);
	}
	public static EdkDll.EE_CognitivEvent_t EE_CognitivEventGetType(IntPtr hEvent)
	{
		return EdkDll.Unmanged_EE_CognitivEventGetType(hEvent);
	}
	public static EdkDll.EE_ExpressivEvent_t EE_ExpressivEventGetType(IntPtr hEvent)
	{
		return EdkDll.Unmanged_EE_ExpressivEventGetType(hEvent);
	}
	public static int EE_EmoEngineEventGetUserId(IntPtr hEvent, out uint pUserIdOut)
	{
		return EdkDll.Unmanged_EE_EmoEngineEventGetUserId(hEvent, out pUserIdOut);
	}
	public static int EE_EmoEngineEventGetEmoState(IntPtr hEvent, IntPtr hEmoState)
	{
		return EdkDll.Unmanged_EE_EmoEngineEventGetEmoState(hEvent, hEmoState);
	}
	public static int EE_EngineGetNextEvent(IntPtr hEvent)
	{
		return EdkDll.Unmanged_EE_EngineGetNextEvent(hEvent);
	}
	public static int EE_EngineClearEventQueue(int eventTypes)
	{
		return EdkDll.Unmanged_EE_EngineClearEventQueue(eventTypes);
	}
	public static int EE_EngineGetNumUser(out uint pNumUserOut)
	{
		return EdkDll.Unmanged_EE_EngineGetNumUser(out pNumUserOut);
	}
	public static int EE_SetHardwarePlayerDisplay(uint userId, uint playerNum)
	{
		return EdkDll.Unmanged_EE_SetHardwarePlayerDisplay(userId, playerNum);
	}
	public static int EE_SetUserProfile(uint userId, byte[] profileBuffer, uint length)
	{
		return EdkDll.Unmanged_EE_SetUserProfile(userId, profileBuffer, length);
	}
	public static int EE_GetUserProfile(uint userId, IntPtr hEvent)
	{
		return EdkDll.Unmanged_EE_GetUserProfile(userId, hEvent);
	}
	public static int EE_GetBaseProfile(IntPtr hEvent)
	{
		return EdkDll.Unmanged_EE_GetBaseProfile(hEvent);
	}
	public static int EE_GetUserProfileSize(IntPtr hEvt, out uint pProfileSizeOut)
	{
		return EdkDll.Unmanged_EE_GetUserProfileSize(hEvt, out pProfileSizeOut);
	}
	public static int EE_GetUserProfileBytes(IntPtr hEvt, byte[] destBuffer, uint length)
	{
		return EdkDll.Unmanged_EE_GetUserProfileBytes(hEvt, destBuffer, length);
	}
	public static int EE_LoadUserProfile(uint userID, string szInputFilename)
	{
		return EdkDll.Unmanged_EE_LoadUserProfile(userID, szInputFilename);
	}
	public static int EE_SaveUserProfile(uint userID, string szOutputFilename)
	{
		return EdkDll.Unmanged_EE_SaveUserProfile(userID, szOutputFilename);
	}
	public static int EE_ExpressivSetThreshold(uint userId, EdkDll.EE_ExpressivAlgo_t algoName, EdkDll.EE_ExpressivThreshold_t thresholdName, int value)
	{
		return EdkDll.Unmanged_EE_ExpressivSetThreshold(userId, algoName, thresholdName, value);
	}
	public static int EE_ExpressivGetThreshold(uint userId, EdkDll.EE_ExpressivAlgo_t algoName, EdkDll.EE_ExpressivThreshold_t thresholdName, out int pValueOut)
	{
		return EdkDll.Unmanged_EE_ExpressivGetThreshold(userId, algoName, thresholdName, out pValueOut);
	}
	public static int EE_ExpressivSetTrainingAction(uint userId, EdkDll.EE_ExpressivAlgo_t action)
	{
		return EdkDll.Unmanged_EE_ExpressivSetTrainingAction(userId, action);
	}
	public static int EE_ExpressivSetTrainingControl(uint userId, EdkDll.EE_ExpressivTrainingControl_t control)
	{
		return EdkDll.Unmanged_EE_ExpressivSetTrainingControl(userId, control);
	}
	public static int EE_ExpressivGetTrainingAction(uint userId, out EdkDll.EE_ExpressivAlgo_t pActionOut)
	{
		return EdkDll.Unmanged_EE_ExpressivGetTrainingAction(userId, out pActionOut);
	}
	public static int EE_ExpressivGetTrainingTime(uint userId, out uint pTrainingTimeOut)
	{
		return EdkDll.Unmanged_EE_ExpressivGetTrainingTime(userId, out pTrainingTimeOut);
	}
	public static int EE_ExpressivGetTrainedSignatureActions(uint userId, out uint pTrainedActionsOut)
	{
		return EdkDll.Unmanged_EE_ExpressivGetTrainedSignatureActions(userId, out pTrainedActionsOut);
	}
	public static int EE_ExpressivGetTrainedSignatureAvailable(uint userId, out int pfAvailableOut)
	{
		return EdkDll.Unmanged_EE_ExpressivGetTrainedSignatureAvailable(userId, out pfAvailableOut);
	}
	public static int EE_ExpressivSetSignatureType(uint userId, EdkDll.EE_ExpressivSignature_t sigType)
	{
		return EdkDll.Unmanged_EE_ExpressivSetSignatureType(userId, sigType);
	}
	public static int EE_ExpressivGetSignatureType(uint userId, out EdkDll.EE_ExpressivSignature_t pSigTypeOut)
	{
		return EdkDll.Unmanged_EE_ExpressivGetSignatureType(userId, out pSigTypeOut);
	}
	public static int EE_CognitivSetActiveActions(uint userId, uint activeActions)
	{
		return EdkDll.Unmanged_EE_CognitivSetActiveActions(userId, activeActions);
	}
	public static int EE_CognitivGetActiveActions(uint userId, out uint pActiveActionsOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetActiveActions(userId, out pActiveActionsOut);
	}
	public static int EE_CognitivGetTrainingTime(uint userId, out uint pTrainingTimeOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetTrainingTime(userId, out pTrainingTimeOut);
	}
	public static int EE_CognitivSetTrainingControl(uint userId, EdkDll.EE_CognitivTrainingControl_t control)
	{
		return EdkDll.Unmanged_EE_CognitivSetTrainingControl(userId, control);
	}
	public static int EE_CognitivSetTrainingAction(uint userId, EdkDll.EE_CognitivAction_t action)
	{
		return EdkDll.Unmanged_EE_CognitivSetTrainingAction(userId, action);
	}
	public static int EE_CognitivGetTrainingAction(uint userId, out EdkDll.EE_CognitivAction_t pActionOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetTrainingAction(userId, out pActionOut);
	}
	public static int EE_CognitivGetTrainedSignatureActions(uint userId, out uint pTrainedActionsOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetTrainedSignatureActions(userId, out pTrainedActionsOut);
	}
	public static int EE_CognitivGetOverallSkillRating(uint userId, out float pOverallSkillRatingOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetOverallSkillRating(userId, out pOverallSkillRatingOut);
	}
	public static int EE_CognitivGetActionSkillRating(uint userId, EdkDll.EE_CognitivAction_t action, out float pActionSkillRatingOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetActionSkillRating(userId, action, out pActionSkillRatingOut);
	}
	public static int EE_CognitivSetActivationLevel(uint userId, int level)
	{
		return EdkDll.Unmanged_EE_CognitivSetActivationLevel(userId, level);
	}
	public static int EE_CognitivSetActionSensitivity(uint userId, int action1Sensitivity, int action2Sensitivity, int action3Sensitivity, int action4Sensitivity)
	{
		return EdkDll.Unmanged_EE_CognitivSetActionSensitivity(userId, action1Sensitivity, action2Sensitivity, action3Sensitivity, action4Sensitivity);
	}
	public static int EE_CognitivGetActivationLevel(uint userId, out int pLevelOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetActivationLevel(userId, out pLevelOut);
	}
	public static int EE_CognitivGetActionSensitivity(uint userId, out int pAction1SensitivityOut, out int pAction2SensitivityOut, out int pAction3SensitivityOut, out int pAction4SensitivityOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetActionSensitivity(userId, out pAction1SensitivityOut, out pAction2SensitivityOut, out pAction3SensitivityOut, out pAction4SensitivityOut);
	}
	public static int EE_CognitivStartSamplingNeutral(uint userId)
	{
		return EdkDll.Unmanged_EE_CognitivStartSamplingNeutral(userId);
	}
	public static int EE_CognitivStopSamplingNeutral(uint userId)
	{
		return EdkDll.Unmanged_EE_CognitivStopSamplingNeutral(userId);
	}
	public static int EE_CognitivSetSignatureCaching(uint userId, uint enabled)
	{
		return EdkDll.Unmanged_EE_CognitivSetSignatureCaching(userId, enabled);
	}
	public static int EE_CognitivGetSignatureCaching(uint userId, out uint pEnabledOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetSignatureCaching(userId, out pEnabledOut);
	}
	public static int EE_CognitivSetSignatureCacheSize(uint userId, uint size)
	{
		return EdkDll.Unmanged_EE_CognitivSetSignatureCacheSize(userId, size);
	}
	public static int EE_CognitivGetSignatureCacheSize(uint userId, out uint pSizeOut)
	{
		return EdkDll.Unmanged_EE_CognitivGetSignatureCacheSize(userId, out pSizeOut);
	}
	public static int EE_HeadsetGetSensorDetails(EdkDll.EE_InputChannels_t channelId, out EdkDll.InputSensorDescriptor_t pDescriptorOut)
	{
		return EdkDll.Unmanged_EE_HeadsetGetSensorDetails(channelId, out pDescriptorOut);
	}
	public static int EE_HardwareGetVersion(uint userId, out uint pHwVersionOut)
	{
		return EdkDll.Unmanged_EE_HardwareGetVersion(userId, out pHwVersionOut);
	}
	public static int EE_SoftwareGetVersion(StringBuilder pszVersionOut, uint nVersionChars, out uint pBuildNumOut)
	{
		return EdkDll.Unmanged_EE_SoftwareGetVersion(pszVersionOut, nVersionChars, out pBuildNumOut);
	}
	public static int EE_HeadsetGetGyroDelta(uint userId, out int pXOut, out int pYOut)
	{
		return EdkDll.Unmanged_EE_HeadsetGetGyroDelta(userId, out pXOut, out pYOut);
	}
	public static int EE_HeadsetGyroRezero(uint userId)
	{
		return EdkDll.Unmanged_EE_HeadsetGyroRezero(userId);
	}
	public static IntPtr EE_OptimizationParamCreate()
	{
		return EdkDll.Unmanged_EE_OptimizationParamCreate();
	}
	public static void EE_OptimizationParamFree(IntPtr hParam)
	{
		EdkDll.Unmanged_EE_OptimizationParamFree(hParam);
	}
	public static int EE_OptimizationEnable(IntPtr hParam)
	{
		return EdkDll.Unmanged_EE_OptimizationEnable(hParam);
	}
	public static int EE_OptimizationIsEnabled(out bool pEnabledOut)
	{
		return EdkDll.Unmanged_EE_OptimizationIsEnabled(out pEnabledOut);
	}
	public static int EE_OptimizationDisable()
	{
		return EdkDll.Unmanged_EE_OptimizationDisable();
	}
	public static int EE_OptimizationGetParam(IntPtr hParam)
	{
		return EdkDll.Unmanged_EE_OptimizationGetParam(hParam);
	}
	public static int EE_OptimizationGetVitalAlgorithm(IntPtr hParam, EdkDll.EE_EmotivSuite_t suite, out uint pVitalAlgorithmBitVectorOut)
	{
		return EdkDll.Unmanged_EE_OptimizationGetVitalAlgorithm(hParam, suite, out pVitalAlgorithmBitVectorOut);
	}
	public static int EE_OptimizationSetVitalAlgorithm(IntPtr hParam, EdkDll.EE_EmotivSuite_t suite, uint vitalAlgorithmBitVector)
	{
		return EdkDll.Unmanged_EE_OptimizationSetVitalAlgorithm(hParam, suite, vitalAlgorithmBitVector);
	}
	public static int EE_ResetDetection(uint userId, EdkDll.EE_EmotivSuite_t suite, uint detectionBitVector)
	{
		return EdkDll.Unmanged_EE_ResetDetection(userId, suite, detectionBitVector);
	}
	public static IntPtr ES_Create()
	{
		return EdkDll.Unmanaged_ES_Create();
	}
	public static void ES_Free(IntPtr state)
	{
		EdkDll.Unmanaged_ES_Free(state);
	}
	public static void ES_Init(IntPtr state)
	{
		EdkDll.Unmanaged_ES_Init(state);
	}
	public static float ES_GetTimeFromStart(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_GetTimeFromStart(state);
	}
	public static int ES_GetHeadsetOn(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_GetHeadsetOn(state);
	}
	public static int ES_GetNumContactQualityChannels(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_GetNumContactQualityChannels(state);
	}
	public static EdkDll.EE_EEG_ContactQuality_t ES_GetContactQuality(IntPtr state, int electroIdx)
	{
		return EdkDll.Unmanaged_ES_GetContactQuality(state, electroIdx);
	}
	public static int ES_GetContactQualityFromAllChannels(IntPtr state, out EdkDll.EE_EEG_ContactQuality_t[] contactQuality)
	{
		int num = EdkDll.ES_GetNumContactQualityChannels(state);
		contactQuality = new EdkDll.EE_EEG_ContactQuality_t[num];
		return EdkDll.Unmanaged_ES_GetContactQualityFromAllChannels(state, contactQuality, (uint)contactQuality.Length);
	}
	public static bool ES_ExpressivIsBlink(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsBlink(state);
	}
	public static bool ES_ExpressivIsLeftWink(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsLeftWink(state);
	}
	public static bool ES_ExpressivIsRightWink(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsRightWink(state);
	}
	public static bool ES_ExpressivIsEyesOpen(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsEyesOpen(state);
	}
	public static bool ES_ExpressivIsLookingUp(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsLookingUp(state);
	}
	public static bool ES_ExpressivIsLookingDown(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsLookingDown(state);
	}
	public static bool ES_ExpressivIsLookingLeft(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsLookingLeft(state);
	}
	public static bool ES_ExpressivIsLookingRight(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsLookingRight(state);
	}
	public static void ES_ExpressivGetEyelidState(IntPtr state, out float leftEye, out float rightEye)
	{
		EdkDll.Unmanaged_ES_ExpressivGetEyelidState(state, out leftEye, out rightEye);
	}
	public static void ES_ExpressivGetEyeLocation(IntPtr state, out float x, out float y)
	{
		EdkDll.Unmanaged_ES_ExpressivGetEyeLocation(state, out x, out y);
	}
	public static float ES_ExpressivGetEyebrowExtent(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivGetEyebrowExtent(state);
	}
	public static float ES_ExpressivGetSmileExtent(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivGetSmileExtent(state);
	}
	public static float ES_ExpressivGetClenchExtent(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivGetClenchExtent(state);
	}
	public static EdkDll.EE_ExpressivAlgo_t ES_ExpressivGetUpperFaceAction(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivGetUpperFaceAction(state);
	}
	public static float ES_ExpressivGetUpperFaceActionPower(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivGetUpperFaceActionPower(state);
	}
	public static EdkDll.EE_ExpressivAlgo_t ES_ExpressivGetLowerFaceAction(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivGetLowerFaceAction(state);
	}
	public static float ES_ExpressivGetLowerFaceActionPower(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_ExpressivGetLowerFaceActionPower(state);
	}
	public static bool ES_ExpressivIsActive(IntPtr state, EdkDll.EE_ExpressivAlgo_t type)
	{
		return EdkDll.Unmanaged_ES_ExpressivIsActive(state, type);
	}
	public static float ES_AffectivGetExcitementLongTermScore(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_AffectivGetExcitementLongTermScore(state);
	}
	public static float ES_AffectivGetExcitementShortTermScore(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_AffectivGetExcitementShortTermScore(state);
	}
	public static bool ES_AffectivIsActive(IntPtr state, EdkDll.EE_AffectivAlgo_t type)
	{
		return EdkDll.Unmanaged_ES_AffectivIsActive(state, type);
	}
	public static float ES_AffectivGetMeditationScore(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_AffectivGetMeditationScore(state);
	}
	public static float ES_AffectivGetFrustrationScore(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_AffectivGetFrustrationScore(state);
	}
	public static float ES_AffectivGetEngagementBoredomScore(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_AffectivGetEngagementBoredomScore(state);
	}
	public static EdkDll.EE_CognitivAction_t ES_CognitivGetCurrentAction(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_CognitivGetCurrentAction(state);
	}
	public static float ES_CognitivGetCurrentActionPower(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_CognitivGetCurrentActionPower(state);
	}
	public static bool ES_CognitivIsActive(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_CognitivIsActive(state);
	}
	public static float ES_CognitivGetCurrentLevelRating(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_CognitivGetCurrentLevelRating(state);
	}
	public static EdkDll.EE_SignalStrength_t ES_GetWirelessSignalStatus(IntPtr state)
	{
		return EdkDll.Unmanaged_ES_GetWirelessSignalStatus(state);
	}
	public static void ES_Copy(IntPtr a, IntPtr b)
	{
		EdkDll.Unmanaged_ES_Copy(a, b);
	}
	public static bool ES_AffectivEqual(IntPtr a, IntPtr b)
	{
		return EdkDll.Unmanaged_ES_AffectivEqual(a, b);
	}
	public static bool ES_ExpressivEqual(IntPtr a, IntPtr b)
	{
		return EdkDll.Unmanaged_ES_ExpressivEqual(a, b);
	}
	public static bool ES_CognitivEqual(IntPtr a, IntPtr b)
	{
		return EdkDll.Unmanaged_ES_CognitivEqual(a, b);
	}
	public static bool ES_EmoEngineEqual(IntPtr a, IntPtr b)
	{
		return EdkDll.Unmanaged_ES_EmoEngineEqual(a, b);
	}
	public static bool ES_Equal(IntPtr a, IntPtr b)
	{
		return EdkDll.Unmanaged_ES_Equal(a, b);
	}
	public static void ES_GetBatteryChargeLevel(IntPtr state, out int chargeLevel, out int maxChargeLevel)
	{
		EdkDll.Unmanaged_ES_GetBatteryChargeLevel(state, out chargeLevel, out maxChargeLevel);
	}
}
