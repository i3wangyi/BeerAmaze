/*/
* Script by Devin Curry
	* www.Devination.com
		* www.youtube.com/user/curryboy001
		* Please like and subscribe if you found my tutorials helpful :D
			* Google+ Community: https://plus.google.com/communities/108584850180626452949
				* Twitter: https://twitter.com/Devination3D
				* Facebook Page: https://www.facebook.com/unity3Dtutorialsbydevin
				/*/
using UnityEngine;
using System.Collections;

public class JoyStick : TouchLogic 
{
	public enum JoystickType {Movement, LookRotation, SkyColor};
	public JoystickType joystickType;
	public Transform player = null;
	public float playerSpeed = 10f, maxJoyDelta = 0.2f, rotateSpeed = 5.0f;
	private Vector3 oJoyPos, joyDelta;
	private Transform joyTrans = null;
	public CharacterController troller;
	public GameObject Character;

	private bool startTouch = false;
	public	float movespeed = 5.0f;
	private float startOri;

	public static bool FirstPV = false;
	public static bool ThirdPV = true;

	void Start () 
	{
		joyTrans = this.transform;
		oJoyPos = joyTrans.position;
		FirstPV = false;
		ThirdPV = true;
	}

	public static void SwitchView()
	{
		FirstPV = !FirstPV;
		ThirdPV = !ThirdPV;
	}

	void OnTouchBegan()
	{
		//Used so the joystick only pays attention to the touch that began on the joystick
		touch2Watch = TouchLogic.currTouch;
		startOri = player.eulerAngles.y;
	}
	
	void OnTouchMovedAnywhere()
	{
		if(TouchLogic.currTouch == touch2Watch)
		{
			//move the joystick
			joyTrans.position = MoveJoyStick();
			ApplyDeltaJoy();
		}
	}
	
	void OnTouchStayedAnywhere()
	{
		if(TouchLogic.currTouch == touch2Watch)
		{
			ApplyDeltaJoy();
		}
	}
	
	void OnTouchEndedAnywhere()
	{
		//the || condition is a failsafe so joystick never gets stuck with no fingers on screen
		if(TouchLogic.currTouch == touch2Watch || Input.touches.Length <= 0)
		{
			//move the joystick back to its orig position
			joyTrans.position = oJoyPos;
			touch2Watch = 64;
		}
	}
	
	void ApplyDeltaJoy()
	{
		Vector3 moveDirection = new Vector3(0,0,0);
		float Angle;
		float alpha;
		float A;

		switch(joystickType)
		{
		case JoystickType.Movement:
			if(FirstPV){
				Angle = Mathf.Atan2(joyDelta.x,joyDelta.z) * 180.0f / Mathf.PI;
				if(Angle >= -45 && Angle <= 45)
				{
					//up
					Vector3 forward = transform.TransformDirection(player.forward);
					//				moveDirection = new Vector3(0,0,movespeed);
					troller.Move(forward * movespeed/2);
				}
				if(Angle > 45 && Angle <= 135)
				{
					//right
					Vector3 right = transform.TransformDirection(player.right);
					//				moveDirection = new Vector3(0,0,movespeed);
					troller.Move(right * movespeed/2);
				}
				if(Angle > 135 || Angle <= -135)
				{
					//down
					Vector3 backward = transform.TransformDirection(player.forward);
					troller.Move( -backward *  movespeed/2);
				}
				if(Angle > -135  &&  Angle < -45)
				{
					//left
					Vector3 left = transform.TransformDirection(player.right);
					troller.Move( -left * movespeed/2);
				}
			}
			if(ThirdPV)
			{
				moveDirection  =  new Vector3(joyDelta.x,0, joyDelta.z);
				Angle = Mathf.Atan2(joyDelta.x,joyDelta.z) * Mathf.Rad2Deg;
				player.eulerAngles = new Vector3(player.eulerAngles.x, Angle, player.eulerAngles.z);
				moveDirection = transform.TransformDirection(moveDirection * movespeed);
				//characterTrasform.position = new Vector3(characterTrasform.position.x + joyDelta.x, characterTrasform.position.y,characterTrasform.position.z+joyDelta.z);
				troller.Move(moveDirection * 5);
			}
			Character.gameObject.animation.Play("walk", PlayMode.StopAll);
			
			break;
		case JoystickType.LookRotation:
			moveDirection = new Vector3(joyDelta.x, 0, joyDelta.z);

			if(FirstPV){
				alpha = startOri/(180.0f/Mathf.PI) ;
				Angle = Mathf.Atan2(joyDelta.x,joyDelta.z);
				
				A = Angle + alpha;
				if(A < 0)
				{
					A += Mathf.PI * 2;
				}
				else if(A > 2 * Mathf.PI){
					A -= Mathf.PI * 2;
				}
				if(Mathf.Sqrt(joyDelta.x * joyDelta.x + joyDelta.z * joyDelta.z) >= maxJoyDelta * 0.5 )
				{
					player.eulerAngles = new Vector3(player.eulerAngles.x, A*(180.0f/Mathf.PI), player.eulerAngles.z);	
				}
			}

			if(ThirdPV){
				moveDirection  =  new Vector3(joyDelta.x,0, joyDelta.z);
				Angle = Mathf.Atan2(joyDelta.x,joyDelta.z) * Mathf.Rad2Deg;
				if(Mathf.Sqrt(joyDelta.x * joyDelta.x + joyDelta.z * joyDelta.z) >= maxJoyDelta * 0.7 )
				{
					player.eulerAngles = new Vector3 (player.eulerAngles.x, Angle, player.eulerAngles.z);
				}
			}

			break;
		}
	}
	
	Vector3 MoveJoyStick()
	{
		//convert the touch position to a % of the screen to move our joystick
		float x = Input.GetTouch (touch2Watch).position.x / Screen.width,
		y = Input.GetTouch (touch2Watch).position.y / Screen.height;
		//combine the floats into a single Vector3 and limit the delta distance
		Vector3 position = new Vector3 (Mathf.Clamp(x, oJoyPos.x - maxJoyDelta, oJoyPos.x + maxJoyDelta),
		                                Mathf.Clamp(y, oJoyPos.y - maxJoyDelta, oJoyPos.y + maxJoyDelta), 0);//use Vector2.ClampMagnitude instead if you want a circular clamp instead of a square
		//joyDelta used for moving the player
//		joyDelta = new Vector3(position.x - oJoyPos.x, 0, position.y - oJoyPos.y).normalized;
		joyDelta = new Vector3(position.x - oJoyPos.x, 0, position.y - oJoyPos.y);
		//position used for moving the joystick
		return position;
	}
	
	void LateUpdate()
	{
		
	}
}