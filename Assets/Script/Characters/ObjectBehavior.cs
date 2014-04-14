using UnityEngine;
using System.Collections;

public class ObjectBehavior : MonoBehaviour {

	public static bool isPlayMode = true;
	public bool EnableTranslate = false;
	public bool EnableRotate = false;

	// Object moves as camera moves
	public GameObject MainCamera;
	public Vector3 CameraPrevPos;
	public Vector3 CameraPrevOri;
	public Vector3 CameraNewPos;
	public Vector3 CameraNewOri;
	//Object position and orientation
	public Vector3 prevPos;
	public Vector3 PrevOri;

	public Vector3 newPos;
	public Vector3 newOri;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.Find ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {

		if (isPlayMode) {

			CameraNewPos = MainCamera.transform.position;
			CameraNewOri = MainCamera.transform.eulerAngles;

			Vector3 CameraPosDiff = CameraNewPos - CameraPrevPos;
			Vector3 CameraOriDiff = CameraNewOri - CameraPrevOri;
			float rotateSpeed = 1.0f;

			//May scale proportionally to camera's movement
			if(EnableTranslate)
			{
				//Control move in the plane
				transform.position += new Vector3(CameraPosDiff.x,0,CameraPosDiff.z);
			}
			if(EnableRotate)
			{
				//Add: HeadLight behavior
				transform.Rotate(Vector3.up * Time.deltaTime*rotateSpeed);
			}

			CameraPrevPos = CameraNewPos;
			CameraPrevOri = CameraNewOri;

		}
	}

	public void setPlayMode()
	{
		isPlayMode = true;
	}
	public void resetPlayMode()
	{
		isPlayMode = false;
	}
	public void setMove()
	{
		EnableTranslate = true;
	}
	public void resetMove()
	{
		EnableTranslate = false;
	}
	public void setRotate()
	{
		EnableRotate = true;
	}
	public void resetRotate()
	{
		EnableRotate = false;
	}

	//Called when user hold the UI's translate or rotate button, used to record the camera's position at that time
	public void setCameraStatus()
	{
		CameraPrevPos = MainCamera.transform.position;
		CameraPrevOri = MainCamera.transform.eulerAngles;
	}
	                 
}
