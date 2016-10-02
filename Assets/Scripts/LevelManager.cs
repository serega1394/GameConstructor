using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject basket;
	public GameObject sortItem;

	public Sprite[] sortItems = new Sprite[8];
	public Sprite[] baskets = new Sprite[2];
	
	public Vector3 mousePos = new Vector3();

	private GameObject currentSortItem;
	private GameObject currentBasket;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			currentBasket = (GameObject)Instantiate(basket, new Vector3(-400,-300,0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[0];

			currentBasket = (GameObject)Instantiate(basket, new Vector3(400,-300,0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[1];
		}
		else if(Input.GetKeyDown(KeyCode.KeypadEnter))
		{

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-500,300,0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[6];

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-400, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[3];

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-250, 150, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[7];

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(0, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[4];

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(250, 150, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[5];

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(0, 250, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[1];

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(500, 300, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[2];

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(400, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[0];

		}
	
	}
	void OnMouseDown()
	{
		/*
		//!!!For game constructor
		mousePos = Input.mousePosition;
		mousePos.Set(mousePos.x-700,mousePos.y-290,mousePos.z);
		
		Instantiate(sortItem, mousePos, Quaternion.identity);
		*/
		
		
	}
}
