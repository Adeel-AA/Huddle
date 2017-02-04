using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
* class in charge of checking the winning condition of the game and checks if the player collected all the sheep in the pen
*/

public class LevelComplete : MonoBehaviour {
	private GameObject[] allObj; // dirty arrayList contains all the objects of the scene currently
	public static ArrayList sheep{get;set;} // all active sheep on scene needs to be static and public in order to be modified by other classes incase sheep escape game boundaries
	public static List <string> Boxes {get;set;}
	private int SceneType; // the theme type of the game 1 is sheep 2 is ware house ... etc
	public static int bigBoxCount {get;set;}
	private int score;// score for the level will have a default value untill we implement it...
	public int isTimed; // sets if the level is a timed one


	// Use this for initialization
	
	void Start () {
		
		allObj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		sheep = new ArrayList ();
		Boxes = new List <string> ();
		if (GameObject.FindGameObjectWithTag ("HrBox") != null) {
			addBoxesToArrayList ();
			SceneType = 2;
			bigBoxCount = Boxes.Count / 3; // big boxes is the winning condition of the game... since 3 boxes are required so we can just deduce the count
		} else {
			addSheepToArrayList ();
			SceneType = 1;
			bigBoxCount = 100;

		}
		score = 20;

	
	}
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
		Debug.Log (Boxes.Count);

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
	private void ScoreFlusher() {
		SavedState.CurrentScore =score.ToString();
		SavedState.FlushDataToSave (SceneManager.GetActiveScene ().name);

	}
	#endregion
	#region EvenManagers
	/*
	 * loads the next scene in the project build
	 * */
	private void SceneLoader(){
		int current = SceneManager.GetActiveScene ().buildIndex;
		current = current + 1;
		SceneManager.LoadScene (current);

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
			ScoreFlusher ();
			SceneLoader ();

		} else {
			Debug.Log ("Didn't CatchThemAll");
		}
	}

	private void winningConditionSheep() {
		if (isTimed == 0) {
			SheepDone ();
		} else if (isTimed == 1) {
			if (Timer.time == 0) {
				Debug.Log ("Try again");
				reloadScene ();

			} else {
				SheepDone ();
			}

		}


	}
	/**
	 * winning condition warehouse
	 * */
	private void winningConditionWareHouse() {
		if (Boxes.Count == 3) {
			if (Boxes [0].Equals (Boxes [1]) && Boxes [0].Equals (Boxes [2])) {
				Debug.Log ("finish the round !");

			} else if (Boxes.Count == 2) {
				Debug.Log ("two boxes left go on finish the round");
			}
			else {

				SceneLoader();


			}


		}


		else if (bigBoxCount==0) {
			ScoreFlusher ();
			SceneLoader();
			Debug.Log ("level has ended!");

		}

	}
	#endregion

	
	// Update is called once per frame
	/*
	* triggered every frame compares the sheep in the current scene to the sheep in the pen if theyre equal then user wins and level is progressed
	*/
	void Update () {
		
		if (SceneType == 1) {
			winningConditionSheep ();
		} 
		else if (SceneType == 2) {
			winningConditionWareHouse ();

		}
	}
			}

