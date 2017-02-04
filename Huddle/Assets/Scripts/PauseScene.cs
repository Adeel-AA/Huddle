using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 *  update instead of set Active use local scale ...
 * */
public class PauseScene :MonoBehaviour  {
	private bool Pressed; // boolean to keep track of the button press or key trigger
	private static GameObject Settings; // the settings panel that contains the buttons
	private static GameObject backUi;//the ingame ui present
	// Use this for initialization
	/*
	* constructor initiates the pressed values false since no button is pressed and sets the setting to dissapear as it isn't required
	*/
	void Start () {
		Pressed = false;
		Settings = GameObject.Find ("Settings");

		backUi = GameObject.Find ("UI_INGAME");
		Settings.transform.localScale = new Vector3 (0, 0, 0);

	}
/*
* checks if the setting has been pressed if it is invoked then the game is paused and settings appear and the ingame ui dissapears
* the settings is a translucent panel so users will see the settings but they will not see the huddle count and the pause button
*/
	private  void settingsButton(){
		if (Pressed == false) {
			Time.timeScale = 0;
			Pressed = true;
			Settings.transform.localScale = new Vector3 (1, 1, 1);
			backUi.transform.localScale = new Vector3 (0, 0, 0);
		} else {
			Time.timeScale = 1;
			Pressed = false;
			Settings.transform.localScale = new Vector3 (0, 0, 0);
			backUi.transform.localScale = new Vector3 (1, 1, 1);


		}
	}

	public  void pressSettings () {
		Time.timeScale = 0;  // slows the game criplingly so it pauses
		Settings.transform.localScale = new Vector3 (1, 1, 1);
		backUi.transform.localScale = new Vector3 (0, 0, 0); // gets rid of the ingame ui 

	}
    /*
    * resumes game back to current state
    */
	public void Resume (){
		Settings.transform.localScale = new Vector3 (0, 0, 0); // gets rid of the settings panel 
		backUi.transform.localScale = new Vector3 (1,1,1); // brings back the ui for the game like pause button and huddle counter
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
				Settings.transform.localScale = new Vector3 (1, 1, 1);
				backUi.transform.localScale = new Vector3 (0, 0, 0);
			}
			else {
				Time.timeScale = 1; 
				Pressed = false;
				Settings.transform.localScale = new Vector3 (0, 0, 0);
				backUi.transform.localScale = new Vector3 (1, 1, 1);
			}
		}


	}
}
