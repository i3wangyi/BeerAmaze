using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour 
{
	public bool startMenu = true;
	public  bool HelpSelected = false;
	public  bool AboutUsSelected = false;
	public Texture backgroundTexture;
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
		if (startMenu)
		{
			//For Mobile Debugging
			GUI.skin.GetStyle ("Button").fontSize = 45;	
			GUI.skin.GetStyle ("TextField").fontSize = 45;	
			GUI.skin.GetStyle ("box").fontSize = 45;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
			GUILayout.BeginArea (new Rect (Screen.width / 2 - 300, Screen.height / 2 - 500, 600, 1000));
			GUILayout.BeginVertical ("box");

			if (!AboutUsSelected && !HelpSelected) {

					//Start
					if (GUILayout.Button ("Start!")) {
							Application.LoadLevel ("MazeSelection");
					}
					//Help
					if (GUILayout.Button ("Help")) {
							HelpSelected = true;
					}
					//Help
					if (GUILayout.Button ("AboutUs")) {
						AboutUsSelected = true;
					}

			}
			if(HelpSelected)
			{
				startMenu = false;
				HelpSelected = false;
				GameObject.Find("Camera").GetComponent<InfoShow>().info = true;
			}
			if(AboutUsSelected)
			{
				GUILayout.TextField ("Welcome to OurMazeGame!!");
				if (GUILayout.Button ("CLOSE")) {
					AboutUsSelected = false;
				}
			}
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}
	}
}
