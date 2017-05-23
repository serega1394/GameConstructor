using UnityEngine;
using System.Collections;

public class JSONSaveController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static string CreateJSON(Item item, bool constructorPos = false)
	{
		string jsonStr = "";

		string type = item.GetItemType();
		string mark = item.GetMark();
		Vector3 pos = item.GetPosition();
		Debug.Log("1)" + pos.x.ToString() + " " + pos.y.ToString());
		if (constructorPos) pos = PositionManager.GamePosition(pos);
		Debug.Log("2)" + pos.x.ToString() + " " + pos.y.ToString());
		string category = item.GetCategory();
		string sprite = item.GetItemImage();
		int angle = item.GetAngle();
		int scale = item.GetScale();

		jsonStr = "{\"type\":\"" + type + "\",\"mark\":\"" + mark + "\",\"pos\":[" + ((int)(pos.x)).ToString() + "," + ((int)(pos.y)).ToString() +
		                                                                                "," + pos.z.ToString() + "],\"category\":\"" +
		                                                                                category + "\",\"sprite\":\"" + sprite +
		                                                                                "\",\"angle\":" + angle.ToString() +
		                                                                                ",\"scale\":" + scale.ToString() + "}";
		return jsonStr;
	}

	public static string CreateLevelsetsJSON(string type, string winCondition, int points, string background)
	{ 
		string jsonStr  = "{\"type\":\"" + type + "\",\"win_condition\":\"" + winCondition + "\",\"points\":" + points.ToString() + ",\"background\":\"" + background +"\"}";

		return jsonStr;
	}

	public static bool WriteJSON(string jsonStr, string path)
	{
		bool success = false;

		System.IO.File.WriteAllText(path, jsonStr);

		return success;
	}
}
