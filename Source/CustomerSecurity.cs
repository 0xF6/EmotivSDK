using System;
using System.Runtime.InteropServices;
public class CustomerSecurity
{
	[DllImport("edk.dll", EntryPoint = "EE_GetSecurityCode")]
	private static extern double Unmanged_EE_GetSecurityCode();
	[DllImport("edk.dll", EntryPoint = "EE_CheckSecurityCode")]
	private static extern int Unmanged_EE_CheckSecurityCode(double x);
	public static double EE_GetSecurityCode()
	{
		return CustomerSecurity.Unmanged_EE_GetSecurityCode();
	}
	public static int EE_CheckSecurityCode(double x)
	{
		return CustomerSecurity.Unmanged_EE_CheckSecurityCode(x);
	}
	public static double emotiv_func(double x)
	{
		double num = 725.0;
		double num2 = 17.0;
		double num3 = 524288.0;
		return (num * x + num2) % num3;
	}
}
