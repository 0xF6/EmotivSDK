using System;
public class EmoEngineEventArgs : EventArgs
{
	public uint userId;
	public EmoEngineEventArgs(uint userId)
	{
		this.userId = userId;
	}
}
