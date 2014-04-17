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

	private int counter = 0;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.Find ("MainCamera");

		CameraNewPos = MainCamera.transform.position;
		CameraNewOri = MainCamera.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayMode) {



			if(counter < 1)
			{
				counter++;
			}
			else
			{
				CameraPrevPos = CameraNewPos;
				CameraPrevOri = CameraNewOri;
				counter = 0;
			}

			Vector3 CameraPosDiff = CameraNewPos - CameraPrevPos;
			Vector3 CameraOriDiff = CameraNewOri - CameraPrevOri;
			//May scale proportionally to camera's movement
			if(EnableTranslate)
			{
				Debug.Log(CameraNewPos.ToString());
				Debug.Log(CameraPrevPos.ToString());
				Debug.Log(CameraPosDiff.x.ToString());
				//Control move in the plane
				Debug.Log(new Vector3(CameraPosDiff.x,0,CameraPosDiff.z).ToString());
				this.gameObject.transform.position += new Vector3(CameraPosDiff.x,0,CameraPosDiff.z);
				Debug.Log(transform.position.ToString());
				GameObject.Find("MAX").animation.Play("walk", PlayMode.StopAll);
			}
			if(EnableRotate)
			{
				float rotateSpeed = 5.0f * CameraOriDiff.y>0?1:-1;
				//Add: HeadLight behavior
				//Camera EulerAngle's Y increases, clokwise; otherwise, anticlockwise

//				transform.eulerAngles = new Vector3(transform.eulerAngles.x, CameraNewOri.y, transform.eulerAngles.z);
				transform.eulerAngles -= new Vector3(0,CameraPosDiff.y,0);


//				transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
			}

			CameraNewPos = MainCamera.transform.position;
			CameraNewOri = MainCamera.transform.eulerAngles;

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
