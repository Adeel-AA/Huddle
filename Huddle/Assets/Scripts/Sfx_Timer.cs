using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx_Timer : MonoBehaviour {
	public AudioSource audio;
	private float timer=0;
	private float timerMax=0;

	public float waitDuration_SFX;
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying) {
			if (WaitedForSeconds (waitDuration_SFX)) {
				audio.Play ();
				timer = 0;
				timerMax = 0;			

			}
		}
	}

	private bool WaitedForSeconds(float seconds){


		timerMax = seconds;

		timer += Time.deltaTime;

		if (timer >= timerMax)
		{
			return true; //max reached - waited x - seconds
		}

		return false;
	}


}
