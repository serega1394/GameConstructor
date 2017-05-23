using UnityEngine;
using System.Collections;

public class MoveBehaviour : MonoBehaviour {

	private ArrayList listeners;

	Vector3 dist;
	float posX;
	float posY;
	Vector3 previousPosition = new Vector3(0,0,0);

	private bool dragLocked = false;

	void OnMouseDown()
	{
		previousPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		dist = Camera.main.WorldToScreenPoint(transform.position);
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
	}
	void OnMouseDrag()
	{
		if (!dragLocked)
		{
			Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
			transform.position = worldPos;
		}
	}
	void OnMouseUp()
	{
		previousPosition = transform.position;
		dragLocked = false;

	}
	public void SetPreviousPosition()
	{
		dragLocked = true;
		Debug.Log(previousPosition.x.ToString() + previousPosition.y.ToString());
		gameObject.transform.position = new Vector3(previousPosition.x, previousPosition.y, previousPosition.z);
	}

	public void addListener(MoveListener obj)
	{ 
		
	}
}
