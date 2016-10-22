using UnityEngine;
using System.Collections;

public class GroupBoxSpriteCollision : MonoBehaviour {

	public GameObject sortItem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("EEEEEEE");

		/*GameObject currentSortItem = (GameObject)Instantiate(sortItem, collision.gameObject.transform.position, Quaternion.identity);
		currentSortItem.GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;*/


		//Destroy(collision.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{ 
		Debug.Log("aaaaa");
	}
}
