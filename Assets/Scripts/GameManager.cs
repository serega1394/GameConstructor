using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject level;
	private GameObject levelGO;
	public GUITexture previousLevelButton;
	public GUITexture nextLevelButton;

	
	// Use this for initialization
	void Start () {
		//create level
		levelGO = (GameObject)Instantiate(level, new Vector3(0,0,0), Quaternion.identity);
		//levelGO.GetComponent<LevelManager>().setCurrentLevel(1);
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		int count = Input.touchCount;

		for (int i = 0; i < count; i++)
		{
			Touch touch = Input.GetTouch(1);

			if (previousLevelButton.HitTest(touch.position))
			{
				levelGO.GetComponent<LevelManager>().setDownCurrenLevel();
			}

			if (nextLevelButton.HitTest(touch.position))
			{
				levelGO.GetComponent<LevelManager>().setUpCurrentLevel();
			}
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			levelGO.GetComponent<LevelManager>().setUpCurrentLevel();
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{ 
			levelGO.GetComponent<LevelManager>().setDownCurrenLevel();
		}
	}
	public void previousLevelButtonClick()
	{ 
		levelGO.GetComponent<LevelManager>().setDownCurrenLevel();
	}

	public void nextLevelButtonClick()
	{ 
		levelGO.GetComponent<LevelManager>().setUpCurrentLevel();
	}
}
