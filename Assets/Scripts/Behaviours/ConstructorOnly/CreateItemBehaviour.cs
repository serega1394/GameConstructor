using UnityEngine;
using System.Collections;

public class CreateItemBehaviour : MonoBehaviour {

	private ArrayList listeners;

	private GameObject clone;

	void OnMouseDown()
	{
		clone = (GameObject)Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);

		clone.AddComponent<MoveBehaviour>();
		Destroy(clone.GetComponent<CreateItemBehaviour>());
	}

	void OnMouseUp()
	{
		//Destroy(clone.GetComponent<CreateItemBehaviour>());
	}

	public void addListener(Object obj)
	{
		
	}
}
