using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Control_sheep : MonoBehaviour {
	private Object[] playlist;
	public AudioSource current_Song;
	// Use this for initialization
	void Awake () {
		
		playlist = Resources.LoadAll ("Music_S", typeof(AudioClip));
		Debug.Log (playlist.Length);

		current_Song.clip = playlist [0] as AudioClip;


		
	}

	void start() {
		current_Song.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!current_Song.isPlaying) {
			nextTrackRandom ();
		}
	}

	private void nextTrackRandom() {
		current_Song.clip = playlist [Random.Range (0, playlist.Length)] as AudioClip;
		current_Song.Play();
	}
}
