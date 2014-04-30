using UnityEngine;
using System.Collections;

public class  ObjectBehavior: MonoBehaviour {
	public static bool isPlayMode = true;
	public bool EnableTranslate = false;
	public bool EnableRotate = false;

	public Vector3 moveDirection =Vector3.zero;
	private GameObject camera;
	public Vector3 CameraPrevPos;
	public Vector3 CameraPrevOri;
	public Vector3 CameraNewPos;
	public Vector3 CameraNewOri;

	private Vector3 CameraPosDiff;
	private float  CameraAngleDiff;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("MainCamera");
		CameraNewPos = camera.transform.position;
		CameraNewOri = camera.transform.eulerAngles;
		CameraPrevPos = CameraNewPos;
		CameraPrevOri = CameraNewOri;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();	
		CameraNewPos = camera.transform.position;
		CameraNewOri = camera.transform.eulerAngles;
		
		CameraPosDiff = CameraNewPos - CameraPrevPos;
		float oldx = this.transform.position.x;
		float oldz = this.transform.position.z;
		float dx = CameraPosDiff.x;
		float dz = CameraPosDiff.z;
		CameraAngleDiff = Mathf.Atan2(dx,dz)* Mathf.Rad2Deg;
		float playerAngle = this.transform.eulerAngles.y;
		float theta =  CameraAngleDiff - playerAngle - 90; 

//		float newX = 
//		float 
		float NewAngle = playerAngle + theta/10;

		if(isPlayMode){
			if(EnableTranslate){
				moveDirection  =  new Vector3(CameraPosDiff.x,0,CameraPosDiff.z);
				moveDirection = transform.TransformDirection(moveDirection);
				if(moveDirection.magnitude > 1)
				{
					controller.Move(moveDirection);	
					this.gameObject.animation.Play("walk", PlayMode.StopAll);
				}
				else{
					this.gameObject.animation.Play("walk", PlayMode.StopAll);	
				}
			}
			else{
				moveDirection = Vector3.zero;
			}	
			if(EnableRotate)
			{
				if(true){
					this.transform.eulerAngles -= new Vector3(0,theta * Mathf.Deg2Rad,0);
				}
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
