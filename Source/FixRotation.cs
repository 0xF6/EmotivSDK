using System;
using UnityEngine;
public class FixRotation : MonoBehaviour
{
	private Quaternion orgRot;
	private void Start()
	{
		this.orgRot = base.transform.rotation;
	}
	private void Update()
	{
		base.transform.rotation = this.orgRot;
	}
}
