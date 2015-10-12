using System;
using System.IO;
using UnityEngine;
public class MainMenu : MonoBehaviour
{
	public EmoBot emoBot;
	private EyeAction eyeAction;
	private LowerFaceAction lowerFaceAction;
	private float lowerFacePower;
	private UpperFaceAction upperFaceAction;
	private float upperFacePower;
	private float currenttimeleft;
	private float currenttimeright;
	private bool isnormal;
	private bool issmile;
	private bool isclench;
	private bool islaugh;
	private float r;
	private bool winkleft;
	private bool winkright;
	private bool check_control;
	private bool prevLookLeft;
	private bool prevlookright;
	public GUISkin MySkin;
	public GUISkin skin2;
	public GUISkin skin3;
	public GUISkin skin4;
	public GUISkin skin5;
	public GUISkin skin6;
	public GUISkin skin7;
	public GUISkin skin8;
	public float largeround = 8.75f;
	private Rect window = new Rect((float)(Screen.width / 2 - 300), (float)(Screen.height / 2 - 200), 600f, 400f);
	private bool check;
	public Texture atexture;
	public Texture headtexture;
	public Texture scroll;
	public Texture scroll2;
	public Texture control;
	public Texture round;
	public Texture smallround;
	public Texture controled;
	public bool check_button1 = true;
	public bool check_button2;
	private SaveProfile sp;
	public static MainMenu instance;
	public float int_scale = 0.7f;
	public Rect headArea;
	private Rect head;
	public static int[] node;
	public Texture2D headset;
	public Texture2D redButt;
	public Texture2D blackButt;
	public Texture2D orangeButt;
	public Texture2D yellowButt;
	public Texture2D greenButt;
	public bool isEnable = true;
	private Texture2D nodeStatus(int node)
	{
		Texture2D result;
		switch (node)
		{
		case 0:
			result = this.blackButt;
			break;
		case 1:
			result = this.redButt;
			break;
		case 2:
			result = this.orangeButt;
			break;
		case 3:
			result = this.yellowButt;
			break;
		case 4:
			result = this.greenButt;
			break;
		default:
			result = this.blackButt;
			break;
		}
		return result;
	}
	private void DisableInfo()
	{
		this.isEnable = false;
	}
	private void EnableInfo()
	{
		this.isEnable = true;
	}
	private void DrawGUI()
	{
		this.headArea.x = 25f;
		this.headArea.y = 100f;
		GUI.BeginGroup(this.headArea);
		GUI.DrawTexture(this.head, this.headset);
		GUI.DrawTexture(new Rect(47f * this.int_scale, 26f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[3]));
		GUI.DrawTexture(new Rect(130f * this.int_scale, 26f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[16]));
		GUI.DrawTexture(new Rect(67f * this.int_scale, 51f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[5]));
		GUI.DrawTexture(new Rect(110f * this.int_scale, 51f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[14]));
		GUI.DrawTexture(new Rect(18f * this.int_scale, 53f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[4]));
		GUI.DrawTexture(new Rect(159f * this.int_scale, 53f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[15]));
		GUI.DrawTexture(new Rect(37f * this.int_scale, 71f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[5]));
		GUI.DrawTexture(new Rect(141f * this.int_scale, 71f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[13]));
		GUI.DrawTexture(new Rect(8f * this.int_scale, 93f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[7]));
		GUI.DrawTexture(new Rect(169f * this.int_scale, 93f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[12]));
		GUI.DrawTexture(new Rect(18f * this.int_scale, 118f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[0]));
		GUI.DrawTexture(new Rect(159f * this.int_scale, 118f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[1]));
		GUI.DrawTexture(new Rect(37f * this.int_scale, 148f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[8]));
		GUI.DrawTexture(new Rect(140f * this.int_scale, 148f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[11]));
		GUI.DrawTexture(new Rect(64f * this.int_scale, 172f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[9]));
		GUI.DrawTexture(new Rect(113f * this.int_scale, 172f * this.int_scale, 23f * this.int_scale, 23f * this.int_scale), this.nodeStatus(MainMenu.node[10]));
		GUI.EndGroup();
	}
	private void Awake()
	{
		MainMenu.instance = this;
		Application.runInBackground = true;
	}
	private void Start()
	{
		MainMenu.node = new int[18];
		for (int i = 0; i < 18; i++)
		{
			MainMenu.node[i] = 0;
		}
		if (this.headArea == new Rect(0f, 0f, 0f, 0f))
		{
			this.headArea = new Rect(600f, 70f, 225f * this.int_scale, 200f * this.int_scale);
		}
		if (this.head == new Rect(0f, 0f, 0f, 0f))
		{
			this.head = new Rect(0f, 0f, 200f * this.int_scale, 200f * this.int_scale);
		}
		this.sp = new SaveProfile();
		try
		{
			EmotivProfile.read(out this.sp);
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_HORIEYE, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.look));
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_BLINK, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.blink));
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_WINK_LEFT, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.wink_l));
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_WINK_RIGHT, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.wink_r));
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_EYEBROW, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.brow));
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_CLENCH, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.teeth));
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_SMILE, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.smile));
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_SMIRK_RIGHT, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.smirk_r));
			EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_SMIRK_LEFT, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.smirk_l));
		}
		catch (Exception var_1_1F3)
		{
		}
	}
	private void Update()
	{
		for (int i = 0; i < EmoEngineInst.nChan; i++)
		{
			MainMenu.node[i] = EmoEngineInst.Cq[i];
		}
		this.CheckEye();
		this.CheckLowerFace();
		this.CheckUpperFace();
		if (EmoEngineInst.signalStrength == EdkDll.EE_SignalStrength_t.NO_SIGNAL)
		{
			this.emoBot.SetEyeState(EyeState.LookMiddle);
			this.emoBot.SetMouthState(MouthState.Normal);
		}
	}
	private void OnApplicationQuit()
	{
		EmotivProfile.save(this.sp);
	}
	public void CheckEye()
	{
		if (EmoExpressiv.isBlink)
		{
			this.emoBot.SetEyeState(EyeState.Blink);
			return;
		}
		if (EmoExpressiv.isLeftWink)
		{
			this.emoBot.SetEyeState(EyeState.WinkLeft);
			this.winkleft = true;
			this.currenttimeleft = Time.time;
			return;
		}
		if (EmoExpressiv.isRightWink)
		{
			this.emoBot.SetEyeState(EyeState.WinkRight);
			this.winkright = true;
			this.currenttimeright = Time.time;
			return;
		}
		if (EmoExpressiv.isLookingLeft)
		{
			this.emoBot.SetEyeState(EyeState.LookRight);
			return;
		}
		if (EmoExpressiv.isLookingRight)
		{
			this.emoBot.SetEyeState(EyeState.LookLeft);
			return;
		}
		this.emoBot.SetEyeState(EyeState.LookMiddle);
	}
	public void CheckLowerFace()
	{
		if (EmoExpressiv.lowerFaceAction == EdkDll.EE_ExpressivAlgo_t.EXP_SMILE && (double)EmoExpressiv.lowerFacePower > 0.0)
		{
			this.emoBot.SetMouthState(MouthState.Smile);
			return;
		}
		if (EmoExpressiv.lowerFaceAction == EdkDll.EE_ExpressivAlgo_t.EXP_CLENCH && (double)EmoExpressiv.lowerFacePower >= 0.1)
		{
			this.emoBot.SetMouthState(MouthState.Clench);
			return;
		}
		if (EmoExpressiv.lowerFaceAction == EdkDll.EE_ExpressivAlgo_t.EXP_SMIRK_LEFT && (double)EmoExpressiv.lowerFacePower > 0.1)
		{
			this.emoBot.SetMouthState(MouthState.SmirkLeft);
			return;
		}
		if (EmoExpressiv.lowerFaceAction == EdkDll.EE_ExpressivAlgo_t.EXP_SMIRK_RIGHT && (double)EmoExpressiv.lowerFacePower > 0.1)
		{
			this.emoBot.SetMouthState(MouthState.SmirkRight);
			return;
		}
		this.emoBot.SetMouthState(MouthState.Normal);
	}
	public void CheckUpperFace()
	{
		if (EmoExpressiv.eyebrowExtent >= 0.5f)
		{
			this.emoBot.SetBrowState(BrowState.Raise);
			return;
		}
	}
	private void OnGUI()
	{
		if (!this.check_control)
		{
			GUI.skin = this.skin2;
		}
		else
		{
			GUI.skin = this.skin3;
		}
		if (GUI.Button(new Rect((float)(Screen.width / 2 + 320), (float)(Screen.height / 2 - 280), 50f, 50f), string.Empty))
		{
			this.check = true;
			this.check_control = true;
		}
		GUI.skin = this.MySkin;
		if (this.check)
		{
			this.window = GUI.Window(0, this.window, new GUI.WindowFunction(this.myfunc), string.Empty);
		}
		if (this.winkleft && Time.time - this.currenttimeleft > 0.3f)
		{
			this.winkleft = false;
			this.currenttimeleft = Time.time;
			this.emoBot.SetEyeState(EyeState.NormalLeft);
		}
		if (this.winkright && Time.time - this.currenttimeright > 0.3f)
		{
			this.winkright = false;
			this.currenttimeright = Time.time;
			this.emoBot.SetEyeState(EyeState.NormalRight);
		}
	}
	private void myfunc(int i)
	{
		if (this.check_button1)
		{
			if (this.isEnable)
			{
				this.DrawGUI();
			}
			GUI.skin = this.MySkin;
			GUI.Label(new Rect(250f, 90f, 150f, 35f), "Look left/right");
			GUI.Label(new Rect(250f, 120f, 150f, 35f), "Blink");
			GUI.Label(new Rect(250f, 150f, 150f, 35f), "Left wink");
			GUI.Label(new Rect(250f, 180f, 150f, 35f), "Right wink");
			GUI.Label(new Rect(250f, 210f, 150f, 35f), "Raise brow");
			GUI.Label(new Rect(250f, 240f, 150f, 35f), "Clench teeth");
			GUI.Label(new Rect(250f, 270f, 150f, 35f), "Smile");
			GUI.Label(new Rect(250f, 300f, 150f, 35f), "Right Smirk");
			GUI.Label(new Rect(250f, 330f, 150f, 35f), "Left Smirk");
			GUI.skin = this.skin4;
			try
			{
				float num = GUI.HorizontalSlider(new Rect(350f, 100f, 200f, 20f), this.sp.look, 0f, 10f);
				if (num != this.sp.look)
				{
					this.sp.look = num;
					Debug.Log("Look:" + this.sp.look);
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_HORIEYE, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.look));
				}
				num = GUI.HorizontalSlider(new Rect(350f, 130f, 200f, 20f), this.sp.blink, 0f, 10f);
				if (num != this.sp.blink)
				{
					this.sp.blink = num;
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_BLINK, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.blink));
				}
				num = GUI.HorizontalSlider(new Rect(350f, 160f, 200f, 20f), this.sp.wink_l, 0f, 10f);
				if (num != this.sp.wink_l)
				{
					this.sp.wink_l = num;
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_WINK_LEFT, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.wink_l));
				}
				num = GUI.HorizontalSlider(new Rect(350f, 190f, 200f, 20f), this.sp.wink_r, 0f, 10f);
				if (num != this.sp.wink_r)
				{
					this.sp.wink_r = num;
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_WINK_RIGHT, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.wink_r));
				}
				num = GUI.HorizontalSlider(new Rect(350f, 220f, 200f, 20f), this.sp.brow, 0f, 10f);
				if (num != this.sp.brow)
				{
					this.sp.brow = num;
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_EYEBROW, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.brow));
				}
				num = GUI.HorizontalSlider(new Rect(350f, 250f, 200f, 20f), this.sp.teeth, 0f, 10f);
				if (num != this.sp.teeth)
				{
					this.sp.teeth = num;
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_CLENCH, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.teeth));
				}
				num = GUI.HorizontalSlider(new Rect(350f, 280f, 200f, 20f), this.sp.smile, 0f, 10f);
				if (num != this.sp.smile)
				{
					this.sp.smile = num;
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_SMILE, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.smile));
				}
				num = GUI.HorizontalSlider(new Rect(350f, 310f, 200f, 20f), this.sp.smirk_r, 0f, 10f);
				if (num != this.sp.smirk_r)
				{
					this.sp.smirk_r = num;
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_SMIRK_RIGHT, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.smirk_r));
				}
				num = GUI.HorizontalSlider(new Rect(350f, 340f, 200f, 20f), this.sp.smirk_l, 0f, 10f);
				if (num != this.sp.smirk_l)
				{
					this.sp.smirk_l = num;
					EdkDll.EE_ExpressivSetThreshold(0u, EdkDll.EE_ExpressivAlgo_t.EXP_SMIRK_LEFT, EdkDll.EE_ExpressivThreshold_t.EXP_SENSITIVITY, (int)(100f * this.sp.smirk_l));
				}
			}
			catch (Exception var_1_575)
			{
				Debug.Log("Khoa khoa khoa");
				string currentDirectory = Directory.GetCurrentDirectory();
				string path = currentDirectory + "\\setting.xml";
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
		}
		else
		{
			GUI.skin = this.skin5;
		}
		if (GUI.Button(new Rect(50f, 55f, 85f, 32f), "Headset"))
		{
			this.check_button1 = true;
			this.check_button2 = false;
		}
		if (this.check_button2)
		{
			GUI.DrawTexture(new Rect(34f, 120f, 200f, 200f), this.round);
			this.r = this.largeround * 200f / 12f;
			GUI.DrawTexture(new Rect((float)((int)(134f - this.r / 2f)), (float)((int)(220f - this.r / 2f)), (float)((int)this.r), (float)((int)this.r)), this.smallround);
			GUI.DrawTexture(new Rect((float)(124 + EmoGyroData.GyroX / 16), (float)(210 + EmoGyroData.GyroY / 16), 20f, 20f), this.blackButt);
			GUI.skin = this.MySkin;
			GUI.Label(new Rect(360f, 90f, 100f, 20f), "Gyro sensitivity");
			GUI.skin = this.skin6;
			this.largeround = GUI.VerticalSlider(new Rect(400f, 120f, 20f, 200f), this.largeround, 12f, 4f);
		}
		else
		{
			GUI.skin = this.skin7;
		}
		if (GUI.Button(new Rect(133f, 55f, 85f, 32f), "Gyro"))
		{
			this.check_button2 = true;
			this.check_button1 = false;
		}
		GUI.skin = this.skin8;
		if (GUI.Button(new Rect(525f, 40f, 40f, 40f), string.Empty))
		{
			this.check = false;
			this.check_control = false;
			this.check_button1 = true;
			this.check_button2 = false;
		}
		GUI.DragWindow();
	}
}
