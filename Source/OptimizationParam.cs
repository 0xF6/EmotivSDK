using System;
public class OptimizationParam
{
	private IntPtr hOptimizationParam;
	public OptimizationParam()
	{
		this.hOptimizationParam = EdkDll.EE_OptimizationParamCreate();
	}
	~OptimizationParam()
	{
		EdkDll.EE_OptimizationParamFree(this.hOptimizationParam);
	}
	public uint GetVitalAlgorithm(EdkDll.EE_EmotivSuite_t suite)
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_OptimizationGetVitalAlgorithm(this.hOptimizationParam, suite, out result));
		return result;
	}
	public void SetVitalAlgorithm(EdkDll.EE_EmotivSuite_t suite, uint vitalAlgorithmBitVector)
	{
		EmoEngine.errorHandler(EdkDll.EE_OptimizationSetVitalAlgorithm(this.hOptimizationParam, suite, vitalAlgorithmBitVector));
	}
	public IntPtr GetHandle()
	{
		return this.hOptimizationParam;
	}
}
