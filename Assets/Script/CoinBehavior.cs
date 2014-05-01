using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Coin collects and destory itself
//	void OnTriggerEnter()
//	{
//		Destroy(this);
//	}

	public void delete()
	{
		Destroy(this.gameObject);
	}

}
