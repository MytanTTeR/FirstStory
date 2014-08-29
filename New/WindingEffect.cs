using UnityEngine;
using System.Collections;

public class WindingEffect : MovementEffects
{
	public Transform GO;

	public bool HorisontalWinding = true;
	public float HorisontalWindingForce;
	
	public bool VerticalWinding = true;
	public float VerticalWindingForce;

	bool StepRightLeg;
	Vector3 position;

	void Start()
	{
		position = GO.localPosition;
	}

	public override void Effect(float time, float SprintForce, bool Move)
	{
		Vector3 NewPos = GO.localPosition;
		float ChangesX = 0, ChangesY = 0;
		if (!Move) { 
			if (HorisontalWinding) ChangesX -= NewPos.x * time; 
			if (VerticalWinding) ChangesY += (position.y - NewPos.y) * time;
			StepRightLeg = true;
		}
		else {
			if (StepRightLeg) {
				if (HorisontalWinding) ChangesX += ( - HorisontalWindingForce + position.x - NewPos.x) * time;
				if (VerticalWinding) ChangesY += ( - VerticalWindingForce + position.y - NewPos.y) * time;
			}
			else {
				if (HorisontalWinding) ChangesX += (HorisontalWindingForce + position.x - NewPos.x) * time; 
				if (VerticalWinding) ChangesY += (VerticalWindingForce + position.y - NewPos.y) * time; 
			}
		}
		if (SprintForce != 0) {
			ChangesX /= SprintForce;
			ChangesY /= SprintForce;
		}
		NewPos += new Vector3 (ChangesX, ChangesY, 0);
		GO.localPosition = NewPos;
	}

	public override void NextStep()
	{
		if (StepRightLeg) StepRightLeg = false;
		else StepRightLeg = true;
	}

}
