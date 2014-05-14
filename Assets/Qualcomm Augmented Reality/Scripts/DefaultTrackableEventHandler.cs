/*==============================================================================
Copyright (c) 2010-2013 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;
    
	public GameObject joyMove;
	public GameObject joyRotate;
	public GameObject FPV_camera;


    #endregion // PRIVATE_MEMBER_VARIABLES



    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

//		foreach(Transform t in AllChildren)
//		{
//			t.gameObject.renderer.enabled = true;
//			t.gameObject.SetActive(true);	
//		}

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

		UI.setPlayMode();
		Radar.isEnableRadar = true;
		joyMove.SetActive(true);
		joyRotate.SetActive(true);
		FPV_camera.camera.enabled = true;

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

//		foreach(Transform t in AllChildren)
//		{
//			t.gameObject.renderer.enabled = false;
//			t.gameObject.SetActive(false);	
//		}
//		GameObject.Find ("Ground").transform.renderer.enabled = false;
        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

		UI.resetPlayMode();
		Radar.isEnableRadar = false;
		if(joyMove != null )
			joyMove.SetActive(false);
		if(joyRotate!=null)
			joyRotate.SetActive(false);
		if(FPV_camera!=null)
			FPV_camera.camera.enabled = false;

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

    #endregion // PRIVATE_METHODS
}
