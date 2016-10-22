using UnityEngine;
using System.Collections;

public class ConstructorManager : MonoBehaviour {

	public Sprite[] sprites = new Sprite[15];

	public GameObject freeSprite;

	public GameObject groupBox;

	private ArrayList boxesCollection = new ArrayList();
	private ArrayList freeSpritesCollection = new ArrayList();
	private ArrayList levelElementsCollection = new ArrayList();

	private int boxesCount = 1;


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

		GameObject currentFreeSprite = (GameObject)Instantiate(freeSprite, new Vector3(-800, 300, 0), Quaternion.identity);
		currentFreeSprite.GetComponent<SpriteRenderer>().sprite = sprites[0];
		freeSpritesCollection.Add(currentFreeSprite);

		currentFreeSprite = (GameObject)Instantiate(freeSprite, new Vector3(-800, 200, 0), Quaternion.identity);
		currentFreeSprite.GetComponent<SpriteRenderer>().sprite = sprites[12];
		freeSpritesCollection.Add(currentFreeSprite);

		currentFreeSprite = (GameObject)Instantiate(freeSprite, new Vector3(-800, 100, 0), Quaternion.identity);
		currentFreeSprite.GetComponent<SpriteRenderer>().sprite = sprites[2];
		freeSpritesCollection.Add(currentFreeSprite);

		currentFreeSprite = (GameObject)Instantiate(freeSprite, new Vector3(-800, 0, 0), Quaternion.identity);
		currentFreeSprite.GetComponent<SpriteRenderer>().sprite = sprites[3];
		freeSpritesCollection.Add(currentFreeSprite);

		currentFreeSprite = (GameObject)Instantiate(freeSprite, new Vector3(-800, -100, 0), Quaternion.identity);
		currentFreeSprite.GetComponent<SpriteRenderer>().sprite = sprites[13];
		freeSpritesCollection.Add(currentFreeSprite);

		currentFreeSprite = (GameObject)Instantiate(freeSprite, new Vector3(-800, -200, 0), Quaternion.identity);
		currentFreeSprite.GetComponent<SpriteRenderer>().sprite = sprites[5];
		freeSpritesCollection.Add(currentFreeSprite);

		currentFreeSprite = (GameObject)Instantiate(freeSprite, new Vector3(-800, -300, 0), Quaternion.identity);
		currentFreeSprite.GetComponent<SpriteRenderer>().sprite = sprites[6];
		freeSpritesCollection.Add(currentFreeSprite);
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

				currentGropBox = (GameObject)Instantiate(groupBox, new Vector3(x, -550, 0), Quaternion.identity);
				boxesCollection.Add(currentGropBox);
				currentGropBox.GetComponent<SortType>().sortType = i;
			}

			x += 500;
		}
	}
	public void DestroyConstructor()
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

		foreach (object element in levelElementsCollection)
		{
			Destroy((GameObject)element);
		}
		levelElementsCollection.Clear();
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
}
