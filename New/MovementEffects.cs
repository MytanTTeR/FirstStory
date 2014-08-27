using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class MovementEffects : MonoBehaviour {

	public Transform PlayerHead;
	public float ShakeForce;
	public float RunForce;
	public float StepLength;
	bool StepRightLeg = true;
	bool Step = true;

	void Update ()
	{
		ShakeHead ();
	}

	void ShakeHead ()
	{
		Vector3 Rotation = PlayerHead.localEulerAngles;
		if (!Step) Rotation.z += Mathf.Lerp (Rotation.z, 0, StepLength);
		else {
			if (StepRightLeg) Rotation.z += Mathf.Lerp (Rotation.z, ShakeForce, StepLength*Time.deltaTime);
			else Rotation.z += Mathf.Lerp (Rotation.z, ShakeForce, StepLength);
		}
		PlayerHead.localEulerAngles = Rotation;
	}
}
