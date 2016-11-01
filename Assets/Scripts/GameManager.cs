using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject level;

	/*TODO
	 * массив уровней
	 * */
	private GameObject levelGO;
	
	public GUITexture previousLevelButton;
	public GUITexture nextLevelButton;
	public int currentMode;

	
	// === ИНИЦИАЛИЗАЦИЯ ===
	void Start () {

		gameMode();

		/*TODO
		 * Создание всех уровней
		 * */
		//create level
		levelGO = (GameObject)Instantiate(level, new Vector3(0,0,0), Quaternion.identity);
		//levelGO.GetComponent<LevelManager>().setCurrentLevel(1);
	}

	void Update()
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
			if (currentMode == 1) levelGO.GetComponent<LevelManager>().setUpCurrentLevel();
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (currentMode == 1) levelGO.GetComponent<LevelManager>().setDownCurrenLevel();
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			currentModeChanged();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			GetComponent<ConstructorManager>().moreGroupButtonClick();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			GetComponent<ConstructorManager>().lessGroupButtonClick();
		}
	}

	//=== ПЕРЕКЛЮЧЕНИЕ УРОВНЕЙ ===
	public void previousLevelButtonClick()
	{
		if (currentMode == 1) levelGO.GetComponent<LevelManager>().setDownCurrenLevel();
		else if (currentMode == 0) GetComponent<ConstructorManager>().previousStep();
	}

	public void nextLevelButtonClick()
	{
		if (currentMode == 1) levelGO.GetComponent<LevelManager>().setUpCurrentLevel();
		else if (currentMode == 0) GetComponent<ConstructorManager>().nextStep();
	}

	//=== ПЕРЕКЛЮЧЕНИЯ РЕЖИМОВ КОНСТРУКТОР/ИГРА ===
	public void constructorMode()
	{
		currentMode = 0;
		levelGO.GetComponent<LevelManager>().clearCurrentLevel();

		GetComponent<ConstructorManager>().CreateSpritePanel();
		GetComponent<ConstructorManager>().CreateGroupBoxes(1, true);
	}

	public void gameMode()
	{
		currentMode = 1;
		GetComponent<ConstructorManager>().DestroyConstructor();
	}

	public void currentModeChanged()
	{		if (currentMode == 0) gameMode();
		else if (currentMode == 1) constructorMode();

	}
}
