using UnityEngine;
using System.Collections.Generic;

public class ChankCreation : MonoBehaviour {
	public GameObject Chank;
	public int Size;
	public GameObject Player;
	List<GameObject> Chanks = new List<GameObject>();
	Vector3 Pos;

	// Use this for initialization
	void Start () {
		float min=-Size/2, max=Size/2;
		for (float x = min; x <= max; x++) {
			for (float z = min; z <= max; z++) {
				GameObject GO = (GameObject) Instantiate(Chank, new Vector3(x*16,0,z*16), Quaternion.identity);
				GO.transform.parent = gameObject.transform;
				GO.name = (x) + " " + 0 + " " + (z);
				Chanks.Add(GO);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Pos = transform.position;
	}
}
