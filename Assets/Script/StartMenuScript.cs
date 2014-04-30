using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour 
{

	private static bool HelpSelected = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		//For Mobile Debugging
		GUI.skin.GetStyle ("Button").fontSize = 45;	
		GUI.skin.GetStyle ("TextField").fontSize = 45;	
		GUI.skin.GetStyle ("box").fontSize = 45;

		GUILayout.BeginArea (new Rect (Screen.width/2 - 300, Screen.height/2 - 500, 600, 1000));
		GUILayout.BeginVertical ("box");

		if (HelpSelected == false) 
		{

			//Start
			if (GUILayout.Button ("START")) 
			{
				Application.LoadLevel ("MazeSelection");
			}
			//Help
			if (GUILayout.Button ("HELP"))
			{
				HelpSelected = true;
			}

		}
		else 
		{


			GUILayout.TextField("Welcome to OurMazeGame!!");
			if (GUILayout.Button ("CLOSE"))
			{
				HelpSelected = false;
			}
		}
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
	}
}
