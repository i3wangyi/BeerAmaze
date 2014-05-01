using UnityEngine;
using System.Collections;

public class CollisionAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{
	}

	void OnCollisionExit()
	{
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		hit.transform.GetComponent<ToolBehavior>().delete();

		if(hit.transform.tag == "Coin")
		{

		}
		else if(hit.transform.tag == "Mushroom")
		{
		}
		else if(hit.transform.tag == "Blood")
		{

		}
	}
}
