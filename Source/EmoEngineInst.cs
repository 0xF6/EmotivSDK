using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
public class EmoEngineInst : MonoBehaviour
{
	private EmoEngine engine = EmoEngine.Instance;
	private ConsoleKeyInfo cki = default(ConsoleKeyInfo);
	public static int[] Cq;
	public static int nChan;
	public static bool IsStarted;
	public static int numOfGoodContacts;
	public static EdkDll.EE_SignalStrength_t signalStrength;
	private void Start()
	{
		if (!EmoEngineInst.IsStarted)
		{
			EmoEngineInst.Cq = new int[18];
			this.engine.EmoEngineConnected += new EmoEngine.EmoEngineConnectedEventHandler(EmoEngineInst.engine_EmoEngineConnected);
			this.engine.EmoEngineDisconnected += new EmoEngine.EmoEngineDisconnectedEventHandler(EmoEngineInst.engine_EmoEngineDisconnected);
			this.engine.EmoEngineEmoStateUpdated += new EmoEngine.EmoEngineEmoStateUpdatedEventHandler(EmoEngineInst.engine_EmoEngineEmoStateUpdated);
			string hostNameOrAddress = "127.0.0.1";
			int port = 3008;
			IPAddress iPAddress = Dns.GetHostAddresses(hostNameOrAddress)[0];
			IPAddress address = IPAddress.Parse("127.0.0.1");
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPEndPoint remoteEP = new IPEndPoint(address, port);
			try
			{
				socket.Connect(remoteEP);
			}
			catch (SocketException var_6_9C)
			{
			}
			if (socket.Connected)
			{
				socket.Shutdown(SocketShutdown.Both);
				socket.Disconnect(true);
				this.engine.RemoteConnect("127.0.0.1", 3008);
			}
			else
			{
				this.engine.Connect();
			}
			EmoEngineInst.IsStarted = true;
		}
	}
	private void Stop()
	{
		this.engine.Disconnect();
	}
	private static void keyHandler(ConsoleKey key)
	{
	}
	private void Update()
	{
		try
		{
			this.engine.ProcessEvents(1000);
		}
		catch (EmoEngineException ex)
		{
			Console.WriteLine("{0}", ex.ToString());
		}
		catch (Exception ex2)
		{
			Console.WriteLine("{0}", ex2.ToString());
		}
	}
	private static void engine_EmoEngineEmoStateUpdated(object sender, EmoStateUpdatedEventArgs e)
	{
		EmoState emoState = e.emoState;
		int numContactQualityChannels = emoState.GetNumContactQualityChannels();
		EdkDll.EE_EEG_ContactQuality_t[] contactQualityFromAllChannels = emoState.GetContactQualityFromAllChannels();
		EmoEngineInst.nChan = numContactQualityChannels;
		EdkDll.EE_SignalStrength_t wirelessSignalStatus = emoState.GetWirelessSignalStatus();
		int num = 0;
		if (wirelessSignalStatus != EdkDll.EE_SignalStrength_t.NO_SIGNAL)
		{
			for (int i = 0; i < numContactQualityChannels; i++)
			{
				if (contactQualityFromAllChannels[i] != emoState.GetContactQuality(i))
				{
					throw new Exception();
				}
				switch (contactQualityFromAllChannels[i])
				{
				case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_NO_SIGNAL:
					EmoEngineInst.Cq[i] = 0;
					break;
				case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_VERY_BAD:
					EmoEngineInst.Cq[i] = 1;
					break;
				case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_POOR:
					EmoEngineInst.Cq[i] = 2;
					break;
				case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_FAIR:
					EmoEngineInst.Cq[i] = 3;
					break;
				case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_GOOD:
					num++;
					EmoEngineInst.Cq[i] = 4;
					break;
				}
			}
		}
		else
		{
			for (int j = 0; j < numContactQualityChannels; j++)
			{
				EmoEngineInst.Cq[j] = 0;
			}
		}
		EmoEngineInst.numOfGoodContacts = num;
		int num2 = 0;
		int num3 = 0;
		EmoEngineInst.signalStrength = emoState.GetWirelessSignalStatus();
		emoState.GetBatteryChargeLevel(out num2, out num3);
	}
	private static void engine_EmoEngineConnected(object sender, EmoEngineEventArgs e)
	{
	}
	private static void engine_EmoEngineDisconnected(object sender, EmoEngineEventArgs e)
	{
	}
}
