using System;
using UnityEngine;
public class EmoUserManagement : MonoBehaviour
{
	private EmoEngine engine = EmoEngine.Instance;
	public static int numUser;
	public static int currentUser;
	public int NumberOfUser;
	public int IndexOfCurrentUser;
	public static bool IsStarted;
	private void Start()
	{
		if (!EmoUserManagement.IsStarted)
		{
			this.engine.UserAdded += new EmoEngine.UserAddedEventHandler(EmoUserManagement.engine_UserAdded);
			this.engine.UserRemoved += new EmoEngine.UserRemovedEventHandler(EmoUserManagement.engine_UserRemoved);
			EmoUserManagement.IsStarted = true;
		}
	}
	private void Update()
	{
		this.NumberOfUser = EmoUserManagement.numUser;
		this.IndexOfCurrentUser = EmoUserManagement.currentUser;
	}
	private static void engine_UserAdded(object sender, EmoEngineEventArgs e)
	{
		EmoUserManagement.numUser++;
		EmoUserManagement.currentUser = EmoUserManagement.numUser - 1;
	}
	private static void engine_UserRemoved(object sender, EmoEngineEventArgs e)
	{
		EmoUserManagement.numUser--;
		EmoUserManagement.currentUser = EmoUserManagement.numUser - 1;
	}
}
