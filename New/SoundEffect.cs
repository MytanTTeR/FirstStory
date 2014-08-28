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

	public override void StartEffect()
	{
		base.StartEffect ();
		SoundID = 0;
	}
	
	public override void NextStep()
	{
		base.NextStep ();
		SoundID++;
		if (SoundID >= Steps.Length) SoundID = 0;
	}
	
	public override void Effects ()
	{
		Step ();
	}

	void Step ()
	{
		if (Sprint) Source.pitch = RunForce;
		else Source.pitch = 1;
		if (timer == StepLength) Source.PlayOneShot (Steps [SoundID]);
	}
}
