using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
public class EmoEngine
{
	public delegate void EmoEngineConnectedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void EmoEngineDisconnectedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void UserAddedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void UserRemovedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void ProfileEventEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivTrainingStartedEventEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivTrainingSucceededEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivTrainingFailedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivTrainingCompletedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivTrainingDataErasedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivTrainingRejectedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivTrainingResetEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivAutoSamplingNeutralCompletedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void CognitivSignatureUpdatedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void ExpressivTrainingStartedEventEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void ExpressivTrainingSucceededEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void ExpressivTrainingFailedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void ExpressivTrainingCompletedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void ExpressivTrainingDataErasedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void ExpressivTrainingRejectedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void ExpressivTrainingResetEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void InternalStateChangedEventHandler(object sender, EmoEngineEventArgs e);
	public delegate void EmoStateUpdatedEventHandler(object sender, EmoStateUpdatedEventArgs e);
	public delegate void EmoEngineEmoStateUpdatedEventHandler(object sender, EmoStateUpdatedEventArgs e);
	public delegate void AffectivEmoStateUpdatedEventHandler(object sender, EmoStateUpdatedEventArgs e);
	public delegate void ExpressivEmoStateUpdatedEventHandler(object sender, EmoStateUpdatedEventArgs e);
	public delegate void CognitivEmoStateUpdatedEventHandler(object sender, EmoStateUpdatedEventArgs e);
	private static EmoEngine instance;
	private Dictionary<uint, EmoState> lastEmoState = new Dictionary<uint, EmoState>();
	private IntPtr hEvent;
	private IntPtr hData;
	public event EmoEngine.EmoEngineConnectedEventHandler EmoEngineConnected
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.EmoEngineConnected = (EmoEngine.EmoEngineConnectedEventHandler)Delegate.Combine(this.EmoEngineConnected, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.EmoEngineConnected = (EmoEngine.EmoEngineConnectedEventHandler)Delegate.Remove(this.EmoEngineConnected, value);
		}
	}
	public event EmoEngine.EmoEngineDisconnectedEventHandler EmoEngineDisconnected
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.EmoEngineDisconnected = (EmoEngine.EmoEngineDisconnectedEventHandler)Delegate.Combine(this.EmoEngineDisconnected, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.EmoEngineDisconnected = (EmoEngine.EmoEngineDisconnectedEventHandler)Delegate.Remove(this.EmoEngineDisconnected, value);
		}
	}
	public event EmoEngine.UserAddedEventHandler UserAdded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.UserAdded = (EmoEngine.UserAddedEventHandler)Delegate.Combine(this.UserAdded, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.UserAdded = (EmoEngine.UserAddedEventHandler)Delegate.Remove(this.UserAdded, value);
		}
	}
	public event EmoEngine.UserRemovedEventHandler UserRemoved
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.UserRemoved = (EmoEngine.UserRemovedEventHandler)Delegate.Combine(this.UserRemoved, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.UserRemoved = (EmoEngine.UserRemovedEventHandler)Delegate.Remove(this.UserRemoved, value);
		}
	}
	public event EmoEngine.CognitivTrainingStartedEventEventHandler CognitivTrainingStarted
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivTrainingStarted = (EmoEngine.CognitivTrainingStartedEventEventHandler)Delegate.Combine(this.CognitivTrainingStarted, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivTrainingStarted = (EmoEngine.CognitivTrainingStartedEventEventHandler)Delegate.Remove(this.CognitivTrainingStarted, value);
		}
	}
	public event EmoEngine.CognitivTrainingSucceededEventHandler CognitivTrainingSucceeded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivTrainingSucceeded = (EmoEngine.CognitivTrainingSucceededEventHandler)Delegate.Combine(this.CognitivTrainingSucceeded, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivTrainingSucceeded = (EmoEngine.CognitivTrainingSucceededEventHandler)Delegate.Remove(this.CognitivTrainingSucceeded, value);
		}
	}
	public event EmoEngine.CognitivTrainingFailedEventHandler CognitivTrainingFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivTrainingFailed = (EmoEngine.CognitivTrainingFailedEventHandler)Delegate.Combine(this.CognitivTrainingFailed, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivTrainingFailed = (EmoEngine.CognitivTrainingFailedEventHandler)Delegate.Remove(this.CognitivTrainingFailed, value);
		}
	}
	public event EmoEngine.CognitivTrainingCompletedEventHandler CognitivTrainingCompleted
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivTrainingCompleted = (EmoEngine.CognitivTrainingCompletedEventHandler)Delegate.Combine(this.CognitivTrainingCompleted, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivTrainingCompleted = (EmoEngine.CognitivTrainingCompletedEventHandler)Delegate.Remove(this.CognitivTrainingCompleted, value);
		}
	}
	public event EmoEngine.CognitivTrainingDataErasedEventHandler CognitivTrainingDataErased
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivTrainingDataErased = (EmoEngine.CognitivTrainingDataErasedEventHandler)Delegate.Combine(this.CognitivTrainingDataErased, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivTrainingDataErased = (EmoEngine.CognitivTrainingDataErasedEventHandler)Delegate.Remove(this.CognitivTrainingDataErased, value);
		}
	}
	public event EmoEngine.CognitivTrainingRejectedEventHandler CognitivTrainingRejected
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivTrainingRejected = (EmoEngine.CognitivTrainingRejectedEventHandler)Delegate.Combine(this.CognitivTrainingRejected, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivTrainingRejected = (EmoEngine.CognitivTrainingRejectedEventHandler)Delegate.Remove(this.CognitivTrainingRejected, value);
		}
	}
	public event EmoEngine.CognitivTrainingResetEventHandler CognitivTrainingReset
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivTrainingReset = (EmoEngine.CognitivTrainingResetEventHandler)Delegate.Combine(this.CognitivTrainingReset, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivTrainingReset = (EmoEngine.CognitivTrainingResetEventHandler)Delegate.Remove(this.CognitivTrainingReset, value);
		}
	}
	public event EmoEngine.CognitivAutoSamplingNeutralCompletedEventHandler CognitivAutoSamplingNeutralCompleted
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivAutoSamplingNeutralCompleted = (EmoEngine.CognitivAutoSamplingNeutralCompletedEventHandler)Delegate.Combine(this.CognitivAutoSamplingNeutralCompleted, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivAutoSamplingNeutralCompleted = (EmoEngine.CognitivAutoSamplingNeutralCompletedEventHandler)Delegate.Remove(this.CognitivAutoSamplingNeutralCompleted, value);
		}
	}
	public event EmoEngine.CognitivSignatureUpdatedEventHandler CognitivSignatureUpdated
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivSignatureUpdated = (EmoEngine.CognitivSignatureUpdatedEventHandler)Delegate.Combine(this.CognitivSignatureUpdated, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivSignatureUpdated = (EmoEngine.CognitivSignatureUpdatedEventHandler)Delegate.Remove(this.CognitivSignatureUpdated, value);
		}
	}
	public event EmoEngine.ExpressivTrainingStartedEventEventHandler ExpressivTrainingStarted
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.ExpressivTrainingStarted = (EmoEngine.ExpressivTrainingStartedEventEventHandler)Delegate.Combine(this.ExpressivTrainingStarted, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.ExpressivTrainingStarted = (EmoEngine.ExpressivTrainingStartedEventEventHandler)Delegate.Remove(this.ExpressivTrainingStarted, value);
		}
	}
	public event EmoEngine.ExpressivTrainingSucceededEventHandler ExpressivTrainingSucceeded
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.ExpressivTrainingSucceeded = (EmoEngine.ExpressivTrainingSucceededEventHandler)Delegate.Combine(this.ExpressivTrainingSucceeded, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.ExpressivTrainingSucceeded = (EmoEngine.ExpressivTrainingSucceededEventHandler)Delegate.Remove(this.ExpressivTrainingSucceeded, value);
		}
	}
	public event EmoEngine.ExpressivTrainingFailedEventHandler ExpressivTrainingFailed
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.ExpressivTrainingFailed = (EmoEngine.ExpressivTrainingFailedEventHandler)Delegate.Combine(this.ExpressivTrainingFailed, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.ExpressivTrainingFailed = (EmoEngine.ExpressivTrainingFailedEventHandler)Delegate.Remove(this.ExpressivTrainingFailed, value);
		}
	}
	public event EmoEngine.ExpressivTrainingCompletedEventHandler ExpressivTrainingCompleted
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.ExpressivTrainingCompleted = (EmoEngine.ExpressivTrainingCompletedEventHandler)Delegate.Combine(this.ExpressivTrainingCompleted, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.ExpressivTrainingCompleted = (EmoEngine.ExpressivTrainingCompletedEventHandler)Delegate.Remove(this.ExpressivTrainingCompleted, value);
		}
	}
	public event EmoEngine.ExpressivTrainingDataErasedEventHandler ExpressivTrainingDataErased
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.ExpressivTrainingDataErased = (EmoEngine.ExpressivTrainingDataErasedEventHandler)Delegate.Combine(this.ExpressivTrainingDataErased, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.ExpressivTrainingDataErased = (EmoEngine.ExpressivTrainingDataErasedEventHandler)Delegate.Remove(this.ExpressivTrainingDataErased, value);
		}
	}
	public event EmoEngine.ExpressivTrainingRejectedEventHandler ExpressivTrainingRejected
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.ExpressivTrainingRejected = (EmoEngine.ExpressivTrainingRejectedEventHandler)Delegate.Combine(this.ExpressivTrainingRejected, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.ExpressivTrainingRejected = (EmoEngine.ExpressivTrainingRejectedEventHandler)Delegate.Remove(this.ExpressivTrainingRejected, value);
		}
	}
	public event EmoEngine.ExpressivTrainingResetEventHandler ExpressivTrainingReset
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.ExpressivTrainingReset = (EmoEngine.ExpressivTrainingResetEventHandler)Delegate.Combine(this.ExpressivTrainingReset, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.ExpressivTrainingReset = (EmoEngine.ExpressivTrainingResetEventHandler)Delegate.Remove(this.ExpressivTrainingReset, value);
		}
	}
	public event EmoEngine.InternalStateChangedEventHandler InternalStateChanged
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.InternalStateChanged = (EmoEngine.InternalStateChangedEventHandler)Delegate.Combine(this.InternalStateChanged, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.InternalStateChanged = (EmoEngine.InternalStateChangedEventHandler)Delegate.Remove(this.InternalStateChanged, value);
		}
	}
	public event EmoEngine.EmoStateUpdatedEventHandler EmoStateUpdated
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.EmoStateUpdated = (EmoEngine.EmoStateUpdatedEventHandler)Delegate.Combine(this.EmoStateUpdated, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.EmoStateUpdated = (EmoEngine.EmoStateUpdatedEventHandler)Delegate.Remove(this.EmoStateUpdated, value);
		}
	}
	public event EmoEngine.EmoEngineEmoStateUpdatedEventHandler EmoEngineEmoStateUpdated
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.EmoEngineEmoStateUpdated = (EmoEngine.EmoEngineEmoStateUpdatedEventHandler)Delegate.Combine(this.EmoEngineEmoStateUpdated, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.EmoEngineEmoStateUpdated = (EmoEngine.EmoEngineEmoStateUpdatedEventHandler)Delegate.Remove(this.EmoEngineEmoStateUpdated, value);
		}
	}
	public event EmoEngine.AffectivEmoStateUpdatedEventHandler AffectivEmoStateUpdated
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.AffectivEmoStateUpdated = (EmoEngine.AffectivEmoStateUpdatedEventHandler)Delegate.Combine(this.AffectivEmoStateUpdated, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.AffectivEmoStateUpdated = (EmoEngine.AffectivEmoStateUpdatedEventHandler)Delegate.Remove(this.AffectivEmoStateUpdated, value);
		}
	}
	public event EmoEngine.ExpressivEmoStateUpdatedEventHandler ExpressivEmoStateUpdated
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.ExpressivEmoStateUpdated = (EmoEngine.ExpressivEmoStateUpdatedEventHandler)Delegate.Combine(this.ExpressivEmoStateUpdated, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.ExpressivEmoStateUpdated = (EmoEngine.ExpressivEmoStateUpdatedEventHandler)Delegate.Remove(this.ExpressivEmoStateUpdated, value);
		}
	}
	public event EmoEngine.CognitivEmoStateUpdatedEventHandler CognitivEmoStateUpdated
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.CognitivEmoStateUpdated = (EmoEngine.CognitivEmoStateUpdatedEventHandler)Delegate.Combine(this.CognitivEmoStateUpdated, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.CognitivEmoStateUpdated = (EmoEngine.CognitivEmoStateUpdatedEventHandler)Delegate.Remove(this.CognitivEmoStateUpdated, value);
		}
	}
	public static EmoEngine Instance
	{
		get
		{
			if (EmoEngine.instance == null)
			{
				EmoEngine.instance = new EmoEngine();
			}
			return EmoEngine.instance;
		}
	}
	private EmoEngine()
	{
		this.hEvent = EdkDll.EE_EmoEngineEventCreate();
	}
	~EmoEngine()
	{
		if (this.hEvent != IntPtr.Zero)
		{
			EdkDll.EE_EmoEngineEventFree(this.hEvent);
		}
	}
	public void ProcessEvents()
	{
		this.ProcessEvents(0);
	}
	public void ProcessEvents(int maxTimeMilliseconds)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		while (EdkDll.EE_EngineGetNextEvent(this.hEvent) == 0)
		{
			if (maxTimeMilliseconds != 0 && stopwatch.ElapsedMilliseconds >= (long)maxTimeMilliseconds)
			{
				break;
			}
			uint num = 0u;
			EdkDll.EE_EmoEngineEventGetUserId(this.hEvent, out num);
			EmoEngineEventArgs e = new EmoEngineEventArgs(num);
			EdkDll.EE_Event_t eE_Event_t = EdkDll.EE_EmoEngineEventGetType(this.hEvent);
			EdkDll.EE_Event_t eE_Event_t2 = eE_Event_t;
			if (eE_Event_t2 != EdkDll.EE_Event_t.EE_UserAdded)
			{
				if (eE_Event_t2 != EdkDll.EE_Event_t.EE_UserRemoved)
				{
					if (eE_Event_t2 != EdkDll.EE_Event_t.EE_EmoStateUpdated)
					{
						if (eE_Event_t2 != EdkDll.EE_Event_t.EE_CognitivEvent)
						{
							if (eE_Event_t2 != EdkDll.EE_Event_t.EE_ExpressivEvent)
							{
								if (eE_Event_t2 == EdkDll.EE_Event_t.EE_InternalStateChanged)
								{
									this.OnInternalStateChanged(e);
								}
							}
							else
							{
								switch (EdkDll.EE_ExpressivEventGetType(this.hEvent))
								{
								case EdkDll.EE_ExpressivEvent_t.EE_ExpressivTrainingStarted:
									this.OnExpressivTrainingStarted(e);
									break;
								case EdkDll.EE_ExpressivEvent_t.EE_ExpressivTrainingSucceeded:
									this.OnExpressivTrainingSucceeded(e);
									break;
								case EdkDll.EE_ExpressivEvent_t.EE_ExpressivTrainingFailed:
									this.OnExpressivTrainingFailed(e);
									break;
								case EdkDll.EE_ExpressivEvent_t.EE_ExpressivTrainingCompleted:
									this.OnExpressivTrainingCompleted(e);
									break;
								case EdkDll.EE_ExpressivEvent_t.EE_ExpressivTrainingDataErased:
									this.OnExpressivTrainingDataErased(e);
									break;
								case EdkDll.EE_ExpressivEvent_t.EE_ExpressivTrainingRejected:
									this.OnExpressivTrainingRejected(e);
									break;
								case EdkDll.EE_ExpressivEvent_t.EE_ExpressivTrainingReset:
									this.OnExpressivTrainingReset(e);
									break;
								}
							}
						}
						else
						{
							switch (EdkDll.EE_CognitivEventGetType(this.hEvent))
							{
							case EdkDll.EE_CognitivEvent_t.EE_CognitivTrainingStarted:
								this.OnCognitivTrainingStarted(e);
								break;
							case EdkDll.EE_CognitivEvent_t.EE_CognitivTrainingSucceeded:
								this.OnCognitivTrainingSucceeded(e);
								break;
							case EdkDll.EE_CognitivEvent_t.EE_CognitivTrainingFailed:
								this.OnCognitivTrainingFailed(e);
								break;
							case EdkDll.EE_CognitivEvent_t.EE_CognitivTrainingCompleted:
								this.OnCognitivTrainingCompleted(e);
								break;
							case EdkDll.EE_CognitivEvent_t.EE_CognitivTrainingDataErased:
								this.OnCognitivTrainingDataErased(e);
								break;
							case EdkDll.EE_CognitivEvent_t.EE_CognitivTrainingRejected:
								this.OnCognitivTrainingRejected(e);
								break;
							case EdkDll.EE_CognitivEvent_t.EE_CognitivTrainingReset:
								this.OnCognitivTrainingReset(e);
								break;
							case EdkDll.EE_CognitivEvent_t.EE_CognitivAutoSamplingNeutralCompleted:
								this.OnCognitivAutoSamplingNeutralCompleted(e);
								break;
							case EdkDll.EE_CognitivEvent_t.EE_CognitivSignatureUpdated:
								this.OnCognitivSignatureUpdated(e);
								break;
							}
						}
					}
					else
					{
						EmoState emoState = new EmoState();
						EmoEngine.errorHandler(EdkDll.EE_EmoEngineEventGetEmoState(this.hEvent, emoState.GetHandle()));
						EmoStateUpdatedEventArgs e2 = new EmoStateUpdatedEventArgs(num, emoState);
						this.OnEmoStateUpdated(e2);
						if (!emoState.EmoEngineEqual(this.lastEmoState[num]))
						{
							e2 = new EmoStateUpdatedEventArgs(num, new EmoState(emoState));
							this.OnEmoEngineEmoStateUpdated(e2);
						}
						if (!emoState.AffectivEqual(this.lastEmoState[num]))
						{
							e2 = new EmoStateUpdatedEventArgs(num, new EmoState(emoState));
							this.OnAffectivEmoStateUpdated(e2);
						}
						if (!emoState.CognitivEqual(this.lastEmoState[num]))
						{
							e2 = new EmoStateUpdatedEventArgs(num, new EmoState(emoState));
							this.OnCognitivEmoStateUpdated(e2);
						}
						if (!emoState.ExpressivEqual(this.lastEmoState[num]))
						{
							e2 = new EmoStateUpdatedEventArgs(num, new EmoState(emoState));
							this.OnExpressivEmoStateUpdated(e2);
						}
						this.lastEmoState[num] = (EmoState)emoState.Clone();
					}
				}
				else
				{
					this.OnUserRemoved(e);
				}
			}
			else
			{
				this.OnUserAdded(e);
			}
		}
	}
	protected virtual void OnEmoEngineConnected(EmoEngineEventArgs e)
	{
		this.lastEmoState.Clear();
		if (this.EmoEngineConnected != null)
		{
			this.EmoEngineConnected(this, e);
		}
	}
	protected virtual void OnEmoEngineDisconnected(EmoEngineEventArgs e)
	{
		if (this.EmoEngineDisconnected != null)
		{
			this.EmoEngineDisconnected(this, e);
		}
	}
	protected virtual void OnUserAdded(EmoEngineEventArgs e)
	{
		this.lastEmoState.Add(e.userId, new EmoState());
		if (this.UserAdded != null)
		{
			this.UserAdded(this, e);
		}
	}
	protected virtual void OnUserRemoved(EmoEngineEventArgs e)
	{
		this.lastEmoState.Remove(e.userId);
		if (this.UserRemoved != null)
		{
			this.UserRemoved(this, e);
		}
	}
	protected virtual void OnCognitivTrainingStarted(EmoEngineEventArgs e)
	{
		if (this.CognitivTrainingStarted != null)
		{
			this.CognitivTrainingStarted(this, e);
		}
	}
	protected virtual void OnCognitivTrainingSucceeded(EmoEngineEventArgs e)
	{
		if (this.CognitivTrainingSucceeded != null)
		{
			this.CognitivTrainingSucceeded(this, e);
		}
	}
	protected virtual void OnCognitivTrainingFailed(EmoEngineEventArgs e)
	{
		if (this.CognitivTrainingFailed != null)
		{
			this.CognitivTrainingFailed(this, e);
		}
	}
	protected virtual void OnCognitivTrainingCompleted(EmoEngineEventArgs e)
	{
		if (this.CognitivTrainingCompleted != null)
		{
			this.CognitivTrainingCompleted(this, e);
		}
	}
	protected virtual void OnCognitivTrainingDataErased(EmoEngineEventArgs e)
	{
		if (this.CognitivTrainingDataErased != null)
		{
			this.CognitivTrainingDataErased(this, e);
		}
	}
	protected virtual void OnCognitivTrainingRejected(EmoEngineEventArgs e)
	{
		if (this.CognitivTrainingRejected != null)
		{
			this.CognitivTrainingRejected(this, e);
		}
	}
	protected virtual void OnCognitivTrainingReset(EmoEngineEventArgs e)
	{
		if (this.CognitivTrainingReset != null)
		{
			this.CognitivTrainingReset(this, e);
		}
	}
	protected virtual void OnCognitivAutoSamplingNeutralCompleted(EmoEngineEventArgs e)
	{
		if (this.CognitivAutoSamplingNeutralCompleted != null)
		{
			this.CognitivAutoSamplingNeutralCompleted(this, e);
		}
	}
	protected virtual void OnCognitivSignatureUpdated(EmoEngineEventArgs e)
	{
		if (this.CognitivSignatureUpdated != null)
		{
			this.CognitivSignatureUpdated(this, e);
		}
	}
	protected virtual void OnExpressivTrainingStarted(EmoEngineEventArgs e)
	{
		if (this.ExpressivTrainingStarted != null)
		{
			this.ExpressivTrainingStarted(this, e);
		}
	}
	protected virtual void OnExpressivTrainingSucceeded(EmoEngineEventArgs e)
	{
		if (this.ExpressivTrainingSucceeded != null)
		{
			this.ExpressivTrainingSucceeded(this, e);
		}
	}
	protected virtual void OnExpressivTrainingFailed(EmoEngineEventArgs e)
	{
		if (this.ExpressivTrainingFailed != null)
		{
			this.ExpressivTrainingFailed(this, e);
		}
	}
	protected virtual void OnExpressivTrainingCompleted(EmoEngineEventArgs e)
	{
		if (this.ExpressivTrainingCompleted != null)
		{
			this.ExpressivTrainingCompleted(this, e);
		}
	}
	protected virtual void OnExpressivTrainingDataErased(EmoEngineEventArgs e)
	{
		if (this.ExpressivTrainingDataErased != null)
		{
			this.ExpressivTrainingDataErased(this, e);
		}
	}
	protected virtual void OnExpressivTrainingRejected(EmoEngineEventArgs e)
	{
		if (this.ExpressivTrainingRejected != null)
		{
			this.ExpressivTrainingRejected(this, e);
		}
	}
	protected virtual void OnExpressivTrainingReset(EmoEngineEventArgs e)
	{
		if (this.ExpressivTrainingReset != null)
		{
			this.ExpressivTrainingReset(this, e);
		}
	}
	protected virtual void OnInternalStateChanged(EmoEngineEventArgs e)
	{
		if (this.InternalStateChanged != null)
		{
			this.InternalStateChanged(this, e);
		}
	}
	protected virtual void OnEmoStateUpdated(EmoStateUpdatedEventArgs e)
	{
		if (this.EmoStateUpdated != null)
		{
			this.EmoStateUpdated(this, e);
		}
	}
	protected virtual void OnEmoEngineEmoStateUpdated(EmoStateUpdatedEventArgs e)
	{
		if (this.EmoEngineEmoStateUpdated != null)
		{
			this.EmoEngineEmoStateUpdated(this, e);
		}
	}
	protected virtual void OnAffectivEmoStateUpdated(EmoStateUpdatedEventArgs e)
	{
		if (this.AffectivEmoStateUpdated != null)
		{
			this.AffectivEmoStateUpdated(this, e);
		}
	}
	protected virtual void OnExpressivEmoStateUpdated(EmoStateUpdatedEventArgs e)
	{
		if (this.ExpressivEmoStateUpdated != null)
		{
			this.ExpressivEmoStateUpdated(this, e);
		}
	}
	protected virtual void OnCognitivEmoStateUpdated(EmoStateUpdatedEventArgs e)
	{
		if (this.CognitivEmoStateUpdated != null)
		{
			this.CognitivEmoStateUpdated(this, e);
		}
	}
	public static void errorHandler(int errorCode)
	{
		if (errorCode == 0)
		{
			return;
		}
		string message = string.Empty;
		switch (errorCode)
		{
		case 768:
			message = "A supplied buffer is not large enough";
			break;
		case 769:
			message = "Parameter is out of range";
			break;
		case 770:
			message = "Parameter is invalid";
			break;
		case 771:
			message = "Parameter is locked";
			break;
		default:
			switch (errorCode)
			{
			case 1280:
				message = "EmoEngine has not been initialized";
				break;
			case 1281:
				message = "Connection with remote instance of EmoEngine has been lost";
				break;
			case 1282:
				message = "Unable to establish connection with remote instance of EmoEngine.";
				break;
			default:
				if (errorCode != 257)
				{
					if (errorCode != 258)
					{
						if (errorCode != 1)
						{
							if (errorCode != 512)
							{
								if (errorCode != 1024)
								{
									if (errorCode != 1536)
									{
										if (errorCode != 1792)
										{
											if (errorCode != 2048)
											{
												message = "Unknown error";
											}
											else
											{
												message = "The requested operation failed due to optimization settings.";
											}
										}
										else
										{
											message = "The gyro could not be calibrated.  The headset must remain still for at least 0.5 secs.";
										}
									}
									else
									{
										message = "There are no new EmoEngine events at this time.";
									}
								}
								else
								{
									message = "User ID supplied to the function is invalid";
								}
							}
							else
							{
								message = "EmoEngine is unable to acquire EEG input data";
							}
						}
						else
						{
							message = "Unknown error";
						}
					}
					else
					{
						message = "The base profile does not have a user ID";
					}
				}
				else
				{
					message = "Invalid profile archive";
				}
				break;
			}
			break;
		}
		throw new EmoEngineException(message)
		{
			ErrorCode = errorCode
		};
	}
	public void Connect()
	{
		EmoEngine.errorHandler(EdkDll.EE_EngineConnect("23091987"));
		this.OnEmoEngineConnected(new EmoEngineEventArgs(4294967295u));
	}
	public void RemoteConnect(string ip, ushort port)
	{
		EmoEngine.errorHandler(EdkDll.EE_EngineRemoteConnect(ip, port));
		this.OnEmoEngineConnected(new EmoEngineEventArgs(4294967295u));
	}
	public void Disconnect()
	{
		EmoEngine.errorHandler(EdkDll.EE_EngineDisconnect());
		this.OnEmoEngineDisconnected(new EmoEngineEventArgs(4294967295u));
	}
	public uint EngineGetNumUser()
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_EngineGetNumUser(out result));
		return result;
	}
	public void SetHardwarePlayerDisplay(uint userId, uint playerNum)
	{
		EmoEngine.errorHandler(EdkDll.EE_SetHardwarePlayerDisplay(userId, playerNum));
	}
	public void SetUserProfile(uint userId, Profile profile)
	{
		if (profile == null)
		{
			throw new NullReferenceException();
		}
		byte[] bytes = profile.GetBytes();
		EmoEngine.errorHandler(EdkDll.EE_SetUserProfile(userId, bytes, (uint)bytes.Length));
	}
	public void SetUserProfile(uint userId, byte[] profileBytes)
	{
		if (profileBytes == null)
		{
			throw new NullReferenceException();
		}
		EmoEngine.errorHandler(EdkDll.EE_SetUserProfile(userId, profileBytes, (uint)profileBytes.Length));
	}
	public Profile GetUserProfile(uint userId)
	{
		Profile profile = new Profile();
		EmoEngine.errorHandler(EdkDll.EE_GetUserProfile(userId, profile.GetHandle()));
		return profile;
	}
	public void LoadUserProfile(uint userID, string szInputFilename)
	{
		EmoEngine.errorHandler(EdkDll.EE_LoadUserProfile(userID, szInputFilename));
	}
	public void EE_SaveUserProfile(uint userID, string szOutputFilename)
	{
		EmoEngine.errorHandler(EdkDll.EE_SaveUserProfile(userID, szOutputFilename));
	}
	public void ExpressivSetThreshold(uint userId, EdkDll.EE_ExpressivAlgo_t algoName, EdkDll.EE_ExpressivThreshold_t thresholdName, int value)
	{
		EmoEngine.errorHandler(EdkDll.EE_ExpressivSetThreshold(userId, algoName, thresholdName, value));
	}
	public int ExpressivGetThreshold(uint userId, EdkDll.EE_ExpressivAlgo_t algoName, EdkDll.EE_ExpressivThreshold_t thresholdName)
	{
		int result = 0;
		EmoEngine.errorHandler(EdkDll.EE_ExpressivGetThreshold(userId, algoName, thresholdName, out result));
		return result;
	}
	public void ExpressivSetTrainingAction(uint userId, EdkDll.EE_ExpressivAlgo_t action)
	{
		EmoEngine.errorHandler(EdkDll.EE_ExpressivSetTrainingAction(userId, action));
	}
	public void ExpressivSetTrainingControl(uint userId, EdkDll.EE_ExpressivTrainingControl_t control)
	{
		EmoEngine.errorHandler(EdkDll.EE_ExpressivSetTrainingControl(userId, control));
	}
	public EdkDll.EE_ExpressivAlgo_t ExpressivGetTrainingAction(uint userId)
	{
		EdkDll.EE_ExpressivAlgo_t result;
		EmoEngine.errorHandler(EdkDll.EE_ExpressivGetTrainingAction(userId, out result));
		return result;
	}
	public uint ExpressivGetTrainingTime(uint userId)
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_ExpressivGetTrainingTime(userId, out result));
		return result;
	}
	public uint ExpressivGetTrainedSignatureActions(uint userId)
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_ExpressivGetTrainedSignatureActions(userId, out result));
		return result;
	}
	public int ExpressivGetTrainedSignatureAvailable(uint userId)
	{
		int result = 0;
		EmoEngine.errorHandler(EdkDll.EE_ExpressivGetTrainedSignatureAvailable(userId, out result));
		return result;
	}
	public void ExpressivSetSignatureType(uint userId, EdkDll.EE_ExpressivSignature_t sigType)
	{
		EmoEngine.errorHandler(EdkDll.EE_ExpressivSetSignatureType(userId, sigType));
	}
	public EdkDll.EE_ExpressivSignature_t ExpressivGetSignatureType(uint userId)
	{
		EdkDll.EE_ExpressivSignature_t result;
		EmoEngine.errorHandler(EdkDll.EE_ExpressivGetSignatureType(userId, out result));
		return result;
	}
	public void CognitivSetActiveActions(uint userId, uint activeActions)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivSetActiveActions(userId, activeActions));
	}
	public uint CognitivGetActiveActions(uint userId)
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetActiveActions(userId, out result));
		return result;
	}
	public uint CognitivGetTrainingTime(uint userId)
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetTrainingTime(userId, out result));
		return result;
	}
	public void CognitivSetTrainingControl(uint userId, EdkDll.EE_CognitivTrainingControl_t control)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivSetTrainingControl(userId, control));
	}
	public void CognitivSetTrainingAction(uint userId, EdkDll.EE_CognitivAction_t action)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivSetTrainingAction(userId, action));
	}
	public EdkDll.EE_CognitivAction_t CognitivGetTrainingAction(uint userId)
	{
		EdkDll.EE_CognitivAction_t result;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetTrainingAction(userId, out result));
		return result;
	}
	public uint CognitivGetTrainedSignatureActions(uint userId)
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetTrainedSignatureActions(userId, out result));
		return result;
	}
	public float CognitivGetOverallSkillRating(uint userId)
	{
		float result = 0f;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetOverallSkillRating(userId, out result));
		return result;
	}
	public float CognitivGetActionSkillRating(uint userId, EdkDll.EE_CognitivAction_t action)
	{
		float result = 0f;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetActionSkillRating(userId, action, out result));
		return result;
	}
	public void CognitivSetActivationLevel(uint userId, int level)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivSetActivationLevel(userId, level));
	}
	public void CognitivSetActionSensitivity(uint userId, int action1Sensitivity, int action2Sensitivity, int action3Sensitivity, int action4Sensitivity)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivSetActionSensitivity(userId, action1Sensitivity, action2Sensitivity, action3Sensitivity, action4Sensitivity));
	}
	public int CognitivGetActivationLevel(uint userId)
	{
		int result = 0;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetActivationLevel(userId, out result));
		return result;
	}
	public void CognitivGetActionSensitivity(uint userId, out int pAction1SensitivityOut, out int pAction2SensitivityOut, out int pAction3SensitivityOut, out int pAction4SensitivityOut)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetActionSensitivity(userId, out pAction1SensitivityOut, out pAction2SensitivityOut, out pAction3SensitivityOut, out pAction4SensitivityOut));
	}
	public void CognitivStartSamplingNeutral(uint userId)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivStartSamplingNeutral(userId));
	}
	public void CognitivStopSamplingNeutral(uint userId)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivStopSamplingNeutral(userId));
	}
	public void CognitivSetSignatureCaching(uint userId, uint enabled)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivSetSignatureCaching(userId, enabled));
	}
	public uint CognitivGetSignatureCaching(uint userId)
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetSignatureCaching(userId, out result));
		return result;
	}
	public void CognitivSetSignatureCacheSize(uint userId, uint size)
	{
		EmoEngine.errorHandler(EdkDll.EE_CognitivSetSignatureCacheSize(userId, size));
	}
	public uint CognitivGetSignatureCacheSize(uint userId)
	{
		uint result = 0u;
		EmoEngine.errorHandler(EdkDll.EE_CognitivGetSignatureCacheSize(userId, out result));
		return result;
	}
	public EdkDll.InputSensorDescriptor_t HeadsetGetSensorDetails(EdkDll.EE_InputChannels_t channelId)
	{
		EdkDll.InputSensorDescriptor_t result;
		EmoEngine.errorHandler(EdkDll.EE_HeadsetGetSensorDetails(channelId, out result));
		return result;
	}
	public uint HardwareGetVersion(uint userId)
	{
		uint result;
		EmoEngine.errorHandler(EdkDll.EE_HardwareGetVersion(userId, out result));
		return result;
	}
	public void SoftwareGetVersion(out string pszVersionOut, out uint pBuildNumOut)
	{
		StringBuilder stringBuilder = new StringBuilder(128);
		EmoEngine.errorHandler(EdkDll.EE_SoftwareGetVersion(stringBuilder, (uint)stringBuilder.Capacity, out pBuildNumOut));
		pszVersionOut = stringBuilder.ToString();
	}
	public void HeadsetGetGyroDelta(uint userId, out int pXOut, out int pYOut)
	{
		EmoEngine.errorHandler(EdkDll.EE_HeadsetGetGyroDelta(userId, out pXOut, out pYOut));
	}
	public void HeadsetGyroRezero(uint userId)
	{
		EmoEngine.errorHandler(EdkDll.EE_HeadsetGyroRezero(userId));
	}
	public void OptimizationEnable(OptimizationParam param)
	{
		if (param == null)
		{
			throw new NullReferenceException();
		}
		EmoEngine.errorHandler(EdkDll.EE_OptimizationEnable(param.GetHandle()));
	}
	public bool OptimizationIsEnabled()
	{
		bool result = false;
		EmoEngine.errorHandler(EdkDll.EE_OptimizationIsEnabled(out result));
		return result;
	}
	public void OptimizationDisable()
	{
		EmoEngine.errorHandler(EdkDll.EE_OptimizationDisable());
	}
	public OptimizationParam OptimizationGetParam()
	{
		OptimizationParam optimizationParam = new OptimizationParam();
		EmoEngine.errorHandler(EdkDll.EE_OptimizationGetParam(optimizationParam.GetHandle()));
		return optimizationParam;
	}
	public void ResetDetection(uint userId, EdkDll.EE_EmotivSuite_t suite, uint detectionBitVector)
	{
		EmoEngine.errorHandler(EdkDll.EE_ResetDetection(userId, suite, detectionBitVector));
	}
}
