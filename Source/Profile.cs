using System;
public class Profile
{
	private IntPtr hProfile;
	public Profile()
	{
		this.hProfile = EdkDll.EE_ProfileEventCreate();
		EdkDll.EE_GetBaseProfile(this.hProfile);
	}
	~Profile()
	{
		EdkDll.EE_EmoEngineEventFree(this.hProfile);
	}
	public byte[] GetBytes()
	{
		uint num = 0u;
		EmoEngine.errorHandler(EdkDll.EE_GetUserProfileSize(this.hProfile, out num));
		byte[] array = new byte[num];
		EmoEngine.errorHandler(EdkDll.EE_GetUserProfileBytes(this.hProfile, array, num));
		return array;
	}
	public IntPtr GetHandle()
	{
		return this.hProfile;
	}
}
