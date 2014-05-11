using UnityEngine;
using System.Collections;

public class CameraFrame : MonoBehaviour {

	public Texture2D textureImage;
	public int frame_depth = 2;

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
		GUI.depth = frame_depth;
		GUI.DrawTexture (new Rect (0.68f * Screen.width, 0.02f * Screen.height, 0.35f * Screen.width, 0.4f * Screen.height), textureImage);
	}
}
