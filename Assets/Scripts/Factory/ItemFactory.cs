using UnityEngine;
using System.Collections;

public class ItemFactory : MonoBehaviour {

	public GameObject itemGameObj;
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public GameObject CreateItem(JSONController jsonController)
	{
		GameObject currentGameObject = (GameObject)Instantiate(itemGameObj, new Vector3(jsonController.pos[0], jsonController.pos[1], jsonController.pos[2]), Quaternion.identity);
		currentGameObject.GetComponent<SpriteRenderer>().sprite = LoadSprite(PathManager.GetFullImagePath(jsonController.sprite, jsonController.category));
		currentGameObject.AddComponent<PolygonCollider2D>();
		Item item = currentGameObject.GetComponent<Item>();
		item.SetMark(jsonController.mark);
		item.Rotate(jsonController.angle);
		item.SetScale(jsonController.scale);
		item.SetCategory(jsonController.category);
		item.SetType(jsonController.type);
		item.SetImage(jsonController.sprite);

		if (jsonController.type == "basket" || jsonController.type == "correlation") 	currentGameObject.AddComponent<BasketBehaviour>();

		if (jsonController.type == "sort_item" || jsonController.type == "correlation")
		{
			currentGameObject.AddComponent<MoveBehaviour>();
			currentGameObject.AddComponent<CollisionBehaviour>();
			currentGameObject.GetComponent<CollisionBehaviour>().addListener(levelManager);
			levelManager.itemsUntilWin++;
		}

		else if (jsonController.type == "excess" && jsonController.mark == "excess")
		{
			currentGameObject.AddComponent<ClickedBehaviour>().addListener(levelManager);
			levelManager.itemsUntilWin++;
		}

		return currentGameObject;
	}

	public static Sprite LoadSprite(string imagePath)
	{
		byte[] imgBytes = System.IO.File.ReadAllBytes(imagePath);

		Texture2D texture = new Texture2D(1,1);
		texture.LoadImage(imgBytes, false);
		return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
	}
}
