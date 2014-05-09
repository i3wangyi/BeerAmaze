using UnityEngine;
using System.Collections;
static public class Maze
{
	static public string mazeSelected;
}
public class MazeSelection : MonoBehaviour {
	private GameObject[] objArray;
	private Vector3[] startOri;
	private int it;
	private Vector2 startPos;
	private Vector2 endPos;
	private GameObject currentObj;
	private float countDown;
	private bool setTimer;
	private int mazeNum;
	// Use this for initialization
	void Start () {
		mazeNum = 1;
		objArray = new GameObject[mazeNum ];
		startOri = new Vector3[mazeNum ];
		objArray [0] = GameObject.Find ("maze6");
//		objArray [1] = GameObject.Find ("maze11");
		objArray [0].SetActive(true);
//		objArray [1].SetActive(false);
		for (int i = 0; i < mazeNum ; i++) {
			startOri[i] = objArray[i].transform.eulerAngles;
				}
		it = 0;
		currentObj = objArray [0];
		countDown = 10.0f;
		setTimer = false;

	}
	public void SetTimer1()
	{
		setTimer = true;
	}
	public void SetTimer2()
	{
		setTimer = false;
	}
	// Update is called once per frame
	void OnGUI(){
		GUI.skin.GetStyle ("Label").fontSize = 90;
		GUILayout.BeginArea (new Rect (Screen.width/2 - 300, Screen.height/2 - 500, 600, 1000));
		GUILayout.BeginVertical ("box");
		GUILayout.Label (countDown.ToString ());
		GUILayout.EndVertical ();
		GUILayout.EndArea ();
		}

	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
			if(Input.GetTouch(i).phase == TouchPhase.Began)
			{
				startPos = Input.GetTouch(i).position;
			}
			if(Input.GetTouch(i).phase == TouchPhase.Ended)
			{
				endPos = Input.GetTouch(i).position;
				if(endPos.x - startPos.x > 0)
				{
					objArray[it].SetActive(false);
					it = (it + 1) % mazeNum ;
					objArray[it].SetActive(true);
					currentObj = objArray[it];
					currentObj.transform.eulerAngles = startOri[it];
				}
				if(endPos.x - startPos.x < 0)
				{
					objArray[it].SetActive(false);
					if(it == 0)
						it = mazeNum - 1;
					else
						it --;
					objArray[it].SetActive(true);
					currentObj = objArray[it];
					currentObj.transform.eulerAngles = startOri[it];
				}
				if(Mathf.Abs(endPos.y - startPos.y) > 100)
				{
					Application.LoadLevel ("BeerAmaze");
				}
			}
		}
		if(countDown < 0)
		{
			Maze.mazeSelected = objArray[it].name;
			Application.LoadLevel ("BeerAmaze");
		}
		if (setTimer)
			countDown -= Time.deltaTime;
		currentObj.transform.Rotate (0, 10 * Time.deltaTime, 0);
	}
}
