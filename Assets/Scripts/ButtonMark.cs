using UnityEngine;
using System.Collections;

public class ButtonMark : MonoBehaviour {

	public GameObject globalGameObject;

	public int mark = 0;

	public void SetLevel()
	{
		globalGameObject.GetComponent<LevelManager>().clearCurrentLevel();
		globalGameObject.GetComponent<LevelManager>().setCurrentLevel(mark);
	}

}
