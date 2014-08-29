using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour {

	public float SprintForce;
	public float StepLength;
	public MovementEffects[] Effects;
	bool Move = false;
	float timer = 0, _SprintForce = 1;

	void Update()
	{
//		if (CollisionFlags.CollidedBelow != 0) return;

		_SprintForce = IsSprint ? SprintForce : 1;

		Move = IsMove;

		if (IsStop) {
			timer = StepLength;
			NextStep();
		}

		if (Move && timer <= 0) 
		{
			timer = StepLength;
			NextStep ();
		}
		if (timer > 0) 
		{
			Effect ();
			timer -= Time.deltaTime * _SprintForce;
		}
	}

	bool IsMove
	{
		get {
			return Input.GetKey (KeyCode.W);
		}
	}

	bool IsSprint
	{
		get {
			return Input.GetKey (KeyCode.LeftShift);
		}
	}

	bool IsStop
	{
		get {
			return Input.GetKeyUp (KeyCode.W);
		}
	}

	void Effect()
	{
		float time = Time.deltaTime / timer;
		foreach (MovementEffects Effect in Effects) {
			Effect.Effect(time, _SprintForce, Move);
		}
	}

	void NextStep()
	{
		foreach (MovementEffects Effect in Effects) {
			Effect.NextStep();
		}
	}
}
