using UnityEngine;
using System.Collections;

public class CollisionBehaviour : MonoBehaviour {

	private ArrayList listeners = new ArrayList();

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Сообщить слушателям о коллизии
		foreach (object listener in listeners)
		{
			((CollisionListener)listener).distributeCollisionOnLevel(gameObject, collision.gameObject);
		}
	}

	public void addListener(CollisionListener obj)
	{
		listeners.Add(obj);
	}

}
