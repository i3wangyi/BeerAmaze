using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	//Indicate which play mode at present
	public static bool isPlayMode = true;
	public GameObject player;
	private static int coinCount;
	private static float timeCost;
	public GUISkin customSkin;
	//public GUIStyle myStyle = null;
	private static float duration = 0;
	private static bool scale = false;
	// Use this for initialization
	void Start () {
		coinCount = 0;
		timeCost = 0;
	}

	public static void coinAdd(int value)
	{
		coinCount = coinCount + value;
	}

	// Update is called once per frame
	void Update () {
	//this.transform.LookAt(player.transform.position);
		timeCost += Time.deltaTime;

		if(scale)
		{
			//within 10s 
			if(Mathf.CeilToInt(duration) <= 10)
			{
				duration += Time.deltaTime;
			}
			else
			{
				//reset to its original scale after 10 seconds
				GameObject.Find("MAX").GetComponent<CollisionAction>().resetScale();
				scale = false;
			}
		}

	}

	void OnGUI()
	{
		//For Mobile Debugging
		GUI.skin = customSkin;
		GUI.skin.GetStyle ("Button").fontSize = 45;
		GUI.skin.GetStyle ("Label").fontSize = 45;			
		GUI.skin.GetStyle ("TextField").fontSize = 45;
		GUI.skin.GetStyle ("HorizontalSlider").fixedHeight = 65;
		GUI.skin.GetStyle ("HorizontalSlider").fixedWidth = 200;
		GUI.skin.GetStyle("box").fontSize = 45;

		if(isPlayMode)
		{
			GUILayout.BeginArea(new Rect(0,0,400,1000) );

				GUILayout.BeginVertical("box");
				GUILayout.Label("Timer : " + Mathf.CeilToInt(timeCost).ToString());
				GUILayout.Label("Points : " + coinCount.ToString());
				GUILayout.EndVertical();

			GUILayout.EndArea();
		}
	}

	                            
	Rect ResizeGUI(Rect _rect)
	{
		float FilScreenWidth = _rect.width / 800;
		float rectWidth = FilScreenWidth * Screen.width;
		float FilScreenHeight = _rect.height / 600;
		float rectHeight = FilScreenHeight * Screen.height;
		float rectX = (_rect.x / 800) * Screen.width;
		float rectY = (_rect.y / 600) * Screen.height;
		
		return new Rect(rectX,rectY,rectWidth,rectHeight);
	}

	//When given object is selected, its character will be passed to the UI
	public void setCharacter(GameObject Character)
	{
		player = Character;
	}
	public static void setPlayMode()
	{
		isPlayMode = true;
	}
	public static void resetPlayMode()
	{
		isPlayMode = false;
	}

	public static void startRecordTime()
	{
		duration = 0;
		scale = true;
	}
	



}
