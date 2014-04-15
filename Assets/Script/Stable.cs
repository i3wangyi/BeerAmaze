using UnityEngine;
using System.Collections;

public class Stable : MonoBehaviour {

	public Vector3 defaultPos;
	public Vector3 defaultOri;
	// Use this for initialization
	void Start () {
		defaultPos = transform.position;
		defaultOri = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		Vector3 pos = other.transform.position;
		Vector3 ori = other.transform.eulerAngles;

		//Just for debug
		GameObject.Find ("MainCamera").transform.GetComponent<UI>().setMazeCollision(true);
		
		transform.position = defaultPos;
		transform.eulerAngles = defaultOri;

		//May play a sound
		GameObject.Find(other.name).GetComponent<CollisionAction>().SetPosOnCollision(pos,ori);
	}
	void OnTriggerExit()
	{
		GameObject.Find ("MainCamera").transform.GetComponent<UI>().setMazeCollision(false);
	}

}
