using System;
using System.Collections;
using System.IO;
using UnityEngine;
public class EmoProfileManagement : MonoBehaviour
{
	private EmoEngine engine = EmoEngine.Instance;
	public static int currentIndex = 0;
	private static ArrayList userProfiles = new ArrayList();
	public int numOfProfile;
	public string currentDir;
	public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
	{
		try
		{
			FileStream fileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
			fileStream.Write(_ByteArray, 0, _ByteArray.Length);
			fileStream.Close();
			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine("Exception caught in process: {0}", ex.ToString());
		}
		return false;
	}
	public void SaveProfilesToFile()
	{
		Debug.Log("Save file");
		string currentDirectory = Directory.GetCurrentDirectory();
		if (!Directory.Exists(currentDirectory + "/EmotivUserProfile"))
		{
			Directory.CreateDirectory(currentDirectory + "/EmotivUserProfile");
		}
		Directory.SetCurrentDirectory(currentDirectory + "/EmotivUserProfile");
		for (int i = 0; i < EmoProfileManagement.userProfiles.Count; i++)
		{
			UserProfile userProfile = (UserProfile)EmoProfileManagement.userProfiles[i];
			this.ByteArrayToFile(userProfile.profileName + ".up", userProfile.profile.GetBytes());
		}
		Directory.SetCurrentDirectory(currentDirectory);
	}
	public static string[] GetProfileList()
	{
		string text = Directory.GetCurrentDirectory();
		if (!Directory.Exists(text + "/EmotivUserProfile"))
		{
			Directory.CreateDirectory(text + "/EmotivUserProfile");
		}
		text += "/EmotivUserProfile";
		string[] files = Directory.GetFiles(text, "*.up");
		for (int i = 0; i < files.Length; i++)
		{
			files[i] = files[i].Substring(0, files[i].Length - 3);
			files[i] = Path.GetFileName(files[i]);
		}
		return files;
	}
	public void LoadProfilesFromFile()
	{
		Debug.Log("Load file");
		string text = Directory.GetCurrentDirectory();
		if (!Directory.Exists(text + "/EmotivUserProfile"))
		{
			Directory.CreateDirectory(text + "/EmotivUserProfile");
		}
		text += "/EmotivUserProfile";
		string[] files = Directory.GetFiles(text, "*.up");
		for (int i = 0; i < files.Length; i++)
		{
			FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, (int)fileStream.Length);
			fileStream.Close();
			this.engine.SetUserProfile((uint)EmoUserManagement.currentUser, array);
			UserProfile userProfile = new UserProfile();
			userProfile.profileName = files[i].Substring(0, files[i].Length - 3);
			userProfile.profileName = Path.GetFileName(userProfile.profileName);
			userProfile.profile = this.engine.GetUserProfile((uint)EmoUserManagement.currentUser);
			EmoProfileManagement.userProfiles.Add(userProfile);
		}
	}
	public bool SetUserProfile(string prName)
	{
		int num = this.FindProfileName(prName);
		if (num != EmoProfileManagement.userProfiles.Count)
		{
			UserProfile userProfile = (UserProfile)EmoProfileManagement.userProfiles[num];
			this.engine.SetUserProfile((uint)EmoUserManagement.currentUser, userProfile.profile);
			EmoProfileManagement.currentIndex = num;
			Debug.Log(prName);
			return true;
		}
		Debug.Log("Set user profile failed");
		return false;
	}
	private int FindProfileName(string prName)
	{
		int num = 0;
		bool flag = false;
		while (!flag && num < EmoProfileManagement.userProfiles.Count)
		{
			UserProfile userProfile = (UserProfile)EmoProfileManagement.userProfiles[num];
			if (prName == userProfile.profileName)
			{
				flag = true;
			}
			else
			{
				num++;
			}
		}
		return num;
	}
	public bool AddNewProfile(string prName)
	{
		Debug.Log("add new profile");
		if (this.FindProfileName(prName) == EmoProfileManagement.userProfiles.Count)
		{
			if (EmoProfileManagement.userProfiles.Count > 0)
			{
				this.SaveCurrentProfile();
			}
			UserProfile userProfile = new UserProfile();
			userProfile.profileName = prName;
			EmoProfileManagement.currentIndex = 0;
			EmoProfileManagement.userProfiles.Insert(EmoProfileManagement.currentIndex, userProfile);
			this.engine.SetUserProfile((uint)EmoUserManagement.currentUser, userProfile.profile);
			this.SaveCurrentProfile();
			return true;
		}
		Debug.Log("Already have this profile name");
		return false;
	}
	public void SaveCurrentProfile()
	{
		UserProfile userProfile = (UserProfile)EmoProfileManagement.userProfiles[EmoProfileManagement.currentIndex];
		userProfile.profile = this.engine.GetUserProfile((uint)EmoUserManagement.currentUser);
		EmoProfileManagement.userProfiles.RemoveAt(EmoProfileManagement.currentIndex);
		EmoProfileManagement.userProfiles.Insert(EmoProfileManagement.currentIndex, userProfile);
	}
	public bool DeleteProfile(string prName)
	{
		int num = this.FindProfileName(prName);
		if (num != EmoProfileManagement.userProfiles.Count + 1)
		{
			EmoProfileManagement.userProfiles.RemoveAt(num);
			if (num == EmoProfileManagement.currentIndex && EmoProfileManagement.currentIndex > 0)
			{
				EmoProfileManagement.currentIndex--;
			}
			return true;
		}
		return false;
	}
	public static string GetProfileName(int profileIndex)
	{
		if (profileIndex < EmoProfileManagement.userProfiles.Count)
		{
			UserProfile userProfile = (UserProfile)EmoProfileManagement.userProfiles[profileIndex];
			return userProfile.profileName;
		}
		return null;
	}
	public static int GetProfilesArraySize()
	{
		return EmoProfileManagement.userProfiles.Count;
	}
	public static void ClearProfileList()
	{
		EmoProfileManagement.userProfiles.Clear();
		EmoProfileManagement.currentIndex = 0;
	}
	private void Start()
	{
	}
	private void Update()
	{
		this.numOfProfile = EmoProfileManagement.GetProfilesArraySize();
		this.currentDir = Directory.GetCurrentDirectory();
	}
	public static bool[] CheckCurrentProfile()
	{
		uint num;
		EdkDll.EE_CognitivGetActiveActions((uint)EmoUserManagement.currentUser, out num);
		string text = Convert.ToString((long)((ulong)num), 2);
		Debug.Log(text);
		bool[] array = new bool[EmoCognitiv.cognitivActionList.Length];
		for (int i = 0; i < EmoCognitiv.cognitivActionList.Length; i++)
		{
			array[i] = false;
		}
		for (int j = text.Length - 1; j >= 0; j--)
		{
			if (text[j] == '1')
			{
				Debug.Log(j);
				array[text.Length - j - 1] = true;
			}
		}
		return array;
	}
}
