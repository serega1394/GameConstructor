﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private int levelNumber = 0;
	private int lastLevel = 3;

	public GameObject basket;
	public GameObject sortItem;

	public Sprite[] sortItems = new Sprite[12];
	public Sprite[] baskets = new Sprite[3];
	
	public Vector3 mousePos = new Vector3();
	private ArrayList levelObjects = new ArrayList();

	private GameObject currentSortItem;
	private GameObject currentBasket;

	private bool firstFlag = true;
	
	// Use this for initialization
	void Start ()
	{
		//setCurrentLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
		
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
		clearCurrentLevel();

		levelNumber = newCurrentLevel;

		if (levelNumber == 1)
		{
			currentBasket = (GameObject)Instantiate(basket, new Vector3(-400, -300, 0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[0];
			currentBasket.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentBasket);

			currentBasket = (GameObject)Instantiate(basket, new Vector3(400, -300, 0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[1];
			currentBasket.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentBasket);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-500, 300, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[2];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-400, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[5];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-250, 150, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[5];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(0, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[2];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(250, 150, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[2];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(0, 250, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[5];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);
		}
		else if (levelNumber == 2)
		{
			currentBasket = (GameObject)Instantiate(basket, new Vector3(-400, -300, 0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[0];
			currentBasket.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentBasket);

			currentBasket = (GameObject)Instantiate(basket, new Vector3(400, -300, 0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[1];
			currentBasket.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentBasket);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-500, 300, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[6];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-400, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[3];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-250, 150, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[7];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(0, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[4];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(250, 150, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[5];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(0, 250, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[1];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(500, 300, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[2];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(400, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[0];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);
		}
		else if (levelNumber == 3)
		{
			currentBasket = (GameObject)Instantiate(basket, new Vector3(-400, -300, 0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[0];
			currentBasket.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentBasket);

			currentBasket = (GameObject)Instantiate(basket, new Vector3(400, -300, 0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[1];
			currentBasket.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentBasket);

			currentBasket = (GameObject)Instantiate(basket, new Vector3(0, -300, 0), Quaternion.identity);
			currentBasket.GetComponent<SpriteRenderer>().sprite = baskets[2];
			currentBasket.GetComponent<SortType>().sortType = 2;
			levelObjects.Add(currentBasket);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-500, 300, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[6];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-400, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[3];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-250, 150, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[7];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(0, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[4];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(250, 150, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[5];
			currentSortItem.GetComponent<SortType>().sortType = 1;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(0, 250, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[1];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(500, 300, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[2];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(400, 0, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[0];
			currentSortItem.GetComponent<SortType>().sortType = 0;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(155, 30, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[9];
			currentSortItem.GetComponent<SortType>().sortType = 2;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-300, 300, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[10];
			currentSortItem.GetComponent<SortType>().sortType = 2;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(230, 280, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[11];
			currentSortItem.GetComponent<SortType>().sortType = 2;
			levelObjects.Add(currentSortItem);

			currentSortItem = (GameObject)Instantiate(sortItem, new Vector3(-150, -80, 0), Quaternion.identity);
			currentSortItem.GetComponent<SpriteRenderer>().sprite = sortItems[8];
			currentSortItem.GetComponent<SortType>().sortType = 2;
			levelObjects.Add(currentSortItem);
		}
	}
	public void setUpCurrentLevel()
	{
		if (levelNumber < lastLevel) setCurrentLevel(++levelNumber);
	}

	public void setDownCurrenLevel()
	{ 
		if (levelNumber > 1) setCurrentLevel(--levelNumber);
	}
	 
	void OnMouseDown()
	{
		/*if (firstFlag)
		{
			setCurrentLevel(1);
			firstFlag = false;
		}
		setUpCurrentLevel();*/
	}

	//
	void ControlProgress()
	{ 
		
	}
}
