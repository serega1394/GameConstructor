using UnityEngine;
using System.Collections;

public class ItemMoveDuplicate : MonoBehaviour {

	Vector3 dist;
	float posX;
	float posY;
	GameObject clone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		dist = Camera.main.WorldToScreenPoint(transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;

		clone = (GameObject)Instantiate(gameObject, gameObject.transform.position, Quaternion.identity);
	}
	void OnMouseUp()
	{
		Destroy(clone.GetComponent<ItemMoveDuplicate>());
		clone.AddComponent<ItemMove>();
	}
	void OnMouseDrag()
	{
		Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
		clone.transform.position = worldPos;
	}
	void OnCollisionEnter()
	{
		Debug.Log("Hit Somefing!");
	}
}