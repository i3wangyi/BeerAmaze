using UnityEngine;
using System.Collections;

public class FogOption : MonoBehaviour {
	public static bool fogoff = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			this.renderer.enabled = fogoff;	
	}
}
