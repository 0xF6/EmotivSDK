using System;
public class EmoStateUpdatedEventArgs : EmoEngineEventArgs
{
	public EmoState emoState;
	public EmoStateUpdatedEventArgs(uint userId, EmoState emoState) : base(userId)
	{
		this.emoState = emoState;
	}
}
