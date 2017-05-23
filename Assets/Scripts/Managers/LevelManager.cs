using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour, CollisionListener, ClickedListener
{
	public Canvas canvas;

	private int levelNumber = 0;
	public int lastLevel = 0;

	public GameObject itemGameObj;

	public GameObject text;

	private ArrayList levelObjects = new ArrayList();

	private GameObject currentGameObject;

	public int itemsUntilWin;

	ItemFactory itemFactory = new ItemFactory();

	void Start()
	{
		// В том числе и для отображения уровеней в меню!
		lastLevel = GetLevelsCount();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void clearCurrentLevel()
	{
		foreach (object element in levelObjects)
		{
			Destroy((GameObject)element);
		}
		levelObjects.Clear();
	}

	public void setCurrentLevel(int newCurrentLevel)
	{
		itemsUntilWin = 0;

		clearCurrentLevel();

		levelNumber = newCurrentLevel;

		string currentLevelDir = PathManager.levelsDir + "\\level" + levelNumber.ToString();

		string jsonPathLevelsetsString = currentLevelDir + "\\levelsets.json";
		string jsonLevelsetsText = System.IO.File.ReadAllText(jsonPathLevelsetsString);

		JSONLevelsets jsonLevelsets = new JSONLevelsets();
		jsonLevelsets.Load(jsonLevelsetsText);

		string[] itemsFilenames = System.IO.Directory.GetFiles(currentLevelDir, "item*.json");

		foreach (string itemFile in itemsFilenames)
		{			string jsonText = System.IO.File.ReadAllText(itemFile);
			JSONController jsonController = new JSONController();
			jsonController.Load(jsonText);

			itemFactory.itemGameObj = itemGameObj;
			itemFactory.levelManager = this;
			currentGameObject = itemFactory.CreateItem(jsonController);

			if (currentGameObject != null) levelObjects.Add(currentGameObject);
		}
	}
	public void setUpCurrentLevel()
	{
		if (levelNumber < lastLevel) setCurrentLevel(++levelNumber);
		else setCurrentLevel(1);
	}

	public void setDownCurrenLevel()
	{
		if (levelNumber > 1) setCurrentLevel(--levelNumber);
	}

	public void distributeCollisionOnLevel(GameObject source, GameObject collision)
	{
		if (source.GetComponent<Item>().GetMark() == collision.GetComponent<Item>().GetMark() && collision.GetComponent<BasketBehaviour>() != null)
		{
			Destroy(source);
			itemsUntilWin--;
		}
		else
		{
			source.GetComponent<MoveBehaviour>().SetPreviousPosition();
		}

		Debug.Log(itemsUntilWin);
		if (itemsUntilWin == 0)
		{
			setUpCurrentLevel();
		}
	}
	public void distributeClickedOnLevel(GameObject obj)
	{
		Destroy(obj);

		itemsUntilWin--;
		Debug.Log(itemsUntilWin);
		if (itemsUntilWin == 0)
		{
			setUpCurrentLevel();
		}
	}

	public static int GetLevelsCount()
	{
		return System.IO.Directory.GetDirectories(PathManager.levelsDir).GetLength(0);
	}
}
