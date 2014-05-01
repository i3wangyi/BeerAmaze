using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour {
	
	public GameObject player; //  target object 

	public float smoothTime = 0.1f; // time for dampen
	public bool cameraFollowX = true; // camera follows on horizontal
	public bool cameraFollowY = true; // camera follows on vertical
	public bool cameraFollowHeight = true; // camera follow CameraTarget object height
	public float cameraHeight = 2.5f; // height of camera adjustable

	public float xVelocity = 0.0f;
	public float zVelocity = 0.0f;
	private Transform thisTransform; // camera Transform
	
	// Use this for initialization
	void Start () {
		thisTransform = transform;

//		player.transform.parent = thisTransform;

	}
	
	// Update is called once per frame
	void Update () {

	}
}