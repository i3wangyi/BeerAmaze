using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour 
{
	public bool startMenu = true;
	public  bool HelpSelected = false;
	public  bool AboutUsSelected = false;
	public Texture backgroundTexture;
	public GUISkin customSkin;

	public AudioClip[] audioClip;
	
	void PlaySound(int clip)
	{
		audio.clip = audioClip [clip];
		audio.Play ();
	}

	// Use this for initialization
	void Start () 
	{
//		this.enabled = false;
		PlaySound(0);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI() {
		GUI.skin = customSkin;
		if (startMenu)
		{
			//For Mobile Debugging

			GUI.skin.GetStyle ("Button").fontSize = 45;	
			GUI.skin.GetStyle ("TextField").fontSize = 45;	
			GUI.skin.GetStyle ("box").fontSize = 45;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
			if(!AboutUsSelected)
			{
				GUILayout.BeginArea (new Rect (Screen.width / 2 - 300, Screen.height / 2 , 600, 600));
				GUILayout.BeginVertical ("box");
			}
			else
			{
				GUILayout.BeginArea (new Rect (Screen.width / 2 - 300, Screen.height / 2 -200, 600, 600));
				GUILayout.BeginVertical ("box");
			}
			if (!AboutUsSelected && !HelpSelected) 
			{

					//Start
					if (GUILayout.Button ("Start!")) {
					PlaySound(0);
					Application.LoadLevel ("MazeSelection");
					}
					//Help
					if (GUILayout.Button ("Help")) {
					PlaySound(0);		
					HelpSelected = true;
					}
					//Help
					if (GUILayout.Button ("About Us")) {
					PlaySound(0);	
					AboutUsSelected = true;
					}

			}
			if(HelpSelected)
			{
				startMenu = false;
				HelpSelected = false;
				GameObject.Find("MENU").GetComponent<InfoShow>().info = true;
			}
			if(AboutUsSelected)
			{
				GUI.skin.GetStyle ("Label").fontSize = 45;	
				GUILayout.Label ("Welcome to OurMazeGame!!");
				GUILayout.Label ("Our members are : "); 
				GUILayout.Label ("Wen-Ping Chi,"); 
				GUILayout.Label ("Yi Wang,"); 
				GUILayout.Label ("Shuai Lu,");
				GUILayout.Label ("Margaret Elizabeth Kinetz!"); 
				if (GUILayout.Button ("Close")) {
					AboutUsSelected = false;
				}
			}

			if(GUILayout.Button("Quit"))
			{
				Application.Quit();
			}

			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}
	}
}
