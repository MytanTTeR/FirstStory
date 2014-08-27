using UnityEngine;
using System.Collections;

public class SystemPlayer : MonoBehaviour {
	public Transform WeaponPoint;
	public GameObject[] Blocks;
	public int ID;
	Vector3 Pos;
	public GameObject Chanks;
	public string Name;
	// Use this for initialization
	void Start () {
		ActivateItem(ID);
	}
	
	// Update is called once per frame
	void Update () {
		Select();
//		Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.blue);
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit) && hit.transform.tag != "Player")
			{
				int ASD = 0;
				Pos = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y + hit.normal.y - 1), Mathf.Round(hit.point.z));
				Debug.Log(Pos.x + " " + Pos.y + " " + Pos.z);
				Name = Mathf.Round(Pos.x/16f) + " " + 0 + " " + Mathf.Round(Pos.z/16f);

				Chanks = GameObject.Find(Name);
				Block Post = new Block(Pos, ID);
				Chanks.SendMessage("BlockAdd", Post);
			}
		}
		if(Input.GetMouseButtonDown(1)){
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit) && hit.transform.tag != "Player")
			{
				int ASD = 0;
				Pos = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y-1), Mathf.Round(hit.point.z));
				Debug.Log(Pos.x + " " + Pos.y + " " + Pos.z);
				Name = Mathf.Round(Pos.x/16f) + " " + 0 + " " + Mathf.Round(Pos.z/16f);
				
				Chanks = GameObject.Find(Name);
				Chanks.SendMessage("BlockRemove", Pos);
			}
		}
	}
	void ActivateItem(int ID)
	{
		this.ID = ID;
		for (int i = 0; i < Blocks.Length; i++) {
			if(i == ID) Blocks[i].SetActive(true);
			else Blocks[i].SetActive(false);
		}
	}
	void Select()
	{
		if (Input.GetKeyDown("0")) ActivateItem(0);
		else if (Input.GetKeyDown("1")) ActivateItem(1);
		else if (Input.GetKeyDown("2")) ActivateItem(2);
		else if (Input.GetKeyDown("3")) ActivateItem(3);
		else if (Input.GetKeyDown("4")) ActivateItem(4);
		else if (Input.GetKeyDown("5")) ActivateItem(5);
		else if (Input.GetKeyDown("6")) ActivateItem(6);
		else if (Input.GetKeyDown("7")) ActivateItem(7);
		else if (Input.GetKeyDown("8")) ActivateItem(8);
		else if (Input.GetKeyDown("9")) ActivateItem(9);
	}
}
