using UnityEngine;
using System.Collections;

public class CollisionAction : MonoBehaviour {
	//Record original scale
	private Vector3 originScale;
	private Vector3 originPos;
	private Vector3 originOri;
	private bool IMBA = false;

	public AudioClip[] audioClip;

	void PlaySound(int clip)
	{
		audio.clip = audioClip [clip];
		audio.Play ();
		}

	// Use this for initialization
	void Start () {
		originScale = this.transform.localScale;
		originPos = this.transform.position;
		originOri = this.transform.eulerAngles;
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

		if(hit.transform.tag == "coin1" )
		{
			hit.transform.GetComponent<ToolBehavior>().delete();
			UI.coinAdd(1);
			PlaySound(0);
		}
		if(hit.transform.tag == "coin5") {
			hit.transform.GetComponent<ToolBehavior>().delete();
			UI.coinAdd(5);
			PlaySound(0);
		}
		if(hit.transform.tag == "coin10") {
			hit.transform.GetComponent<ToolBehavior>().delete();
			UI.coinAdd(10);	
			PlaySound(0);
		}	
		if(hit.transform.tag == "coin20") {
			hit.transform.GetComponent<ToolBehavior>().delete();
			UI.coinAdd(20);	
			PlaySound(0);
		}	
		if(hit.transform.tag == "Mushroom")
		{
			PlaySound(1);
			//Scale up the characte
			hit.transform.GetComponent<ToolBehavior>().delete();
			this.transform.localScale = this.transform.localScale * (1.0f + 0.3f);
			IMBA = true;
			UI.startRecordTime();
		}
		if(hit.transform.tag == "Beer")
		{
			PlaySound(2);
			GameObject.Find ("MainCamera").GetComponent<UI>().EndOfGame = true;
		}
		/*else if(hit.transform.tag == "Monster")
		{
			if(IMBA)
			{
				//Death
				hit.transform.GetComponent<MonsterBehavior1>().setDeath();	
				hit.transform.GetComponent<MonsterBehavior2>().setDeath();
				hit.transform.GetComponent<MonsterBehavior3>().setDeath();
			}
			else{
				//reset to its original position	
				reset();
			}
		}*/
	}
	
	public void resetScale()
	{
		PlaySound(3);
		this.transform.localScale = originScale;
		IMBA = false;
	}

	public bool isIMBA()
	{
		if(IMBA)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void reset()
	{
		this.transform.position = originPos;
		this.transform.eulerAngles = originOri;
	}
}
