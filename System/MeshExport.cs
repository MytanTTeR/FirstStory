using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class MeshExport : MonoBehaviour {
	public List<GameObject> GM = new List<GameObject>();
	public enum Type {UV, Meshs};
	public Type Export = Type.Meshs ;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < GM.Count; i++) {
			Mesh NewMesh = new Mesh();
			if (Export == Type.Meshs) {
				Vector3 Size = GM[i].transform.localScale;
				Mesh MainMesh = GM[i].GetComponent<MeshFilter>().mesh;
				List<Vector3> NewVertices = new List<Vector3>();
				for (int g = 0; g < MainMesh.vertices.Length; g++) {
					NewVertices.Add(new Vector3(MainMesh.vertices[g].x*Size.x, MainMesh.vertices[g].y*Size.y, MainMesh.vertices[g].z*Size.z));
				}
	        	NewMesh.vertices = NewVertices.ToArray();
				NewMesh.triangles = MainMesh.triangles;
				NewMesh.tangents = MainMesh.tangents;
				NewMesh.Optimize();
				NewMesh.RecalculateBounds();
				AssetDatabase.CreateAsset(NewMesh, "Assets/Add/Asset/UV/" + GM[i].name + ".asset");
			}
			else{
				NewMesh = GM[i].GetComponent<MeshFilter>().sharedMesh;
				//Точки
				StreamWriter Str = new StreamWriter("Assets/Add/Asset/UV/New/"+ GM[i].name + "_Vertices.txt");
				for (int h = 0; h < NewMesh.vertices.Length; h++) {
					Str.Write(NewMesh.vertices[h].x + "," + NewMesh.vertices[h].y + "," + NewMesh.vertices[h].z + (h == NewMesh.vertices.Length-1 ? "" : " "));
				}
				Str.Close();
				//Точки
				Str = new StreamWriter("Assets/Add/Asset/UV/New/"+ GM[i].name + "_Triangles.txt");
				for (int h = 0; h < NewMesh.triangles.Length; h++) {
					Str.Write(NewMesh.triangles[h] + (h == NewMesh.triangles.Length-1 ? "" : " "));
				}
				Str.Close();
//				AssetDatabase.CreateAsset(NewMesh, "/Assets/Add/UV/" + GM[i].name + ".asset");
//				Vector2[] UV = GM[i].GetComponent<MeshFilter>().sharedMesh.uv;
//				StreamWriter Str = new StreamWriter("Assets/Add/Asset/UV/" + GM[i].name + ".txt");
//				Str.Write("{");
//				for (int k = 0; k < UV.Length; k++) {
//					Str.Write("{" + UV[k].x + ", " + UV[k].y + "}" + (k==UV.Length?"":", "));
//				}
//				Str.Write("}");
//				Str.Close();
			}

       		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
