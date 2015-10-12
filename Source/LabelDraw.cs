using System;
using UnityEngine;
public class LabelDraw : MonoBehaviour
{
	public string str_Information;
	public bool enable_LabelInformation;
	private float time_count;
	private void Start()
	{
	}
	private void Update()
	{
	}
	private void OnGUI()
	{
		if (this.enable_LabelInformation)
		{
			GUI.Label(new Rect((float)(Screen.width - this.str_Information.Length * 6), (float)(Screen.height - 20), (float)Screen.width, (float)Screen.height), this.str_Information);
			if (Time.time - this.time_count > 5f)
			{
				this.enable_LabelInformation = false;
			}
		}
	}
	private void DrawLabel(string message)
	{
		this.str_Information = message;
		this.enable_LabelInformation = true;
		this.time_count = Time.time;
	}
}
