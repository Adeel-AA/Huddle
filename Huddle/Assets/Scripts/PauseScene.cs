using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PauseScene : MonoBehaviour {
	private bool Pressed; // boolean to keep track of the button press or key trigger
	public GameObject Settings; // the settings panel that contains the buttons
	public GameObject backUi;//the ingame ui present
	// Use this for initialization
	/*
	* constructor initiates the pressed values false since no button is pressed and sets the setting to dissapear as it isn't required
	*/
	void Start () {
		Pressed = false;
		Settings.SetActive(false);
	}
/*
* checks if the setting has been pressed if it is invoked then the game is paused and settings appear and the ingame ui dissapears
* the settings is a translucent panel so users will see the settings but they will not see the huddle count and the pause button
*/
	private void settingsButton(){
		if (Pressed == false) {
			Time.timeScale = 0;
			Pressed = true;
			Settings.SetActive(true);
			backUi.SetActive (false);
		} else {
			Time.timeScale = 1;
			Pressed = false;
			Settings.SetActive(false);
			backUi.SetActive (true);

		}
	}

	public void pressSettings () {
		Time.timeScale = 0;  // slows the game criplingly so it auses
		Settings.SetActive (true); // shows the settings panel
		backUi.SetActive (false); // gets rid of the ingame ui 

	}
    /*
    * resumes game back to current state
    */
	public void Resume (){
		Settings.SetActive (false); // gets rid of the settings panel 
		backUi.SetActive (true); // brings back the ui for the game like pause button and huddle counter
		Time.timeScale = 1; // brings game back to realtime speed

	}
	
	// Update is called once per frame
	/*
	* checks if the trigger button escape is pressed in order to bring up the settings this needs to run for every frame since user can press the key at any time
	*/
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Pressed == false){
			Time.timeScale = 0;
				Pressed = true; // since we pressed the escape key then it changes the boolean so that when escape is pressed again it goes back to game rather than stay in settings
				Settings.SetActive (true);
				backUi.SetActive (false);
			}
			else {
				Time.timeScale = 1; 
				Pressed = false;
				Settings.SetActive(false);
				backUi.SetActive(true);
			}
		}


	}
}
