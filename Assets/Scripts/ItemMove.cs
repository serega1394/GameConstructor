using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemMove : MonoBehaviour {
	
	Vector3 dist;
	float posX;
	float posY;

	public string sortType;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{		dist = Camera.main.WorldToScreenPoint(transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
	}
	void OnMouseDrag()
	{
		Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
		transform.position = worldPos;
	}
	void OnCollisionEnter()
	{
		Debug.Log("Hit Somefing!");
	}
}
