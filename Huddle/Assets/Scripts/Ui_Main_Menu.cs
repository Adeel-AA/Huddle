using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/**
 * UI_referncer script for Main Menu
 * */
public class Ui_Main_Menu : MonoBehaviour {
	private Button play_button;//skip to current level
	private Button options_button; // go to options
	private Button quit_button; // Quit applications
	private Button tutorial_button; // go to tutorial
	private Button continue_button; // Go to Level Select
	private ChangeScene change; // Change Scene Object
	private static int current_Level =0 ; // the level to continue to 
	/*
	 * Intiatlize buttons and add onlcick actions to them
	 * */
	void Start () {
		InitializeButtonsScene ();
		change = gameObject.GetComponent <ChangeScene> ();
		setActionsToButtons ();
	}
	/**
	 * intitalizes the buttons int he scenes and fetches them ... method is specific to the scene 
	 * */
	private void InitializeButtonsScene() {
		play_button = GameObject.Find ("Play").GetComponent <Button> ();
		options_button = GameObject.Find ("Options").GetComponent <Button> ();
		quit_button = GameObject.Find ("Quit").GetComponent <Button> ();
		tutorial_button = GameObject.Find ("Tutorial").GetComponent <Button> ();
		continue_button = GameObject.Find ("Continue").GetComponent <Button> ();



	}
	/**
	 * sets the the onlcick actions to the buttons in the current scene
	 * */
	private void setActionsToButtons() {
		play_button.onClick.AddListener (() => change.ChangeSceneInt(current_Level));
		options_button.onClick.AddListener (() => change.ChangeToScene("Options"));
		quit_button.onClick.AddListener (() => change.QuitGame());
		tutorial_button.onClick.AddListener (() => change.ChangeToScene("Tutorial"));
		continue_button.onClick.AddListener (() => change.LevelSelect());

	}
	

}
