using UnityEngine;
using System.Collections;
//Go left and right
public class MonsterBehavior2 : MonoBehaviour 
{
	private string direction = "left";
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

		if(!isDeath && !col.gameObject.tag.ToString().Equals("Player"))
		{
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
		else if(!isDeath && col.gameObject.tag.ToString().Equals("Player"))
		{
			if(col.GetComponent<CollisionAction>().isIMBA())
			{
				PlaySound (1);
				//setDeath();
				Invoke("setDeath", 1);
			}
			else
			{
				PlaySound (0);
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
