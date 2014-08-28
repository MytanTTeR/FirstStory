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
	
	void WindingHead ()
	{
		Vector3 NewPos = GO.localPosition;
		float X = Time.deltaTime / timer;
//		float Y = Time.deltaTime / (StepLength - timer);
		float ChangesX = 0, ChangesY = 0;
		if (!Step) { 
			if (HorisontalWinding) ChangesX -= NewPos.x * X; 
			if (VerticalWinding) ChangesY += (position.y - NewPos.y) * X;
		}
		else {
			if (StepRightLeg) {
				if (HorisontalWinding) ChangesX += ( - HorisontalWindingForce + position.x - NewPos.x) * X;
				if (VerticalWinding) ChangesY += ( - VerticalWindingForce + position.y - NewPos.y) * X;
			}
			else {
				if (HorisontalWinding) ChangesX += (HorisontalWindingForce + position.x - NewPos.x) * X; 
				if (VerticalWinding) ChangesY += (VerticalWindingForce + position.y - NewPos.y) * X; 
			}
		}
		if (Sprint) {
			ChangesX /= RunForce;
			ChangesY /= RunForce;
		}
		NewPos.x += ChangesX;
		NewPos.y += ChangesY;
		GO.localPosition = NewPos;
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
		base.Effects ();
		WindingHead ();
	}
}
