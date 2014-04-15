using UnityEngine;
using System.Collections;

public class CollisionAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetPosOnCollision(Vector3 pos, Vector3 ori)
	{
		transform.position = pos;
		transform.eulerAngles = ori;
	}
}
