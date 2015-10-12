using System;
using UnityEngine;
public class EmoBot : MonoBehaviour
{
	private const int lookFrames = 120;
	public Transform head;
	public Mouth mouth;
	public GameObject leftBrow;
	public GameObject rightBrow;
	public GameObject leftEye;
	public GameObject rightEye;
	public Light leftLightLeft1;
	public Light leftLightLeft2;
	public Light leftLightCenter1;
	public Light leftLightCenter2;
	public Light leftLightRight1;
	public Light leftLightRight2;
	public Light rightLightLeft1;
	public Light rightLightLeft2;
	public Light rightLightCenter1;
	public Light rightLightCenter2;
	public Light rightLightRight1;
	public Light rightLightRight2;
	private int eyeLightCountDown;
	private void Start()
	{
		this.leftEye.animation["blink"].speed = 2f;
		this.rightEye.animation["blink"].speed = 2f;
	}
	private void Update()
	{
		this.RotateHead();
	}
	private void RotateHead()
	{
		Vector3 worldPosition = new Vector3((float)(EmoGyroData.GyroX + Screen.width / 2), (float)(EmoGyroData.GyroY + Screen.height / 2), 0f);
		worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(worldPosition.x, worldPosition.y, 15f));
		this.head.LookAt(worldPosition);
		this.head.Rotate(0f, -90f, 0f);
	}
	public void SetMouthState(MouthState state)
	{
		this.mouth.SetState(state);
	}
	public void SetBrowState(BrowState state)
	{
		if (state != BrowState.Furrow)
		{
			if (state == BrowState.Raise)
			{
				this.leftBrow.animation.CrossFade("raise brow");
				this.rightBrow.animation.CrossFade("raise brow");
				this.leftEye.animation.CrossFade("raise");
				this.rightEye.animation.CrossFade("raise");
			}
		}
		else
		{
			this.leftBrow.animation.CrossFade("furrow brow");
			this.rightBrow.animation.CrossFade("furrow brow");
			this.leftEye.animation.CrossFade("furrow");
			this.rightEye.animation.CrossFade("furrow");
		}
	}
	public void SetEyeState(EyeState state)
	{
		switch (state)
		{
		case EyeState.Blink:
			this.leftEye.animation.CrossFade("blink");
			this.rightEye.animation.CrossFade("blink");
			break;
		case EyeState.WinkLeft:
			this.leftEye.animation.CrossFade("wink");
			break;
		case EyeState.NormalLeft:
			this.leftEye.animation.CrossFade("normal");
			break;
		case EyeState.WinkRight:
			this.rightEye.animation.CrossFade("wink");
			break;
		case EyeState.NormalRight:
			this.rightEye.animation.CrossFade("normal");
			break;
		case EyeState.LookLeft:
			this.leftLightLeft1.enabled = true;
			this.leftLightLeft2.enabled = true;
			this.leftLightCenter1.enabled = false;
			this.leftLightCenter2.enabled = false;
			this.leftLightRight1.enabled = false;
			this.leftLightRight2.enabled = false;
			this.rightLightLeft1.enabled = true;
			this.rightLightLeft2.enabled = true;
			this.rightLightCenter1.enabled = false;
			this.rightLightCenter2.enabled = false;
			this.rightLightRight1.enabled = false;
			this.rightLightRight2.enabled = false;
			this.eyeLightCountDown = 20;
			break;
		case EyeState.LookRight:
			this.leftLightLeft1.enabled = false;
			this.leftLightLeft2.enabled = false;
			this.leftLightCenter1.enabled = false;
			this.leftLightCenter2.enabled = false;
			this.leftLightRight1.enabled = true;
			this.leftLightRight2.enabled = true;
			this.rightLightLeft1.enabled = false;
			this.rightLightLeft2.enabled = false;
			this.rightLightCenter1.enabled = false;
			this.rightLightCenter2.enabled = false;
			this.rightLightRight1.enabled = true;
			this.rightLightRight2.enabled = true;
			this.eyeLightCountDown = 20;
			break;
		case EyeState.LookMiddle:
			this.leftLightLeft1.enabled = false;
			this.leftLightLeft2.enabled = false;
			this.leftLightCenter1.enabled = true;
			this.leftLightCenter2.enabled = true;
			this.leftLightRight1.enabled = false;
			this.leftLightRight2.enabled = false;
			this.rightLightLeft1.enabled = false;
			this.rightLightLeft2.enabled = false;
			this.rightLightCenter1.enabled = true;
			this.rightLightCenter2.enabled = true;
			this.rightLightRight1.enabled = false;
			this.rightLightRight2.enabled = false;
			break;
		}
	}
}
