using UnityEngine;
using System.Collections;

public class PositionManager : MonoBehaviour {

	static Vector2 constructorOffSet = new Vector2(3000f,0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static Vector3 RealPositon(Vector3 gamePosition, string type = "constructor")
	{
		Vector3 realPos = new Vector3();

		if (type == "constructor")
		{
			realPos.x = gamePosition.x + constructorOffSet.x;
			realPos.x = gamePosition.y + constructorOffSet.y;
		}

		return realPos;
	}

	//!!! Предполагается, что функция будет использоваться для позиций item-ов
	public static Vector3 GamePosition(Vector3 realPositon, string type = "constructor")
	{
		Vector3 gamePos = new Vector3();

		if (type == "constructor")
		{
			gamePos.x = realPositon.x - constructorOffSet.x;
			gamePos.y = realPositon.y - constructorOffSet.y;
		}

		return gamePos;
	}
}
