using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	//Indicate which play mode at present
	public bool isPlayMode = true;
	public GameObject MainObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Set mobile GUI
	void onGUI()
	{
		if(isPlayMode)
		{
			GUILayout.BeginArea(new Rect(0,0,400,1000) );
			GUILayout.BeginVertical("box");
			GUILayout.BeginHorizontal("box");
			//Translate
			if(GUILayout.RepeatButton("Move"))
			{
				MainObject.GetComponent<ObjectBehavior>().setMove();
				MainObject.GetComponent<ObjectBehavior>().setCameraStatus();
			}
			else{
				MainObject.GetComponent<ObjectBehavior>().resetMove();
			}
			GUILayout.EndHorizontal();


			GUILayout.BeginHorizontal("box");
			//Rotate
			if(GUILayout.RepeatButton("Look around"))
			{
				MainObject.GetComponent<ObjectBehavior>().setRotate();
				MainObject.GetComponent<ObjectBehavior>().setCameraStatus();
			}
			else{
				MainObject.GetComponent<ObjectBehavior>().resetRotate();
			}
			GUILayout.EndHorizontal();
		}
	}
	//When given object is selected, its character will be passed to the UI
	public void setCharacter(GameObject Character)
	{
		MainObject = Character;
	}
	public void setPlayMode()
	{
		isPlayMode = true;
	}
	public void resetPlayMode()
	{
		isPlayMode = false;
	}
}
