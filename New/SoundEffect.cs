using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class SoundEffect : MovementEffects {

	public AudioClip[] Steps;
	AudioSource Source;
	int SoundID;

	void Start()
	{
		Source = GetComponent<AudioSource>() ;
	}
	
	public override void NextStep()
	{
		SoundID++;
		if (SoundID >= Steps.Length) SoundID = 0;
		Source.PlayOneShot (Steps [SoundID]);
	}


	public override void Effect(float time, float SprintForce, bool Move)
	{
		if (SprintForce != 0) Source.pitch = SprintForce;
		else Source.pitch = 1;
	}
}
