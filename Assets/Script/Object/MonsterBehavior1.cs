using UnityEngine;
using System.Collections;
//Go forward and backward
public class MonsterBehavior1 : MonoBehaviour
{
	private string direction = "forward";
	private bool isDeath = false;

	public AudioClip[] audioClip;
	void PlaySound(int clip)
	{
		audio.clip = audioClip [clip];
		audio.Play ();
	}
	// Use this for initialization
	void Start ()
	{
		this.gameObject.animation.Play("idle", PlayMode.StopAll);	//idle, attack
		this.gameObject.transform.localEulerAngles = new Vector3(0f, 270f, 0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!isDeath){
			if (direction.Equals("forward")) 
			{
				this.gameObject.transform.localPosition = this.gameObject.transform.localPosition + new Vector3(0.001f, 0f, 0f);
			}
			else if(direction.Equals("backward"))
			{
				this.gameObject.transform.localPosition = this.gameObject.transform.localPosition - new Vector3(0.001f, 0f, 0f);
			}
			else
			{
				;
			}
		}
	}

	void OnTriggerEnter(Collider col) 
	{
		if(!isDeath && !col.gameObject.tag.ToString().Equals("Player"))
		{
			if(direction.Equals("forward"))
			{
				direction = "backward";
				this.gameObject.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
			}
			else if(direction.Equals("backward"))
			{
				direction = "forward";
				this.gameObject.transform.localEulerAngles = new Vector3(0f, 270f, 0f);
			}
		}
		else if(!isDeath && col.gameObject.tag.ToString().Equals("Player"))
		{
			if(col.GetComponent<CollisionAction>().isIMBA())
			{
				PlaySound(0);
				setDeath();
			}
			else
			{
				PlaySound(1);
				col.GetComponent<CollisionAction>().reset();
				UI.isAttacked = true;
				Invoke("ToggleLabel", 2);
			}
		}
	}

	public void ToggleLabel() 
	{
		UI.isAttacked = false;
	}

	/*void OnCollisionEnter(Collision col)
	{
		;
	}*/

	public void setDeath()
	{
		isDeath = true;
		UI.coinAdd(30);
		Destroy(this.gameObject);
		//this.gameObject.animation.Play("death", PlayMode.StopAll);
	}

}
