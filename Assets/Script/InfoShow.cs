using UnityEngine;
using System.Collections;

public class InfoShow : MonoBehaviour {
	public int count = 0;
	public Texture[] infoImage = new Texture[3];
	public Texture nextTex;
	public Texture preTex;
	public bool info = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		if(info)
		{
			GUI.backgroundColor = Color.clear;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), infoImage[count]);
			GUILayout.BeginArea(new Rect (Screen.width -550, Screen.height - 250, 550, 250));
			GUILayout.BeginHorizontal("box");
			if (GUILayout.Button (preTex)) {
				if(count > 0)
					count--;
			}
			if (GUILayout.Button (nextTex)) {
				count++;
				if(count > 2)
				{
					info = false;
					count = 0;
					GameObject.Find("MENU").GetComponent<StartMenuScript>().startMenu = true;
				}
			}
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();
		}
	}
}
