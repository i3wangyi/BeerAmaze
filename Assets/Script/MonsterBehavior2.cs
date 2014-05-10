using UnityEngine;
using System.Collections;
//Go left and right
public class MonsterBehavior2 : MonoBehaviour {

	private string direction = "left";
	private bool isDeath = false;
	
	// Use this for initialization
	void Start ()
	{
		this.gameObject.animation.Play("idle", PlayMode.StopAll);	//idle, attack
		this.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!isDeath){
			if (direction.Equals("right")) 
			{
				this.gameObject.transform.localPosition = this.gameObject.transform.localPosition + new Vector3(0f, 0f, 0.001f);
			}
			else if(direction.Equals("left"))
			{
				this.gameObject.transform.localPosition = this.gameObject.transform.localPosition - new Vector3(0f, 0f, 0.001f);
			}
			else
			{
				;
			}
		}
	}
	
	void OnTriggerEnter(Collider col) 
	{
		Debug.Log ("collision"+col.ToString());
		if(direction.Equals("right"))
		{
			direction = "left";
			this.gameObject.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
		else if(direction.Equals("left"))
		{
			direction = "right";
			this.gameObject.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
		}
	}
	
	/*void OnCollisionEnter(Collision col)
	{
		;
	}*/
	
	public void setDeath()
	{
		isDeath = true;
		this.gameObject.animation.Play("death", PlayMode.StopAll);
	}
}
