using UnityEngine;
using System.Collections;

public class wayfinding : MonoBehaviour
{
	//For holding the compass textures
	public Texture2D bg;
	public Texture2D bubble;

	//"North" in the game
	//0 for + Z Axis, 90 for + X Axis, etc
	public float north;
	
	//Where the compass bubble needs to be inside the compass
	public float radius;
	
	//Where the compass needs to be placed
	public Vector2 center;
	
	//Size in pixels about how big the compass should be
	public Vector2 compassSize;
	public Vector2 bubbleSize;
	
	// Use this for initialization
	void Start()
	{
		//Set the placement of compass from size and center
		compassRect = new Rect(
			center.x - compassSize.x / 2,
			center.y - compassSize.y / 2,
			compassSize.x,
			compassSize.y);
	}

	Rect compassRect;
	void OnGUI()
	{
		GUI.Box(new Rect(0, Screen.height- 30, 200, 30), "Compass");
		
		// Draw background
		GUI.DrawTexture(compassRect, bg);
		
		// Draw bubble
		GUI.DrawTexture(new Rect(center.x + x - bubbleSize.x / 2, center.y + y - bubbleSize.y/2, bubbleSize.x, bubbleSize.y), bubble);
	}
	
	// Update is called once per frame
	float rot, x, y;
	void Update()
	{
		// Note -90 compensation cos north is along 2D Y axis
		rot = (-90 + this.transform.eulerAngles.y - north)* Mathf.Deg2Rad;
		
		// Bubble position
		x = radius * Mathf.Cos(rot);
		y = radius * Mathf.Sin(rot);
	}
}