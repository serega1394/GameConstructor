using UnityEngine;
using System.Collections;
using System.IO;

public class JSONController : MonoBehaviour {

	public string type;
	public string mark;
	public int[] pos;
	public string category;
	public string sprite;
	public int angle;
	public int scale;

	public void Load(string savedData)
	{
		JsonUtility.FromJsonOverwrite(savedData, this);
	}

	public static JSONController CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<JSONController>(jsonString);
	}
}
