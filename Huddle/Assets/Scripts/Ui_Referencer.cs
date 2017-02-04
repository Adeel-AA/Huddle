using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using System.IO;
using System;
/*
 * In charge of keeping track of ui buttons and setting the 
 * */
public class Ui_Referencer : MonoBehaviour {
	private Button pause;
	private PauseScene p;
	private Button resume;
	private Button restart;
	private Button Level_Select;
	private Button QuitToMainMenu;
	private ChangeScene change;
	private GameObject TutorialSprite;
	private int gameMode; //
	// Use this for initialization
	/*
	 * gets all the buttons from the scene and uses the change scene class and pause scene class in order to set actions for buttons
	 * 
	 * */
	void Start () {
		gameMode = gameModeSet ();
		TutorialSprite = pullTutorialSprite ();
		IntializeTutorialSprite ();
		fetchButtonsFromScene ();
		p = gameObject.GetComponent<PauseScene>();
		change = gameObject.GetComponent <ChangeScene> ();
		setAllReferencesToButtons ();

	}
	/*
	 * fetchest the relevant buttons from the scene that are related to the ingame ui and settings 
	 * */

	private void fetchButtonsFromScene(){
		pause = GameObject.FindGameObjectWithTag ("Pause").GetComponent<Button>();
		resume = GameObject.Find ("resume").GetComponent<Button>();
		restart = GameObject.Find ("restart").GetComponent<Button>();
		Level_Select = GameObject.Find ("Level_Select").GetComponent<Button>();
		QuitToMainMenu = GameObject.Find ("QuitMain").GetComponent<Button>();
	}
	/*
	 * tells the script what kind of game theme is the level on and associates that with an int and returns it
	 * */
	private int gameModeSet() {
		if (GameObject.Find ("Tutorial_Sprite_Shepard") != null) {
			return 0;


		} else {
			return 1;
		}
	}

	private GameObject pullTutorialSprite() {
		if (gameMode == 0) {
			return GameObject.Find ("Tutorial_Sprite_Shepard");

		} else {
			return null;
		}

	}

	private void IntializeTutorialSprite() {
		
		try {TutorialSprite.transform.localScale = new Vector2 (0, 0);}
		catch (NullReferenceException e) {
		}



	}

	private void popUpTutorialSprite(){
		TutorialSprite.transform.localScale = new Vector2 (1, 1);
	}
	/*
	 * sets the references a.k.a event listeners  to the specific buttons in the scene
	 * */
	private void setAllReferencesToButtons(){
		pause.onClick.AddListener (() => p.pressSettings());
		resume.onClick.AddListener (() => p.Resume());
		restart.onClick.AddListener (() => change.ReloadScene ());
		Level_Select.onClick.AddListener (() => change.LevelSelect ());
		QuitToMainMenu.onClick.AddListener (() => change.MainMenu ());



	}

	 
}