using UnityEngine;
using System.Collections;
using System.IO;

public class JSONLevelsets : MonoBehaviour
{

	public string type;
	public string win_condition;
	public int points;
	public string background;

	public void Load(string savedData)
	{
		JsonUtility.FromJsonOverwrite(savedData, this);
	}

	public static JSONLevelsets CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<JSONLevelsets>(jsonString);
	}
}
