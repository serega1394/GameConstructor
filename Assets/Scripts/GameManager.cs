using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject level;
	
	// Use this for initialization
	void Start () {
		//create level
		Instantiate(level, new Vector3(0,0,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
}
