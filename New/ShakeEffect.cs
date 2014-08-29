using UnityEngine;
using System.Collections;

public class ShakeEffect : MovementEffects
{
	public Transform GO;
	public float ShakeForce;
	bool StepRightLeg;
	float rotationZ = 0;

	public override void Effect(float time, float SprintForce, bool Move)
	{
		if (!Move) StepRightLeg = true;
		float Changes = 0;
		if (!Move) Changes -= rotationZ * time; 
		else {
			if (StepRightLeg) Changes += (ShakeForce - rotationZ) * time; 
			else Changes += (- ShakeForce - rotationZ) * time; 
		}
		if (SprintForce != 0) Changes /= SprintForce;
		Vector3 Rotation = GO.localEulerAngles;
		rotationZ += Changes;
		Rotation.z = rotationZ;
		GO.localEulerAngles = Rotation;
	}

	public override void NextStep()
	{
		base.NextStep ();
		if (StepRightLeg) StepRightLeg = false;
		else StepRightLeg = true;
	}
}
