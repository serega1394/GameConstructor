using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollContentButtonMark : MonoBehaviour {

	public ConstructorInterfaceManager constructorIntarfaceManager;

	public string folder = "";

	public Item item;

	public void SetGame()
	{
		constructorIntarfaceManager.SetGame(this);
	}
	public void SetLevel()
	{
		constructorIntarfaceManager.SetLevel(this);
	}
	public void SetImgFolder()
	{ 
		constructorIntarfaceManager.SetImgFolder(this);
	}

	public void CreateSprite()
	{
		constructorIntarfaceManager.CreateSprite(gameObject.GetComponent<Image>().sprite, (Item)item.Clone());
	}

}
