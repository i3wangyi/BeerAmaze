using UnityEngine;
using System.Collections;

public class CameraFrame : MonoBehaviour {

	public Texture2D textureImage;
	public int frame_depth = 2;
	public static bool visible = true;

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
		if(UI.isPlayMode && visible )
		{
			GUI.depth = frame_depth;
			GUI.DrawTexture (new Rect (0.68f * Screen.width, 0, 0.35f * Screen.width, 0.4f * Screen.height), textureImage);
		}
	}
}
