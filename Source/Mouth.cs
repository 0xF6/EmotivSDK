using System;
using UnityEngine;
public class Mouth : MonoBehaviour
{
	private const float offsetMin = -3.6f;
	private const float offsetMax = -1.7f;
	private const float speed = 0.1f;
	public Texture textureNormal;
	public Texture textureSmile;
	public Texture textureClench;
	public Texture textureSmirkLeft;
	public Texture textureSmirkRight;
	public Texture textureLaugh;
	public MouthState state;
	public float offsetY;
	public Animation mouth;
	private Mesh mesh;
	private Vector3[] vertices;
	private Vector2[] uv;
	private int[] moveVertices = new int[]
	{
		1,
		2,
		3,
		4,
		6,
		8,
		9
	};
	private int[] staticVertices = new int[]
	{
		0,
		5,
		7
	};
	private bool bMovePoints;
	private float offsetTo;
	private float offsetStep;
	private void Start()
	{
		this.mesh = base.GetComponent<MeshFilter>().mesh;
		this.vertices = this.mesh.vertices;
		this.uv = this.mesh.uv;
	}
	private void FixedUpdate()
	{
		if (!this.bMovePoints)
		{
			switch (this.state)
			{
			case MouthState.Normal:
				if (base.renderer.material.mainTexture != this.textureNormal)
				{
					base.renderer.material.mainTexture = this.textureNormal;
					this.offsetY = -1.7f;
					this.UpdateMouth();
				}
				break;
			case MouthState.Smile:
				if (base.renderer.material.mainTexture != this.textureSmile)
				{
					base.renderer.material.mainTexture = this.textureSmile;
					this.MovePoints(-3.6f, -1.7f, 0.1f);
				}
				break;
			case MouthState.Clench:
				if (base.renderer.material.mainTexture != this.textureClench)
				{
					base.renderer.material.mainTexture = this.textureClench;
					this.MovePoints(-3.6f, -1.7f, 0.2f);
				}
				break;
			case MouthState.SmirkLeft:
				if (base.renderer.material.mainTexture != this.textureSmirkLeft)
				{
					base.renderer.material.mainTexture = this.textureSmirkLeft;
					this.MovePoints(-3.6f, -1.7f, 0.1f);
				}
				break;
			case MouthState.SmirkRight:
				if (base.renderer.material.mainTexture != this.textureSmirkRight)
				{
					base.renderer.material.mainTexture = this.textureSmirkRight;
					this.MovePoints(-3.6f, -1.7f, 0.1f);
				}
				break;
			case MouthState.Laugh:
				if (base.renderer.material.mainTexture != this.textureLaugh)
				{
					base.renderer.material.mainTexture = this.textureLaugh;
					this.mouth.CrossFade("laugh");
				}
				break;
			}
		}
		if (!this.bMovePoints)
		{
			return;
		}
		this.UpdateMouth();
		this.offsetY += this.offsetStep;
		if (this.offsetStep > 0f && this.offsetY > this.offsetTo)
		{
			this.bMovePoints = false;
		}
	}
	private void UpdateMouth()
	{
		Vector3[] array = new Vector3[this.vertices.Length];
		Vector2[] array2 = new Vector2[this.uv.Length];
		for (int i = 0; i < this.moveVertices.Length; i++)
		{
			array[this.moveVertices[i]] = new Vector3(this.vertices[this.moveVertices[i]].x, this.vertices[this.moveVertices[i]].y, this.vertices[this.moveVertices[i]].z - this.offsetY);
			array2[this.moveVertices[i]] = new Vector2(this.uv[this.moveVertices[i]].x, this.uv[this.moveVertices[i]].y + this.offsetY / 10f);
		}
		for (int j = 0; j < this.staticVertices.Length; j++)
		{
			array[this.staticVertices[j]] = this.vertices[this.staticVertices[j]];
			array2[this.staticVertices[j]] = this.uv[this.staticVertices[j]];
		}
		this.mesh.vertices = array;
		this.mesh.uv = array2;
	}
	protected void MovePoints(float from, float to, float step)
	{
		this.bMovePoints = true;
		if (from < -3.6f)
		{
			from = -3.6f;
		}
		if (from > -1.7f)
		{
			from = -1.7f;
		}
		if (to < -3.6f)
		{
			to = -3.6f;
		}
		if (to > -1.7f)
		{
			to = -1.7f;
		}
		this.offsetY = from;
		this.offsetTo = to;
		this.offsetStep = step;
	}
	public void SetState(MouthState newState)
	{
		this.state = newState;
	}
}
