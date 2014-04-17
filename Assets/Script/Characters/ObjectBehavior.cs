using UnityEngine;
using System.Collections;

public class ObjectBehavior : MonoBehaviour {

	public static bool isPlayMode = true;
	public bool EnableTranslate = false;
	public bool EnableRotate = false;

	// Object moves as camera moves
	private GameObject camera;
	public Vector3 CameraPrevPos;
	public Vector3 CameraPrevOri;
	public Vector3 CameraNewPos;
	public Vector3 CameraNewOri;


	private Vector3 CameraPosDiff;
	private Vector3 CameraOriDiff;

	private int counter = 0;

	// Use this for initialization
	void Start () 
	{
		camera = GameObject.Find ("MainCamera");

		CameraNewPos = camera.transform.position;
		CameraNewOri = camera.transform.eulerAngles;
		CameraPrevPos = CameraNewPos;
		CameraPrevOri = CameraNewOri;
	}
	
	// Update is called once per frame

	void Update () 
	{
		CameraNewPos = camera.transform.position;
		CameraNewOri = camera.transform.eulerAngles;

		CameraPosDiff = CameraNewPos - CameraPrevPos;
		CameraOriDiff = CameraNewOri - CameraPrevOri;


		if (isPlayMode) {

			//May scale proportionally to camera's movement
			if(EnableTranslate)
			{

				Debug.Log (CameraPosDiff.x.ToString() + " " +CameraPosDiff.z.ToString());
				//Control move in the plane
				this.transform.position += new Vector3(CameraPosDiff.x,0,CameraPosDiff.z);
				this.gameObject.animation.Play("walk", PlayMode.StopAll);
			}
			if(EnableRotate)
			{
				//Add: HeadLight behavior
				//Camera EulerAngle's Y increases, clokwise; otherwise, anticlockwise
				
				//				transform.eulerAngles = new Vector3(transform.eulerAngles.x, CameraNewOri.y, transform.eulerAngles.z);
				this.transform.eulerAngles -= new Vector3(0,CameraPosDiff.y,0);
				
				
				//				transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

			}
		}

		CameraPrevPos = CameraNewPos;
		CameraPrevOri = CameraNewOri;

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
	
}
