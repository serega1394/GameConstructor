using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject button;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
		GameObject currentButton = (GameObject)Instantiate(button, new Vector3(0, 100, 0), Quaternion.identity);
		currentButton.transform.SetParent(canvas.transform);
		currentButton.GetComponentInChildren<Text>().text = "Играть";
		currentButton.GetComponentInChildren<Text>().fontSize = 60;
		currentButton.GetComponent<Button>().onClick.AddListener(delegate
		{
			StartGame();

		});

		currentButton = (GameObject)Instantiate(button, new Vector3(0, 0, 0), Quaternion.identity);
		currentButton.transform.SetParent(canvas.transform);
		currentButton.GetComponentInChildren<Text>().text = "Выбор уровня";
		currentButton.GetComponentInChildren<Text>().fontSize = 60;


		currentButton = (GameObject)Instantiate(button, new Vector3(0, -100, 0), Quaternion.identity);
		currentButton.transform.SetParent(canvas.transform);
		currentButton.GetComponentInChildren<Text>().text = "Настройки";
		currentButton.GetComponentInChildren<Text>().fontSize = 60;

		currentButton = (GameObject)Instantiate(button, new Vector3(0, -200, 0), Quaternion.identity);
		currentButton.transform.SetParent(canvas.transform);
		currentButton.GetComponentInChildren<Text>().text = "Выйти";
		currentButton.GetComponentInChildren<Text>().fontSize = 60;
		currentButton.GetComponent<Button>().onClick.AddListener(delegate
		{
			Quit();
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void StartGame()
	{ 
		Debug.Log("!!!Button!!!");
		//SceneManager.LoadScene("GConstructor");
	}
}
