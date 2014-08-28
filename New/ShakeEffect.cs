using UnityEngine;
using System.Collections;

public class ShakeEffect : MovementEffects
{
	public Transform GO;
	public float ShakeForce;
	bool StepRightLeg;
	float rotationZ = 0;
	
	void ShakeHead ()
	{
		float X = Time.deltaTime / timer;
		float Changes = 0;
		if (!Step) Changes -= rotationZ * X; 
		else {
			if (StepRightLeg) Changes += (ShakeForce - rotationZ) * X; 
			else Changes += (- ShakeForce - rotationZ) * X; 
		}
		if (Sprint) Changes /= RunForce;
		Vector3 Rotation = GO.localEulerAngles;
		rotationZ += Changes;
		Rotation.z = rotationZ;
		GO.localEulerAngles = Rotation;
	}
	
	public override void StartEffect()
	{
		base.StartEffect ();
		StepRightLeg = true;
	}
	
	public override void NextStep()
	{
		base.NextStep ();
		if (StepRightLeg) StepRightLeg = false;
		else StepRightLeg = true;
	}
	
	public override void Effects ()
	{
		ShakeHead ();
	}
}
