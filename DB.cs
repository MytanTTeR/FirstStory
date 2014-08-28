using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BD {
	public int ID;
	public string Name;
	public Vector2[] UV;
	public BD (int ID, string Name, Vector2[] UV)
	{
		this.ID = ID;
		this.Name = Name;
		this.UV = UV;
	}
}

public class DB : MonoBehaviour {

	public BD[] Blocks = {
		new BD(0, "Stone", LoadUV("Stone")),
		new BD(1, "Brick", LoadUV("Brick")),
		new BD(2, "Earn", LoadUV("Earn")),
		new BD(3, "Grass", LoadUV("Grass")),
	};
	static Vector2[] LoadUV (string name)
	{
		string Pathf = "Assets/Add/Asset/UV/UV";
		return ((Mesh)(AssetSystem.Load(Pathf+name+".asset",typeof (Mesh)))).uv;
	}
}
