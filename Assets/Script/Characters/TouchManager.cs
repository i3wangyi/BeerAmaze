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

public class TouchManager : TouchLogic 
{
	public TouchLogic[] touches2Manage;
	
	void OnTouchEndedAnywhere()
	{
		foreach(TouchLogic obj in touches2Manage)
			if(obj.touch2Watch > TouchLogic.currTouch)
				obj.touch2Watch--;
	}
}