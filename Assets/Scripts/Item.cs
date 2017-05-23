using UnityEngine;
using System.Collections;

using System;

public class Item : MonoBehaviour, ICloneable {

	private string image;
	private string category;
	private string mark;
	private string type;

	public void Rotate(int angle)
	{	
		gameObject.transform.Rotate(0, 0, angle);
	}

	public void SetCategory(string category)
	{
		this.category = category;
	}

	public void SetImage(string image)
	{
		this.image = image;
	}

	public void SetMark(string mark)
	{
		this.mark = mark;
	}

	public void SetPosition(Vector3 pos)
	{
		gameObject.transform.position = pos;
	}

	public void SetScale(int scale)
	{
		gameObject.transform.localScale = new Vector3(scale, scale, scale);
	}

	public void DecScale(int deltaScale)
	{
		int scale = (int)gameObject.transform.localScale.x + deltaScale;
		gameObject.transform.localScale = new Vector3(scale, scale, scale);
	}

	public void SetType(string type)
	{
		this.type = type;
	}

	public string GetCategory()
	{
		return category;
	}
	public int GetAngle()
	{
		return (int)gameObject.transform.rotation.z;
	}

	public string GetImage()
	{
		return image;
	}

	public string GetMark()
	{
		return mark;
	}

	public Vector3 GetPosition()
	{
		return gameObject.transform.position;
	}

	public int GetScale()
	{
		return (int)gameObject.transform.localScale.x;
	}

	public string GetItemType()
	{
		return type;
	}

	public string GetItemImage()
	{
		return image;
	}

	public object Clone()
	{
		Item clone = new Item();
		clone.image = this.image;
		clone.category = this.category;
		clone.mark = this.mark;
		clone.type = this.type;
		return clone;
	}

	public void SetAll(Item sourceItem)
	{ 
		this.image = sourceItem.image;
		this.category = sourceItem.category;
		this.mark = sourceItem.mark;
		this.type = sourceItem.type;
	}
}
