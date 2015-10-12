using System;
using System.Runtime.Serialization;
public class EmoEngineException : ApplicationException
{
	private int errorCode;
	public int ErrorCode
	{
		get
		{
			return this.errorCode;
		}
		set
		{
			this.errorCode = value;
		}
	}
	public EmoEngineException()
	{
	}
	public EmoEngineException(string message) : base(message)
	{
	}
	public EmoEngineException(string message, Exception inner) : base(message, inner)
	{
	}
	protected EmoEngineException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}
