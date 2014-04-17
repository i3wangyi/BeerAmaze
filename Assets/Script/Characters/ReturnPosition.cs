using UnityEngine;
using System.Collections;

public class ReturnPosition : MonoBehaviour 
{
	private Vector3 currentPos;
	private Vector3 currentOri;

	private Vector3 previousPos;
	private Vector3 previousOri;

	private int counter = 0;


	// Use this for initialization
	void Start () 
	{
		currentPos = this.gameObject.transform.position;
		currentOri = this.gameObject.transform.eulerAngles;
		previousPos = currentPos;
		previousOri = currentOri;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (counter <= 20) 
		{
			counter++;	
		} 
		else 
		{
			previousPos = currentPos;
			previousOri = currentOri;
			counter = 0;
		}

		currentPos = this.gameObject.transform.position;
		currentOri = this.gameObject.transform.eulerAngles;
	}
	void OnTriggerEnter(Collider other)
	{
		this.gameObject.transform.position = previousPos;
		this.gameObject.transform.eulerAngles = previousOri;
		counter = 0;
	}
	void OnTriggerExit()
	{
		;
	}
}
