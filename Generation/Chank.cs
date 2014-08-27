using UnityEngine;
using System;
using System.Collections.Generic;
[Serializable]
public class Block {
	public Vector3 Position;
	public int ID;
	public Block(Vector3 Position, int ID)
		{
			this.Position = Position;
			this.ID = ID;
		}
}
public class Chank : MonoBehaviour {
	public Mesh Cube;
	public List<Block> GM = new List<Block>();
	public List<Block> GMMap = new List<Block>();
	DB Dtb = new DB();
	public int Zero = 2;
	Vector3 Pos;

	float OffsetX = 850;
	float OffsetZ = 850;

	void Start () {
		Pos = transform.position;
		float minX= -8 + Pos.x, maxX = 8 + Pos.x, minZ = -8 + Pos.z, maxZ = 8 + Pos.z;
		for (float x = minX; x < maxX; x++) {
			for (float  z = minZ; z < maxZ; z++) {
				float y;
				y = PerlinY(x, z);
				if (y == 0){
					GM.Add(new Block(new Vector3(x,y,z), 1)); 
//					GM.Add(new Block(new Vector3(x,y+6,z), 1));
				}
				else if (PerlinY(x+1, z) == 0 || PerlinY(x-1, z) == 0 || PerlinY(x, z+1) == 0 || PerlinY(x, z-1) == 0 ) Walls(x,z);
			}
		}
		MeshCreation();
	}
	void BlockAdd(Block Cube){
		if(!GM.Contains(GM.Find(x => x.Position == Cube.Position)) && !GMMap.Contains(GMMap.Find(x => x.Position == Cube.Position)));
		{
			GMMap.Add(Cube);
			MeshCreation();
		}
	}
	void BlockRemove(Vector3 P){
//		if(GMMap.Contains(GMMap.Find(x => x.Position == P)));
//		{
			GMMap.Remove(GMMap.Find(x => x.Position == P));
			MeshCreation();
//		}
	}
	void Walls(float x, float z)
	{
		for (int i = 0; i < 7; i++) {
			GM.Add(new Block(new Vector3(x,i,z), 1));
		}
	}
	float PerlinY(float x, float z)
	{
		if (Mathf.Abs(x) <= 50 && Mathf.Abs(z) <= 50) return 0;
		float y = (float)(2*Mathf.Cos(20*Mathf.PerlinNoise((x + OffsetX)*0.005f,(z + OffsetZ)*0.005f) - Zero));
		y *= y;
		y = Mathf.Round(y);
		if (y != 0) {
			y = (float)(2*Mathf.Cos(20*Mathf.PerlinNoise((x - 368)*0.005f,(z - 500)*0.005f) - Zero));
			y *= y;
			y = Mathf.Round(y);
		}
		return y;
	}
	void MeshCreation(){
		List<Block> GMtemp = new List<Block>(GM);
		GMtemp.AddRange(GMMap);
		Mesh MainMesh = Cube;
		List<Vector3> Vertices = new List<Vector3>();
		List<Vector2> UV = new List<Vector2>();
		List<int> Triangles = new List<int>();
		List<Vector4> Tangents = new List<Vector4>();
		List<Vector3> Normals = new List<Vector3>();
		int TrianglesCount = 0;
		Vector3 Pos = transform.position;
		for (int i = 0; i < GMtemp.Count; i++) {
			foreach(int V in MainMesh.triangles)
			{
				Triangles.Add(V + TrianglesCount);
			}
			for (int g = 0; g < MainMesh.vertices.Length; g++) {
				Vertices.Add(MainMesh.vertices[g] - Pos + GMtemp[i].Position);
			}
			UV.AddRange(Dtb.Blocks[GMtemp[i].ID].UV);
			Normals.AddRange(MainMesh.normals);
			Tangents.AddRange(MainMesh.tangents);
			TrianglesCount += MainMesh.vertices.Length;
		}
		Mesh NewMesh = new Mesh();
		NewMesh.vertices = Vertices.ToArray();
		NewMesh.triangles = Triangles.ToArray();
		NewMesh.tangents = Tangents.ToArray();
		NewMesh.uv = UV.ToArray();
		NewMesh.RecalculateBounds();
		NewMesh.RecalculateNormals();
		NewMesh.Optimize();
		NewMesh.name = Pos.x/16 + " " + Pos.y + " " + Pos.z/16;
		gameObject.GetComponent<MeshFilter>().sharedMesh = NewMesh;
		gameObject.GetComponent<MeshCollider>().sharedMesh = NewMesh;
	}
	
}
