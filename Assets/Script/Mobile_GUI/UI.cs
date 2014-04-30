using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	//Indicate which play mode at present
	public static bool isPlayMode = true;
	public GameObject player;
	public bool MazeCollision = false;
	private bool move = false;
	private bool rotate = false;
	private bool radardetection = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		this.transform.LookAt(player.transform.position);	
	}

	void OnGUI()
	{
		//For Mobile Debugging
		GUI.skin.GetStyle ("Button").fontSize = 45;
		GUI.skin.GetStyle ("Label").fontSize = 45;			
		GUI.skin.GetStyle ("TextField").fontSize = 45;
		GUI.skin.GetStyle ("HorizontalSlider").fixedHeight = 45;
		GUI.skin.GetStyle ("HorizontalSlider").fixedWidth = 300;
		GUI.skin.GetStyle("box").fontSize = 45;

		if(isPlayMode)
		{
			GUILayout.BeginArea(new Rect(0,0,600,1000) );

				GUILayout.BeginVertical("box");
					//Translate
					if(GUILayout.RepeatButton("Move"))
					{
						move = true;
				        player.GetComponent<ObjectBehavior>().setMove();
					}
					else if(move){
						move = false;
						player.GetComponent<ObjectBehavior>().resetMove();
					}

					//Rotate
					if(GUILayout.RepeatButton("Look around"))
					{
						rotate = true;
						player.GetComponent<ObjectBehavior>().setRotate();
					}
					else if(rotate){
						rotate = false;	
						player.GetComponent<ObjectBehavior>().resetRotate();
					}

					//For debug camera's position
					GUILayout.TextField(this.transform.position.ToString());
					GUILayout.TextField("("+(int)this.transform.eulerAngles.x+","+(int)this.transform.eulerAngles.y+","+(int)this.transform.eulerAngles.z + ")");
					
					if(MazeCollision)
					{
						GUILayout.TextField("Collision Detection");
					}
					if(radardetection)
					{
						GUILayout.TextField("Radar detection");
					}
					
				GUILayout.EndVertical();

			GUILayout.EndArea();
		}
	}

	//For debug
	public void setMazeCollision(bool c)
	{
		MazeCollision = c;
	}
	public void setRadar(bool c)
	{
		radardetection = c;
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
	public void setPlayMode()
	{
		isPlayMode = true;
	}
	public void resetPlayMode()
	{
		isPlayMode = false;
	}
}
