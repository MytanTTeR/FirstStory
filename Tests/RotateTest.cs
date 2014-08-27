using UnityEngine;
using System.Collections;

public class RotateTest : MonoBehaviour {
	public GameObject GO;
	public float Angle;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(transform.position, (GO.transform.position-transform.position));
	
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit)){

			Quaternion Rotation = new Quaternion();
			Vector3 Axis = new Vector3();

			//По оси OY
//			Vector3 FromY = transform.up, ToY = Vector3.Exclude(hit.normal, FromY);
//			Angle = Vector3.Angle(FromY, ToY);
//			if(Vector3.Distance(FromY, hit.point) > (Vector3.Distance(ToY,hit.point))) Angle *=-1;
//			Quaternion Rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
//			Debug.DrawRay(transform.position, FromY*10, Color.red);
//			Debug.DrawRay(transform.position, ToY*10, Color.green);
//			if(Input.GetKey(KeyCode.Y))transform.rotation = Quaternion.RotateTowards(transform.rotation, Rotation, 0.5f);

			//По оси OZ
			Vector3 FromZ = transform.forward, ToZ = Vector3.Exclude(hit.normal, FromZ);
			Angle = Vector3.Angle(FromZ, ToZ);
			Axis = transform.right;
			if(Vector3.Distance(FromZ, hit.point) > (Vector3.Distance(ToZ,hit.point))) Angle *=-1;
			Rotation = Quaternion.AngleAxis(Angle, Axis);
//			Debug.DrawRay(transform.position, Axis*10, Color.black);
			Debug.DrawRay(transform.position, FromZ*10, Color.red);
			Debug.DrawRay(transform.position, ToZ*10, Color.green);
			if(Input.GetKey(KeyCode.Z))transform.rotation *= Quaternion.Lerp(Quaternion.identity, Rotation, 0.1f);

			//По оси OX
			Vector3 FromX = transform.right, ToX = Vector3.Exclude(hit.normal, FromX);
			Angle = Vector3.Angle(FromX, ToX);
			Axis = transform.forward;
			if(Vector3.Distance(FromX, hit.point) > (Vector3.Distance(ToX,hit.point))) Angle *=-1;
			Rotation = Quaternion.AngleAxis(Angle, Axis);
//			Debug.DrawRay(transform.position, Axis*10, Color.black);
			Debug.DrawRay(transform.position, FromX*10, Color.red);
			Debug.DrawRay(transform.position, ToX*10, Color.green);
			if(Input.GetKey(KeyCode.X))transform.rotation *= Quaternion.Lerp(Quaternion.identity, Rotation, 0.1f);

	


		}
	}
}
