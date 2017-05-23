using UnityEngine;
using System.Collections;

public class ClickedBehaviour : MonoBehaviour {

	private ArrayList listeners = new ArrayList();

	void OnMouseDown()
	{
		foreach (object listener in listeners)
		{
			((ClickedListener)listener).distributeClickedOnLevel(gameObject);
		}
	}

	public void addListener(ClickedListener obj)
	{
		listeners.Add(obj);
	}
}
