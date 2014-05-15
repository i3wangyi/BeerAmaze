using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	//Indicate which play mode at present
	public static bool isPlayMode = true;
	public bool EndOfGame = false;
	public static bool isAttacked = false;

	public GameObject player;
	public Camera ARCamera;
	public Camera FPVCamera;
	public int endTime;
	public bool setEndTime;

	private static int coinCount;
	private static float timeCost;
	private int mainCM;
	private int fpvCM;
	public static bool AssistCamera = false;

	public GUISkin customSkin;
	//public GUIStyle myStyle = null;
	private static float duration = 0;
	private static bool scale = false;
	private  bool FPV = false;
	private  bool isAssistView = true;
	private int n = 0; 
	public AudioClip[] audioClip;
	
	void PlaySound(int clip)
	{
		audio.clip = audioClip [clip];
		audio.Play ();
	}
	// Use this for initialization
	void Start () {
		coinCount = 0;
		timeCost = 0;
		Time.timeScale = 1;
		fpvCM = FPVCamera.cullingMask;
		FPV = false;
		mainCM = ARCamera.cullingMask;
		endTime = 0;
		setEndTime = false;
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
		GUI.skin.GetStyle ("Label").alignment = TextAnchor.MiddleCenter;
		GUI.skin.GetStyle ("Button").alignment = TextAnchor.MiddleCenter;

		if(isPlayMode)
		{
			GUILayout.BeginArea(new Rect(0,0,300,1000) );

				GUILayout.BeginVertical("box");
				GUILayout.Label("Timer:" + Mathf.CeilToInt(timeCost).ToString());
				GUILayout.Label("Points:" + coinCount.ToString());
				if(GUILayout.Button("Setting"))
				{
					PlaySound(0);
					if(n == 0) n = 1;
					else n = 0;
				}
				GUILayout.EndVertical();

			GUILayout.EndArea();

			if(n == 1)
			{
				GUILayout.BeginArea(new Rect(300,125,300,1000) );
				
				GUILayout.BeginVertical("box");
				if(GUILayout.Button ("View Switch"))
				{
					PlaySound(0);
					viewSwitch(FPV);

					FPV = !FPV;
					isAssistView = true;

					JoyStick.SwitchView();
				}
				if(!FPV)
				{
					if(GUILayout.Button("Fog"))
					{
						PlaySound(0);
						FogOption.fogoff=!FogOption.fogoff;
					}
				}
				if(GUILayout.Button("Assist View"))
				{
					PlaySound(0);
					if(FPV)
					{
						GameObject.Find("MainCamera").camera.enabled = !GameObject.Find("MainCamera").camera.enabled;
						GameObject.Find("FPV_Camera").camera.enabled = true;
					}
					else{
						GameObject.Find("FPV_Camera").camera.enabled = !GameObject.Find("FPV_Camera").camera.enabled;
						GameObject.Find("MainCamera").camera.enabled = true; 
					}
					CameraFrame.visible = !CameraFrame.visible;
				}
				if(GUILayout.Button ("Restart"))
				{
					PlaySound(0);
					Application.LoadLevel ("Welcome");
				}

				GUILayout.EndVertical();
				
				GUILayout.EndArea();
			}
		}

		if (isAttacked) 
		{
			GUILayout.BeginArea(new Rect(650,300,600,1000) );
			GUILayout.BeginVertical("box");
			GUILayout.Label("You have been attacked by a monster!!");
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		
		if (EndOfGame) 
		{
			if(!setEndTime)
			{
				setEndTime = !setEndTime;
				endTime = Mathf.CeilToInt(timeCost);
			}

			GUILayout.BeginArea(new Rect(650,300,600,1000) );
			GUILayout.BeginVertical("box");
			GUILayout.Label("Congratulation!! You Win!!");
			GUILayout.Label("Timer:" + endTime.ToString());
			GUILayout.Label("Points:" + coinCount.ToString());
			if (GUILayout.Button ("RESTART!!")) 
			{
				PlaySound(0);
				Application.LoadLevel ("Welcome");
			}
			if (GUILayout.Button ("QUIT!!")) 
			{
				PlaySound(0);
				Application.Quit();
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
//			Time.timeScale = 0;
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
	
	public void viewSwitch(bool v)
	{
		Debug.Log ("v:" + v);
		//consider camera depth
		if(!v)
		{
			ARCamera.depth = 2;
			FPVCamera.depth = 1;

			FPVCamera.cullingMask = mainCM;
			ARCamera.cullingMask = fpvCM;

			ARCamera.rect = new Rect(0.68f,0.62f,0.32f,0.37f);
			FPVCamera.rect = new Rect(0,0,1,1);

			GameObject.Find("MainCamera").camera.enabled = true;
			GameObject.Find("FPV_Camera").camera.enabled = true;	
			CameraFrame.visible = true;
		}
		else{
			ARCamera.depth = 1;
			FPVCamera.depth = 2;

			FPVCamera.cullingMask = fpvCM;
			ARCamera.cullingMask = mainCM;
			ARCamera.rect = new Rect(0,0,1,1);
			FPVCamera.rect = new Rect(0.68f,0.62f,0.32f,0.37f);

			GameObject.Find("MainCamera").camera.enabled = true;
			GameObject.Find("FPV_Camera").camera.enabled = true;	
			CameraFrame.visible = true;

		}
	}


}
