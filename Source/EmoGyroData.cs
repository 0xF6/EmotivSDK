using System;
using UnityEngine;
public class EmoGyroData : MonoBehaviour
{
	public static Status headPosition;
	public Status oldPosition;
	private EmoEngine engine = EmoEngine.Instance;
	public static int GyroX;
	public static int GyroY;
	public int GTempX;
	public int GTempY;
	public float delayUpdate = 0.1f;
	public float timeNoMove;
	public bool isMoveBack;
	public int oldPositionX;
	public int oldPositionY;
	public float timeMoveBack;
	public float timeCheckStatus;
	private float dis;
	private void Update()
	{
		if (EmoEngineInst.signalStrength == EdkDll.EE_SignalStrength_t.NO_SIGNAL)
		{
			return;
		}
		this.delayUpdate -= Time.deltaTime;
		this.timeCheckStatus += Time.deltaTime;
		if (this.delayUpdate <= 0f)
		{
			this.delayUpdate = 0.1f;
			try
			{
				this.engine.HeadsetGetGyroDelta(0u, out this.GTempX, out this.GTempY);
				if (Math.Abs(this.GTempX) < 15 && Math.Abs(this.GTempY) < 15)
				{
					this.timeNoMove += Time.deltaTime;
					if ((double)this.timeNoMove > 0.07)
					{
						this.oldPositionX = EmoGyroData.GyroX;
						this.oldPositionY = EmoGyroData.GyroY;
						this.timeMoveBack = 0f;
						this.isMoveBack = true;
					}
				}
				else
				{
					this.isMoveBack = false;
					this.timeNoMove = 0f;
					float num = (float)(EmoGyroData.GyroX - this.GTempX / 3);
					float num2 = (float)(EmoGyroData.GyroY + this.GTempY / 3);
					this.dis = Mathf.Sqrt(num * num + num2 * num2);
					if (this.dis < 100f * MainMenu.instance.largeround)
					{
						EmoGyroData.GyroX = (int)num;
						EmoGyroData.GyroY = (int)num2;
					}
					else
					{
						EmoGyroData.GyroX = (int)((100f * MainMenu.instance.largeround + 10f) * (float)EmoGyroData.GyroX / this.dis);
						EmoGyroData.GyroY = (int)((100f * MainMenu.instance.largeround + 10f) * (float)EmoGyroData.GyroY / this.dis);
					}
				}
				this.dis = Mathf.Sqrt((float)(EmoGyroData.GyroX * EmoGyroData.GyroX + EmoGyroData.GyroY * EmoGyroData.GyroY));
				if (this.dis < 90f)
				{
					EmoGyroData.headPosition = Status.Center;
				}
				else
				{
					if (EmoGyroData.GyroX > 100 && EmoGyroData.headPosition != Status.Deny)
					{
						EmoGyroData.headPosition = Status.Right;
					}
					else if (EmoGyroData.GyroX < -100 && EmoGyroData.headPosition != Status.Deny)
					{
						EmoGyroData.headPosition = Status.Left;
					}
					if (EmoGyroData.GyroY > 100)
					{
						EmoGyroData.headPosition = Status.Down;
					}
					else if (EmoGyroData.GyroY < -100)
					{
						EmoGyroData.headPosition = Status.Up;
					}
				}
				if (EmoGyroData.headPosition != this.oldPosition)
				{
					if (this.oldPosition == Status.Left && EmoGyroData.headPosition == Status.Right && (double)this.timeCheckStatus < 1.5)
					{
						EmoGyroData.headPosition = Status.Deny;
					}
					if (this.oldPosition == Status.Right && EmoGyroData.headPosition == Status.Left && (double)this.timeCheckStatus < 1.5)
					{
						EmoGyroData.headPosition = Status.Deny;
					}
					if (EmoGyroData.headPosition != Status.Center)
					{
						this.oldPosition = EmoGyroData.headPosition;
						this.timeCheckStatus = 0f;
					}
				}
			}
			catch (Exception var_2_2DF)
			{
			}
		}
		if (this.isMoveBack)
		{
			this.timeMoveBack += Time.deltaTime * 1.5f;
			Vector3 vector = Vector3.Slerp(new Vector3((float)this.oldPositionX, (float)this.oldPositionY, 0f), Vector3.zero, this.timeMoveBack);
			EmoGyroData.GyroX = (int)vector.x;
			EmoGyroData.GyroY = (int)vector.y;
		}
	}
}
