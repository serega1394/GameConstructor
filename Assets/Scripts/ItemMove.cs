using UnityEngine;
using System.Collections;

public class ItemMove : MonoBehaviour {

	public Vector3 mousePos = new Vector3();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDrag()
	{
		mousePos.Set(mousePos.x-700,mousePos.y-290,mousePos.z);
		transform.position = mousePos; //Quaternion.Euler(mousePos);
		mousePos = Input.mousePosition;
	}
}
