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

		if(hit.transform.tag == "Coin")
		{
			hit.transform.GetComponent<ToolBehavior>().delete();
			UI.coinAdd(10);
		}
		else if(hit.transform.tag == "Mushroom")
		{
		}
		else if(hit.transform.tag == "Blood")
		{

		}
	}
}
