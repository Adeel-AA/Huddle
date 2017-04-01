using UnityEngine;
using System.Collections;
/*
* class in charge of music and sfx commands in the game
*/
public class MusicControl : MonoBehaviour {
	public AudioSource sfx; // sfx source 
	public AudioSource music; // music source
	// Use this for initialization
	void Start () {
	
	}


/*
* mutes or unmutes the sfx source
*/
	public void ToggleSfx() {
		if (sfx.mute == false) {
            sfx.mute=true;
            //Debug.Log("you've muted the sound effects");
		} else {
            sfx.mute = false;
           // Debug.Log("unmuted the sound effects");
		}
	}
/*
* mutes or unmutes the music source
*/
	public void ToggleMusic(){
		if (music.mute == false) {
			music.mute=true;
           // Debug.Log("you've muted the music");
		}
			else {
			music.mute= false;
            //Debug.Log("you've unmuted the music");
			}
		}
    /*
    * changes the volume of the music whether it is increase or decrease
    */
    public void EditVolumeMusic(double volume)
    {

        music.volume = music.volume + (float)volume; // value of volume is float so the parameter needs to be casted
    }
    /*
    * changes the volume of the sound effects wheter it is increased or decreased
    */
    public void EditVolumeSFX ( double volume)
    {
        sfx.volume = sfx.volume + (float)volume; // value of volume is float so the parameter needs to be casted


    }













    }


	
	// Update is called once per frame

