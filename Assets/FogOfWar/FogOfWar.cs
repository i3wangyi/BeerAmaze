using UnityEngine;
using System.Collections;

public class FogOfWar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer> ().material.SetVector ("_Player_Pos", GameObject.Find ("soldier").transform.position);
		this.GetComponent<Renderer> ().material.SetVector ("_Player_Ori", GameObject.Find ("soldier").transform.forward);
	}
}
