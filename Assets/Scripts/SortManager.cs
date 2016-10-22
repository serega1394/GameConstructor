using UnityEngine;
using System.Collections;

public class SortManager : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D sortCollision)
	{
		Debug.Log("HIT!!!");

		int basketSortType = gameObject.GetComponent<SortType>().sortType;
		int itemSortType = sortCollision.gameObject.GetComponent<SortType>().sortType;

		if (basketSortType == itemSortType)
		{
			Destroy(sortCollision.gameObject);
		}
	}
}
