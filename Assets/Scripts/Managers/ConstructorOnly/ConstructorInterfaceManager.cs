using UnityEngine;
using UnityEngine.UI;

using System;
using System.Linq;
using System.Collections;

public class ConstructorInterfaceManager : MonoBehaviour
{
	public Button simpleModeButton;
	public Button hardModeButton;

	public Button sortingGameButton;
	public Button excessGameButton;
	public Button correlationGameButton;

	public InputField itemsCountInputField;
	public InputField groupsCountInputField;

	public GameObject scrollContentButton;

	public GameObject scrollGamesContent;
	public GameObject scrollLevelsContent;
	public GameObject scrollCategoriesContent;
	public GameObject scrollSpritesContent;

	public GameObject hardItemsSettingsContent;

	public Button angleIncButton;
	public Button angleDecButton;
	public InputField markInputField;
	public Button scaleIncButton;
	public Button scaleDecButton;
	public Button basketButton;
	public Button sortItemButton;
	public Button excessButton;
	public Button notExcessButton;

	private int SIMPLE_MODE = 0;
	private int MEDIUM_MODE = 1;
	private int HARD_MODE = 2;

	private int currentMode = 0;

	GameObject selectedItem = null;

	public GameObject currentGameButtonGameObject = null;
	public GameObject currentLevelButtonGameObject = null;
	public GameObject currentImgButtonGameObject = null;

	// Use this for initialization
	void Start()
	{
		SimpleModeButtonClicked();

		SortingGameButtonClicked();

		FillScrollContent(scrollGamesContent, PathManager.GamesDir, "game");

		FillScrollContent(scrollCategoriesContent, PathManager.imgDir, "category");
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SimpleModeButtonClicked()
	{
		currentMode = SIMPLE_MODE;
		simpleModeButton.interactable = false;
		hardModeButton.interactable = true;
		itemsCountInputField.gameObject.SetActive(true);
		groupsCountInputField.gameObject.SetActive(true);

		scrollCategoriesContent.SetActive(false);
		scrollSpritesContent.SetActive(false);
		hardItemsSettingsContent.SetActive(false);
	}

	public void HardModeButtonClicked()
	{
		currentMode = HARD_MODE;
		simpleModeButton.interactable = true;
		hardModeButton.interactable = false;
		itemsCountInputField.gameObject.SetActive(false);
		groupsCountInputField.gameObject.SetActive(false);

		scrollCategoriesContent.SetActive(true);
		scrollSpritesContent.SetActive(true);
		hardItemsSettingsContent.SetActive(true);
	}

	public void SortingGameButtonClicked()
	{
		sortingGameButton.interactable = false;
		excessGameButton.interactable = true;
		correlationGameButton.interactable = true;

		basketButton.gameObject.SetActive(true);
		sortItemButton.gameObject.SetActive(true);
		excessButton.gameObject.SetActive(false);
		notExcessButton.gameObject.SetActive(false);

		Component[] comps = itemsCountInputField.gameObject.GetComponentsInChildren<Text>();
		foreach (Text comp in comps)
		{
			if (comp.text != "") comp.text = "Количество сортируемых объектов";
		}

		Component[] compsGr = groupsCountInputField.gameObject.GetComponentsInChildren<Text>();
		foreach (Text comp in compsGr)
		{
			if (comp.text != "") comp.text = "Количество групп";
		}
	}

	public void ExcessGameButtonClicked()
	{
		sortingGameButton.interactable = true;
		excessGameButton.interactable = false;
		correlationGameButton.interactable = true;
		notExcessButton.gameObject.SetActive(true);

		basketButton.gameObject.SetActive(false);
		sortItemButton.gameObject.SetActive(false);
		excessButton.gameObject.SetActive(true);

		Component[] comps = itemsCountInputField.gameObject.GetComponentsInChildren<Text>();
		foreach (Text comp in comps)
		{
			if (comp.text != "") comp.text = "Количество объектов";
		}

		Component[] compsGr = groupsCountInputField.gameObject.GetComponentsInChildren<Text>();
		foreach (Text comp in compsGr)
		{
			if (comp.text != "")
			{
				comp.text = "Количество лишних";
			}
		}
	}

	public void CorrelationGameButtonClicked()
	{
		sortingGameButton.interactable = true;
		excessGameButton.interactable = true;
		correlationGameButton.interactable = false;

		basketButton.gameObject.SetActive(false);
		sortItemButton.gameObject.SetActive(false);
		excessButton.gameObject.SetActive(false);
		notExcessButton.gameObject.SetActive(false);

		Component[] comps = itemsCountInputField.gameObject.GetComponentsInChildren<Text>();
		foreach (Text comp in comps)
		{
			if (comp.text != "")
			{
				comp.text = "Количество объектов";
			}
		}
		Component[] compsGr = groupsCountInputField.gameObject.GetComponentsInChildren<Text>();
		foreach (Text comp in compsGr)
		{
			if (comp.text != "")
			{
				comp.text = "Колличество групп";
			}
		}
	}

	public void SetSelectedItem(GameObject selectedItem)
	{
		this.selectedItem = selectedItem;

		markInputField.text = selectedItem.GetComponent<Item>().GetMark();

		basketButton.interactable = selectedItem.GetComponent<Item>().GetItemType() != "basket";

		sortItemButton.interactable = selectedItem.GetComponent<Item>().GetItemType() != "sort_item";

		excessButton.interactable = selectedItem.GetComponent<Item>().GetMark() != "excess";
		notExcessButton.interactable = selectedItem.GetComponent<Item>().GetMark() == "excess";
	}

	public void AngleIncButtonClicked()
	{
		if (!selectedItem) return;
		selectedItem.GetComponent<Item>().Rotate(10);
	}

	public void AngleDecButtonClicked()
	{
		if (!selectedItem) return;
		selectedItem.GetComponent<Item>().Rotate(-10);
	}

	public void ScaleIncButtonClicked()
	{
		if (!selectedItem) return;
		selectedItem.GetComponent<Item>().DecScale(5);
	}

	public void ScaleDecButtonClicked()
	{
		if (!selectedItem) return;
		if (selectedItem.GetComponent<Item>().GetScale() > 5)
		{
			selectedItem.GetComponent<Item>().DecScale(-5);
		}
	}

	public void MarkInputFieldChanged()
	{
		if (!selectedItem) return;
		selectedItem.GetComponent<Item>().SetMark(markInputField.text);
	}

	public void BasketButtonCkicked()
	{
		if (!selectedItem) return;

		basketButton.interactable = !basketButton.interactable;
		sortItemButton.interactable = !basketButton.interactable;

		selectedItem.GetComponent<Item>().SetType("basket");
	}

	public void SortItemButtonClicked()
	{ 
		if (!selectedItem) return;

		sortItemButton.interactable = !sortItemButton.interactable;
		basketButton.interactable = !sortItemButton.interactable;

		selectedItem.GetComponent<Item>().SetType("sort_item");
	}

	public void ExcessButtonClicked()
	{		if (!selectedItem) return;

		excessButton.interactable = !excessButton.interactable;
		notExcessButton.interactable = !excessButton.interactable;
		selectedItem.GetComponent<Item>().SetMark("excess");
	}

	public void NotExcessButtonClicked()
	{ 
		if (!selectedItem) return;

		notExcessButton.interactable = !notExcessButton.interactable;
		excessButton.interactable = !notExcessButton.interactable;
		selectedItem.GetComponent<Item>().SetMark(selectedItem.GetComponent<Item>().GetCategory());
	}

	//С КНОПКИ СОХРАНЕНИЯ УРОВНЯ !
	//public void ()
	//{
		/*if (currentMode == SIMPLE_MODE)
		{
			if (itemsCountInputField.text == "" || groupsCountInputField.text == "") return;

			int itemsCount = Convert.ToInt32(itemsCountInputField.text);
			int groupsCount = Convert.ToInt32(groupsCountInputField.text);

			string levelType;
			if (!sortingButton.interactable) levelType = "sort_item";
			else if (!excessButton.interactable) levelType = "excess";
			else if (!correlationButton.interactable) levelType = "correlation";
			else return;

			gameObject.GetComponent<ConstructorManager>().SimpleModeGenerate(groupsCount, itemsCount, levelType);
		}
		else if (currentMode == HARD_MODE)
		{
			gameObject.GetComponent<ConstructorManager>().HardModeGenerate();
		}*/
	//}

	private void FillScrollContent(GameObject scrollContent, string sourceFolder, string scrollTypeString)
	{
		string[] paths;

		if (scrollTypeString == "image") paths = System.IO.Directory.GetFiles(sourceFolder, "*.png");
		else paths = System.IO.Directory.GetDirectories(sourceFolder);

		foreach (string path in paths)
		{
			GameObject currentButton = (GameObject)Instantiate(scrollContentButton, new Vector3(0, 0, 0), Quaternion.identity);
			currentButton.transform.SetParent(scrollContent.transform);

			if (scrollTypeString == "image") currentButton.GetComponentInChildren<Text>().text = "";
			else currentButton.GetComponentInChildren<Text>().text = PathManager.GetPathTail(path);

			currentButton.GetComponentInChildren<Text>().fontSize = 36;

			if (scrollTypeString == "image")
			{
				Item item = new Item();
				currentButton.AddComponent<ScrollContentButtonMark>().item = item;
				item.SetMark(PathManager.GetPathTail(sourceFolder));
				item.SetCategory(PathManager.GetPathTail(sourceFolder));
				item.SetImage(PathManager.GetPathTail(path));
				//currentButton.AddComponent<ScrollContentButtonMark>().folder = PathManager.GetPathTail(sourceFolder);
			}
			else currentButton.AddComponent<ScrollContentButtonMark>().folder = PathManager.GetPathTail(path);

			currentButton.GetComponent<ScrollContentButtonMark>().constructorIntarfaceManager = this;
			if (scrollTypeString == "game")
			{
				currentButton.GetComponent<Button>().onClick.AddListener(currentButton.GetComponent<ScrollContentButtonMark>().SetGame);
			}
			else if (scrollTypeString == "level")
			{
				currentButton.GetComponent<Button>().onClick.AddListener(currentButton.GetComponent<ScrollContentButtonMark>().SetLevel);
			}
			else if (scrollTypeString == "category")
			{
				currentButton.GetComponent<Button>().onClick.AddListener(currentButton.GetComponent<ScrollContentButtonMark>().SetImgFolder);
			}
			else if (scrollTypeString == "image")
			{
				currentButton.GetComponent<Image>().sprite = ItemFactory.LoadSprite(path);
				currentButton.GetComponent<Button>().onClick.AddListener(currentButton.GetComponent<ScrollContentButtonMark>().CreateSprite);
			}
		}
	}

	public void CreateSprite(Sprite sprite, Item item)
	{
		if (!sortingGameButton.interactable) item.SetType("sort_item");
		else if (!excessGameButton.interactable) item.SetType("excess");
		else if (!correlationGameButton.interactable) item.SetType("correlation");
		gameObject.GetComponent<ConstructorManager>().CreateItem(sprite, item);
	}

	private void ClearScrollContent(GameObject scrollContent)
	{ 
		Component[] comps = scrollContent.GetComponentsInChildren<Button>();

		foreach (Component comp in comps)
		{
			if (comp.gameObject.GetComponent<ScrollContentButtonMark>())
			{
				Destroy(comp.gameObject);
			}
		}
	}

	public void CreateLevel()
	{
		if (!currentGameButtonGameObject) return;
		gameObject.GetComponent<ConstructorManager>().CreateLevel(currentGameButtonGameObject.GetComponent<ScrollContentButtonMark>().folder, scrollLevelsContent.GetComponentsInChildren<Button>().Length);

		ClearScrollContent(scrollLevelsContent);
		FillScrollContent(scrollLevelsContent, PathManager.GetFullGameFolder(currentGameButtonGameObject.GetComponent<ScrollContentButtonMark>().folder), "level");
	}

	public void CreateGame()
	{ 
		gameObject.GetComponent<ConstructorManager>().CreateGame(scrollGamesContent.GetComponentsInChildren<Button>().Length);

		ClearScrollContent(scrollGamesContent);
		FillScrollContent(scrollGamesContent, PathManager.GamesDir, "game");
	}

	public void SetGame(ScrollContentButtonMark item)
	{
		if (currentGameButtonGameObject != null)
		{
			currentGameButtonGameObject.GetComponent<Button>().interactable = true;
		}
		currentGameButtonGameObject = item.gameObject;
		item.gameObject.GetComponent<Button>().interactable = false;

		ClearScrollContent(scrollLevelsContent);
		FillScrollContent(scrollLevelsContent, PathManager.GetFullGameFolder(item.folder), "level");
	}

	public void SetLevel(ScrollContentButtonMark item)
	{
		if (currentLevelButtonGameObject != null)
		{
			currentLevelButtonGameObject.GetComponent<Button>().interactable = true;
		}
		
		currentLevelButtonGameObject = item.gameObject;
		currentLevelButtonGameObject.GetComponent<Button>().interactable = false;
	}

	public void SetImgFolder(ScrollContentButtonMark item)
	{
		if (currentImgButtonGameObject != null)
		{
			currentImgButtonGameObject.GetComponent<Button>().interactable = true;
		}
		currentImgButtonGameObject = item.gameObject;
		currentImgButtonGameObject.GetComponent<Button>().interactable = false;
		ClearScrollContent(scrollSpritesContent);
		FillScrollContent(scrollSpritesContent, PathManager.GetFullImageFolder(item.folder), "image");
	}

	public void SaveLevel()
	{
		if (!currentGameButtonGameObject || !currentLevelButtonGameObject) return;
		string gameFolder = currentGameButtonGameObject.GetComponent<ScrollContentButtonMark>().folder;
		string levelFolder = currentLevelButtonGameObject.GetComponent<ScrollContentButtonMark>().folder;
		gameObject.GetComponent<ConstructorManager>().SaveLevel(gameFolder, levelFolder);
	}
}
