using UnityEngine;
using System.Collections;

public class FogOfWar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer> ().material.SetVector ("_Player_Pos", GameObject.Find ("MAX").transform.position);
		this.GetComponent<Renderer> ().material.SetVector ("_Player_Ori", GameObject.Find ("MAX").transform.forward);
	}
}
