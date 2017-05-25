using UnityEngine;
using UnityEngine.UI;

using System;
using System.Linq;
using System.Collections;


public class ConstructorManager : MonoBehaviour {
	
	public GameObject freeSprite;

	private UnityEngine.Random random = new UnityEngine.Random();

	string currentGameFolder = "";
	string currenLevelFolder = "";
	string currentImgFolder = "";

	private GameObject selectedItem = null;

	private ConstructorInterfaceManager constructorInterfaceManager = null;

	void Start ()
	{
		constructorInterfaceManager = gameObject.GetComponent<ConstructorInterfaceManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SimpleModeGenerate(int groupsCount, int itemsCount, string levelType)
	{
		//CreateLevelJSON(PathManager.levelsDir + "level7\\levelsets.json", levelType, "", 5);

		/*int begin = 1;
		int end = itemsCount / grCount;

		string[] imgFolders = System.IO.Directory.GetDirectories(LevelManager.imgDir);
		string imgDirTail = GetPathTail(imgFolders[UnityEngine.Random.Range(0, imgFolders.GetLength(0)-1)]);

		/*string[] imgFolders = System.IO.Directory.GetDirectories(LevelManager.imgDir);
		int foldersCount = imgFolders.Length;

		int beginIndexFolder = 0;
		int endIndexFolder = foldersCount / grCount - 1;
		// Цикл по папкам (группам)
		for(int i = 0; i < grCount; i++)
		{
			// Остаток относим к последнему промежутку
			if (i == grCount - 1 && endIndexFolder < foldersCount - 1)
			{
				endIndexFolder = foldersCount - 1;
			}
			//Выбираем папку
			string currentImgDir = imgFolders[UnityEngine.Random.Range(beginIndexFolder, endIndexFolder)];
			string[] imgFilesItems = System.IO.Directory.GetFiles(currentImgDir, "*.png");
			int beginIndexFile = 0;
			int endIndexFile = imgFilesItems.Length / itemsCount - 1;
			for (int j = 0; j < itemsCount / grCount; j++)
			{
				// Остакток относим к последнему промежутку
				if (j == itemsCount / grCount - 1 && endIndexFile < imgFilesItems.Length - 1)
				{
					endIndexFile = imgFilesItems.Length - 1;
				}
				//Выбираем файлы
				string currentImgFile = imgFilesItems[UnityEngine.Random.Range(beginIndexFile, endIndexFile)];
				//string currentImgFile = imgFilesItems[UnityEngine.Random.Range(0, imgFilesItems.Length-1)];
				string path = LevelManager.levelsDir + "level7\\item" + (i+j).ToString() + ".json";
				CreateItemJSON(path, levelTypeString, GetPathTail(currentImgDir), GetPathTail(currentImgFile), GetRandomPosition());

				beginIndexFile += imgFilesItems.Length / (itemsCount / grCount);
				endIndexFile += imgFilesItems.Length / (itemsCount / grCount);
			}
			string[] imgFilesBaskets = System.IO.Directory.GetFiles(currentImgDir + "\\Basket", "*.png");
			string currentBasketFile = GetPathTail(imgFilesBaskets[UnityEngine.Random.Range(0, imgFilesBaskets.Length - 1)]);

			string pathBasket = LevelManager.levelsDir + "level7\\item" + (itemsCount + i + 1).ToString() + ".json";
			CreateItemJSON(pathBasket, "basket", GetPathTail(currentImgDir), GetPathTail(currentBasketFile), GetRandomPosition());

			beginIndexFolder += foldersCount / grCount;
			endIndexFolder += foldersCount / grCount;

		}*/

		string[] imgFolders = System.IO.Directory.GetDirectories(PathManager.imgDir);

		// Цикл по папкам (группам)
		for(int i = 0; i < groupsCount; i++)
		{
			//Выбираем уникальную папку
			int currentRandomFolderIndex = UnityEngine.Random.Range(0, imgFolders.Length - 1);
			string currentImgDir = String.Copy(imgFolders[currentRandomFolderIndex]);
			Debug.Log(currentImgDir);
			//Array.Clear(imgFolders, currentRandomFolderIndex, 1);

			string[] imgFilesItems = System.IO.Directory.GetFiles(currentImgDir, "*.png");
			for (int j = 0; j < itemsCount / groupsCount; j++)
			{
				//Выбираем файлы
				int currentRandomFileIndex = UnityEngine.Random.Range(0, imgFilesItems.Length - 1);
				while (imgFilesItems[currentRandomFileIndex] == null)
				{
					currentRandomFileIndex = UnityEngine.Random.Range(0, imgFilesItems.Length - 1);
				}

				string currentImgFile = String.Copy(imgFilesItems[currentRandomFileIndex]);

				Array.Clear(imgFilesItems, currentRandomFileIndex, 1);
				Debug.Log("Img: " + currentImgFile);
				string path = PathManager.levelsDir + "level7\\item" + (i+j).ToString() + ".json";
				CreateItemJSON(path, levelType, PathManager.GetPathTail(currentImgDir), PathManager.GetPathTail(currentImgFile), GetRandomPosition());
			}
			string[] imgFilesBaskets = System.IO.Directory.GetFiles(currentImgDir + "\\Basket", "*.png");
			string currentBasketFile = PathManager.GetPathTail(imgFilesBaskets[UnityEngine.Random.Range(0, imgFilesBaskets.Length - 1)]);

			Debug.Log("Basket: " + currentBasketFile);

			string pathBasket = PathManager.levelsDir + "level7\\item" + (itemsCount + i + 1).ToString() + ".json";
			CreateItemJSON(pathBasket, "basket", PathManager.GetPathTail(currentImgDir), PathManager.GetPathTail(currentBasketFile), GetRandomPosition());

		}
	}

	private void CreateItemJSON(string directory, string type, string mark, string sprite, Vector3 pos)
	{
		string itemJSON = "{\"type\":\"" + type + "\",\"mark\":\"" + mark + "\",\"pos\":[" + pos.x.ToString() + "," + pos.y.ToString() + "," + pos.z.ToString() + "],\"sprite\":\"" + sprite + "\"}";
 
		System.IO.File.WriteAllText(directory, itemJSON);
	}

	private Vector3 GetRandomPosition()
	{
		int x = 0, y = 0, z = 0;

		x = UnityEngine.Random.Range(-1100, 1100);
		y = UnityEngine.Random.Range(-500, 500);

		return new Vector3(x, y, z);
	}

	public void CreateItem(Sprite sprite, Item item)
	{
		GameObject itemGameObject = (GameObject)Instantiate(freeSprite, new Vector3(2800, 0, 0), Quaternion.identity);		itemGameObject.GetComponent<SpriteRenderer>().sprite = sprite;
		itemGameObject.AddComponent<PolygonCollider2D>();
		itemGameObject.AddComponent<MoveBehaviour>();
		itemGameObject.GetComponent<Item>().SetAll(item);

		itemGameObject.AddComponent<ItemEditBehaviour>().constructorManager = this;
		itemGameObject.GetComponent<ItemEditBehaviour>().constructorInterfaceManager = gameObject.GetComponent<ConstructorInterfaceManager>();
	}

	public void RemoveItem(GameObject item)
	{ 
		
	}

	public void CreateLevel(string gameFolder, int levelNumber)
	{
		string levelPath = PathManager.GetFullLevelFolder(gameFolder, levelNumber);
		System.IO.Directory.CreateDirectory(levelPath);
	}

	public void CreateGame(int gameNumber)
	{
		string gamePath = PathManager.GetFullGameFolder(gameNumber);
		System.IO.Directory.CreateDirectory(gamePath);
	}

	public void LoadLevelForEdit()
	{ 
		// TODO загрузить уровень в конструктор
	}

	//Чисто перегнать спрайты в JSON!!! никаких генераций
	public void SaveLevel(string gameFolder, string levelFolder)
	{
		string levelsetsJSON = JSONSaveController.CreateLevelsetsJSON("sort_items", "sort_item_none", 5, "");
		JSONSaveController.WriteJSON(levelsetsJSON, PathManager.GetLevelSetsPath(gameFolder, levelFolder));
		
		Item[] items = FindObjectsOfType<Item>();

		for (int i = 0; i < items.Length; i++)
		{
			string jsonStr = JSONSaveController.CreateJSON(items[i], true);

			string itemPath = PathManager.GetFullItemPath(gameFolder,levelFolder, i+1);

			JSONSaveController.WriteJSON(jsonStr, itemPath);
		}
	}

	public void RemoveGame()
	{ 
	
	}

	public void RemoveLevel()
	{ 
	
	}
}