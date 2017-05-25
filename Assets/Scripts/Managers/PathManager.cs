using UnityEngine;
using System.Collections;

public class PathManager : MonoBehaviour {

	public static string GamesDir = "D:\\projects\\unity3d\\3\\GConstructor\\Assets\\JSON\\";
	public static string levelsDir = "D:\\projects\\unity3d\\3\\GConstructor\\Assets\\JSON\\Game1\\";
	public static string imgDir = "D:\\projects\\unity3d\\3\\GConstructor\\Assets\\Images\\";

	public static string GetPathTail(string path)
	{
		int beginIndex = path.LastIndexOf('\\') + 1;
		return path.Substring(beginIndex, path.Length - beginIndex);
	}

	public static string GetFullGameFolder(string gamePathTail)
	{
		return GamesDir + gamePathTail + "\\";
	}

	public static string GetFullLevelFolder(string gamePathTail, int levelNumber)
	{
		return GamesDir + gamePathTail + "\\level" + levelNumber.ToString();
	}

	public static string GetFullGameFolder(int gameNumber)
	{
		return GamesDir + "Game" + gameNumber.ToString();
	}

	public static string GetFullImageFolder(string imagePathTail)
	{
		return imgDir + imagePathTail;
	}

	public static string GetFullImagePath(string imagePathTail, string category)
	{
		return imgDir + category + "\\" + imagePathTail;
	}

	public static string GetFullItemPath(string game, string level, int itemIndex)
	{
		return GamesDir + game + "\\" + level + "\\" + "item" + itemIndex.ToString() + ".json";
	}

	public static string GetLevelSetsPath(string game, string level)
	{
		return GamesDir + game + "\\" + level + "\\" + "levelsets.json";
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
