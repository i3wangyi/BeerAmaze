using UnityEngine;
using System.Collections;

public class MonstrerBehavior : MonoBehaviour 
{
	private string direction = "forward";
	private bool isDeath = false;
	
	// Use this for initialization
	void Start ()
	{
		this.gameObject.animation.Play("idle", PlayMode.StopAll);	//idle, attack
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!isDeath){
			if (this.gameObject.transform.localPosition.x < 0.4 && direction.Equals("forward")) 
			{
				this.gameObject.transform.localPosition = this.gameObject.transform.localPosition + new Vector3(0.001f, 0f, 0f);
			}
			else if(this.gameObject.transform.localPosition.x > (-0.4) && direction.Equals("backward"))
			{
				this.gameObject.transform.localPosition = this.gameObject.transform.localPosition - new Vector3(0.001f, 0f, 0f);
			}
			else
			{
				if(this.gameObject.transform.localPosition.x >= 0.4 && direction.Equals("forward"))
				{
					Debug.Log("turn");
					direction = "backward";
					this.gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
				}
				else if(direction.Equals("backward"))
				{
					Debug.Log("turn again");
					direction = "forward";
					this.gameObject.transform.localEulerAngles = new Vector3(0f, 270f, 0f);
				}
			}
		}
	}

	public void setDeath()
	{
		isDeath = true;
		this.gameObject.animation.Play("death", PlayMode.StopAll);
	}

}
