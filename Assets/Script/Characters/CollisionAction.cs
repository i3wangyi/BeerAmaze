using UnityEngine;
using System.Collections;

public class CollisionAction : MonoBehaviour {
	public Vector3 defaultPos;
	public Vector3 defaultOri;

	// Use this for initialization
	void Start () {
		defaultPos = this.transform.position;
		defaultOri = this.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{
		SetPosOnCollision(defaultPos,defaultOri);

		GameObject.Find ("MainCamera").transform.GetComponent<UI>().setMazeCollision(true);
	}

	void OnCollisionExit()
	{
		GameObject.Find ("MainCamera").transform.GetComponent<UI>().setMazeCollision(false);
	}

	public void SetPosOnCollision(Vector3 pos, Vector3 ori)
	{
		this.transform.position = pos;
		this.transform.eulerAngles = ori;
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.transform.tag == "object")
		{
			hit.transform.SendMessage("delete",SendMessageOptions.DontRequireReceiver);
		}
	}
}
