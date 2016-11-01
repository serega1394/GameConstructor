using UnityEngine;
using System.Collections;

public class ConstructorManager : MonoBehaviour {

	public Sprite[] sprites = new Sprite[15];

	public GameObject freeSprite;

	public GameObject sortItem;
	public GameObject basket;

	public GameObject groupBox;
	public GameObject basketBox;

	private ArrayList boxesCollection = new ArrayList();
	private ArrayList freeSpritesCollection = new ArrayList();
	private ArrayList levelElementsCollection = new ArrayList();

	private int boxesCount = 1;

	private int currentStep = 0;


	// Use this for initialization
	void Start () {
		//Debug.Log("ConstructorManagerStart");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/* TODO
	 * Создание панели со спрайтами
	 * */
	public void CreateSpritePanel()
	{
		// todo панель со скроллом
		GameObject currentFreeSprite;
		int x = -800;
		int y = 550		;
		for (int i = 0; i < 15; i++)
		{ 
			currentFreeSprite = (GameObject)Instantiate(freeSprite, new Vector3(x, y, 0), Quaternion.identity);
			currentFreeSprite.GetComponent<SpriteRenderer>().sprite = sprites[i];
			freeSpritesCollection.Add(currentFreeSprite);
			y -= 100;
			if (i == 11)
			{				x = 800;
				y = 550;
			}
		}




	}

	/* TODO
	 * Создание "ящиков" группировки объектов
	 * */
	public void CreateGroupBoxes(int boxesCount, bool basketFlag)
	{
		// todo в зависимости от желаемого количесва определять ширину и создавать "ящики"
		GameObject currentGropBox;
		int x = -500;
		for (int i = 0; i < boxesCount; i++)
		{
			currentGropBox = (GameObject)Instantiate(groupBox, new Vector3(x, 200, 0), Quaternion.identity);
			boxesCollection.Add(currentGropBox);
			currentGropBox.GetComponent<SortType>().sortType = i;

			if (basketFlag)
			{
				//todo ящик, куда класть корзину

				currentGropBox = (GameObject)Instantiate(basketBox, new Vector3(x, -400, 0), Quaternion.identity);
				boxesCollection.Add(currentGropBox);
				currentGropBox.GetComponent<SortType>().sortType = i;
			}

			x += 500;
		}
	}
	public void DestroyConstructor()
	{
		currentStep = 0;
		foreach (object element in boxesCollection)
		{
			Destroy((GameObject)element);
		}
		boxesCollection.Clear();

		foreach (object element in freeSpritesCollection)
		{
			Destroy((GameObject)element);
		}
		freeSpritesCollection.Clear();

		/*foreach (object element in levelElementsCollection)
		{
			Destroy((GameObject)element);
		}
		levelElementsCollection.Clear();*/

		/*ItemMoveDuplicate[] itemMoveDuplicateObjects = FindObjectsOfType<ItemMoveDuplicate>();
		foreach (ItemMoveDuplicate obj in itemMoveDuplicateObjects) Destroy(obj.gameObject);*/

		ItemMove[] itemMoveObjects = FindObjectsOfType<ItemMove>();
		foreach (ItemMove obj in itemMoveObjects) Destroy(obj.gameObject);
	}

	public void lessGroupButtonClick()
	{
		if (GetComponent<GameManager>().currentMode != 0) return;

		if (boxesCount > 1) 
		{
			DestroyConstructor();
			boxesCount--;
			CreateSpritePanel();
			CreateGroupBoxes(boxesCount, true);
		}
	}

	public void moreGroupButtonClick()
	{
		if (GetComponent<GameManager>().currentMode != 0) return;

		if (boxesCount < 3)
		{
			DestroyConstructor();
			boxesCount++;
			CreateSpritePanel();
			CreateGroupBoxes(boxesCount, true);
		}
	}

	public void nextStep()
	{
		if (currentStep == 0)
		{
			foreach (object element in boxesCollection)
			{
				Destroy((GameObject)element);
			}
			boxesCollection.Clear();

			foreach (object element in freeSpritesCollection)
			{
				Destroy((GameObject)element);
			}
			freeSpritesCollection.Clear();

			ItemMove[] items = FindObjectsOfType<ItemMove>();
			foreach (ItemMove item in items)
			{
				GameObject currentItem;
				int itemSortType = getSortType(item.gameObject);

				if (itemSortType != -1)
				{
					if (onBasketPosition(item.gameObject))
					{
						currentItem = (GameObject)Instantiate(basket, item.gameObject.transform.position, Quaternion.identity);
						currentItem.GetComponent<SpriteRenderer>().sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
						currentItem.GetComponent<SortType>().sortType = itemSortType;
					}
					else if (onSortItemPosition(item.gameObject))
					{
						currentItem = (GameObject)Instantiate(sortItem, item.gameObject.transform.position, Quaternion.identity);
						currentItem.GetComponent<SpriteRenderer>().sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
						currentItem.GetComponent<SortType>().sortType = itemSortType;
					}
				}

				Destroy(item.gameObject);
			}


			currentStep++;
		}
		else if (currentStep == 1)
		{ 
			
		}
	}

	public void previousStep()
	{ 
	
	}

	private bool onBasketPosition(GameObject gobj)
	{
		return gobj.transform.position.y <= -220;
	}

	private bool onSortItemPosition(GameObject gobj)
	{
		return true;
	}
	private int getSortType(GameObject gobj)
	{
		float x = gobj.transform.position.x;

		if (x >= -700 && x <= -300) return 0;

		if (x >= -200 && x <= 200 && boxesCount > 1) return 1;

		if (x >= 300 && x <= 700 && boxesCount > 2) return 2;
		return -1;
	}
}
