using UnityEngine;
using System.Collections;

public class ItemEditBehaviour : MonoBehaviour {

	Canvas canvas;

	public ConstructorManager constructorManager;
	public ConstructorInterfaceManager constructorInterfaceManager;

	public bool select = false;

	void OnMouseDown()
	{
		select = !select;

		if (select)
		{			constructorInterfaceManager.SetSelectedItem(gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

}