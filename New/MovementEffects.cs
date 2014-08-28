using UnityEngine;
using System.Collections;

public class MovementEffects : MonoBehaviour {

	public float RunForce;
	public float StepLength;
	[HideInInspector]
	public bool Step = false;
	[HideInInspector]
	public float timer = 0;
	[HideInInspector]
	public bool Sprint;


	public virtual void StartEffect()
	{
		Step = true;
		timer = StepLength;
	}
	
	public virtual void StopEffect()
	{
		Step = false;
		timer = StepLength;
	}

	public virtual void NextStep()
	{
		timer = StepLength;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) Sprint = true;
		if (Input.GetKeyUp (KeyCode.LeftShift)) Sprint = false;
		if (Input.GetKeyDown (KeyCode.W)) StartEffect ();
		if (Input.GetKeyUp (KeyCode.W)) StopEffect ();
		if (Step && timer <= 0) NextStep();
		if (timer > 0) Effects();
		if (timer > 0) timer -= Time.deltaTime * (Sprint ? RunForce : 1f);
	}

	public virtual void Effects()
	{

	}
}