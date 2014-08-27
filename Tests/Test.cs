using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Test : MonoBehaviour {
	public GameObject GO;
	public Mesh M;
	public bool Inst = false;
	public bool MeshTest = false;

	Vector3 Pos;
	Vector3 LastPos;
	Transform tGO;

	Vector3[] Vertices;
	Vector2[] UV;
	int[] Triangles;
	Vector4[] Tangents;
	Vector3[] Normals;


	void Start(){
		if(Inst){
			tGO = ((GameObject)Instantiate(GO, Vector3.zero, GO.transform.rotation)).transform;
			tGO.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		}
		if(MeshTest){
			Vertices = M.vertices;
			UV = M.uv;
			Triangles = M.triangles;
			Tangents = M.tangents;
			Normals = M.normals;
		}
	}

	void Update(){
		if(Inst){
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit) && hit.transform.tag != "Player")
			{
				Vector3 HitPos = hit.normal;
				HitPos.y = 0;
				HitPos.z /= 2f;
				HitPos.x /= 2f;
				Pos = RoundVector(hit.point + hit.normal);
				LastPos = RoundVector(hit.point + HitPos);
				Debug.DrawLine(LastPos, Pos, Color.green);
				tGO.position = LastPos;
			}
		}
		if (Input.GetKeyDown(KeyCode.L) && MeshTest) MeshChanger();
	}
	void MeshChanger(){
		Mesh NewMesh = new Mesh();
		NewMesh.vertices = Vertices;
		NewMesh.triangles = Triangles;
		NewMesh.tangents = Tangents;
		NewMesh.uv = UV;
		NewMesh.RecalculateBounds();
		NewMesh.RecalculateNormals();
		NewMesh.Optimize();
		AssetDatabase.CreateAsset(NewMesh, "Assets/Add/Asset/Mesh1.asset");

	}
	public void DrawBox(Vector3 Point){

	}
	public Vector3 RoundVector(Vector3 V){
		return new Vector3(Mathf.Round(V.x), Mathf.Floor(V.y + 0.5f) - 0.5f, Mathf.Round(V.z + 0.5f) - 0.5f);
	}
	public float Round(float r){
		if(r.ToString().Contains("."))return float.Parse(r.ToString().Split('.')[0]);
		return r;
	}
	void OnGUI(){
//		GUI.Label(new Rect(0,0,100,50), Pos.x + "\n" + Pos.y + "\n" + Pos.z);
		GUI.Box(new Rect(0,0,100,50), Pos.x + "\n" + Pos.y + "\n" + Pos.z);
		GUI.Box(new Rect(0,50,100,50), LastPos.x + "\n" + LastPos.y + "\n" + LastPos.z);
	}
}