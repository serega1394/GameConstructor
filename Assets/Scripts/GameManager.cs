using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject level;
	private GameObject levelGO;

	
	// Use this for initialization
	void Start () {
		//create level
		levelGO = (GameObject)Instantiate(level, new Vector3(0,0,0), Quaternion.identity);
		//levelGO.GetComponent<LevelManager>().setCurrentLevel(1);
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			levelGO.GetComponent<LevelManager>().setUpCurrentLevel();
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{ 
			levelGO.GetComponent<LevelManager>().setDownCurrenLevel();
		}
	}
}
