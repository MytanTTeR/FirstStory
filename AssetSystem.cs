//using UnityEditor;
using System.Collections;

public class AssetSystem {

	public static void Create(UnityEngine.Object Original, string Path)
	{
//		AssetDatabase.CreateAsset (Original, Path);
	}
	public static UnityEngine.Object Load (string Path, System.Type Type)
	{
		return new UnityEngine.Object();
//		return AssetDatabase.LoadAssetAtPath (Path, Type); 
	}
}
