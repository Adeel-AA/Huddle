using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
/*
* class in charge of checking the winning condition of the game and checks if the player collected all the sheep in the pen
*/

public class LevelComplete : MonoBehaviour {
	private GameObject[] allObj; // dirty arrayList contains all the objects of the scene currently
	public static ArrayList sheep{get;set;} // all active sheep on scene needs to be static and public in order to be modified by other classes incase sheep escape game boundaries
	public static List <string> Boxes {get;set;}
	private int SceneType; // the theme type of the game 1 is sheep 2 is ware house ... etc
	public static int bigBoxCount;
	private Player player1;
	private Player player2; // haven't figured out multi profiles yet so just keeping this till i figure it out
	private SavedState saveGame;



	// Use this for initialization

	void Start () {
		saveGame = new SavedState ();
		player1 = new Player ("player 1");
		allObj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		sheep = new ArrayList ();
		Boxes = new List <string> ();
		if (GameObject.FindGameObjectWithTag ("bBox") != null) {
			addBoxesToArrayList ();
			SceneType = 2;
			bigBoxCount = Boxes.Count / 3; // big boxes is the winning condition of the game... since 3 boxes are required so we can just deduce the count
		} else {
			addSheepToArrayList ();
			SceneType = 1;
			bigBoxCount = 100;

		}

	}
	#region score manager
	private void Addscore () {
		int score = SheepColide.count * 5;
		player1.setScore (score);
	}

	private void flushScore() {
		saveGame.flushSave (player1.getName(), SceneManager.GetActiveScene().buildIndex, player1.getCurrentScore ());
	}
	#endregion
	#region ArrayList Operations
	/*
	* adds only the sheep object from the dirty arrayList which contains all the objects
	*/
	private void addSheepToArrayList(){
		for (int i=0;i<allObj.Length;i++){
			if (allObj [i].layer == 10) { // layer 10 is the game layer which all sheep reside together
				sheep.Add (allObj [i].gameObject.transform.name);
			}

		}


		}
	/*
	 * adds boxes in the warehouse theme to the arrayList
	 * */
	private void addBoxesToArrayList() {
		for (int i = 0; i < allObj.Length; i++) {
			if (allObj [i].layer == 13) {
				Boxes.Add (allObj [i].gameObject.transform.name);

			}

		}
		//Debug.Log (Boxes.Count);

	}
	/*
	 * gets the sheep count
	 * */
	private int getCountSheep(){
		return sheep.Count;
	}
	#endregion
	#region scoreManager
	/*
	 * adds the score to the game
	 * */

	#endregion
	#region EvenManagers
	/*
	 * loads the next scene in the project build
	 * */
	private void SceneLoader(){
		int current = SceneManager.GetActiveScene ().buildIndex;
		current = current + 1;
		try {SceneManager.LoadScene (current);} 
		catch (Exception e) {
			
		}

	}
	/*
	 * reloads the scene in the project build
	 * */
	private void reloadScene() {
		int curent = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (curent);


	}
	#endregion
	#region winning
	private void SheepDone() {
		if (sheep.Count == SheepColide.count) {
			flushScore ();
			SceneLoader ();

		} else {
			//Debug.Log ("Didn't CatchThemAll");
		}
	}

	private void winningConditionSheep() {
		
			
				SheepDone ();
			

		}



	/**
	 * winning condition warehouse
	 * */
	private void winningConditionWareHouse() {
		
		if (bigBoxCount==0) {
			flushScore();
			SceneLoader();
			//Debug.Log ("level has ended!");

		}

	}
	#endregion

	
	// Update is called once per frame
	/*
	* triggered every frame compares the sheep in the current scene to the sheep in the pen if theyre equal then user wins and level is progressed
	*/
	void Update () {
		Addscore ();

		if (SceneType == 1) {
			winningConditionSheep ();
		} 
		else if (SceneType == 2) {
			 
					winningConditionWareHouse (); //winning condition doesn't work someone familiar with the condition must pseudo code it ...
				
			}

		}
	}
			

