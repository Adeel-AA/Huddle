using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/*
 * Class Takes care of sheep behaviour
 * */

public class SheepBehave : MonoBehaviour {
	private List <GameObject> pathsAI; // list of paths an ai can go to aka sheep
	public int DistanceThreshold; // distance allowed for player and sheep before it reacts
	private GameObject player1; // player 1 
	private GameObject player2; // player 2 
	public float speed; // movement speed of the sheep
	/*
	 * intiatlizes the list and the players in the scene and set the intial speed and distance threshehold
	 * */
	void Start () {
		pathsAI = new List <GameObject> ();
		addSceneObjects ();
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		speed = (float) 5;
		DistanceThreshold = 10;
	}
	/*
	 * adds Path Objects related to the scene
	 * */
	private void addSceneObjects(){
		GameObject[] tmp = GameObject.FindGameObjectsWithTag ("Path");
		for (int i = 0; i < tmp.Length; i++) {
			pathsAI.Add (tmp [i]);

		}

	}
	/**
	 * Index Generator for the 
	 * */
	private int GenerateListIndex(){
		
		int random = UnityEngine.Random.Range (0, pathsAI.Count-1);
		return random;

	}
	/**
	 *  moves target towards a poisiton of another object
	 * */
	private void MoveTowardsObject(GameObject obj) {
		
		transform.position = Vector2.MoveTowards(transform.position, obj.transform.position,   speed*Time.smoothDeltaTime);
	}

	/**
	 * Generates a random Path to move towards for the sheep
	 * */
	private void RandomMovement() {
		int index = GenerateListIndex ();
		try {
			GameObject current = pathsAI [index];
			MoveTowardsObject (current);	
		
		}
		catch (ArgumentOutOfRangeException e){

			Debug.Log ("Winning Condition of the game");

		}



	}
	/*
	 * return a boolean to determine proximity of two objects
	 * */
	private bool isClose() {
		if (Vector2.Distance (transform.position, player1.transform.position) <=DistanceThreshold || Vector2.Distance (transform.position, player2.transform.position)<=DistanceThreshold) {
			Debug.Log ("Resume Normal Sheep Behaviour");
			return true;

		} else{
			return false;
		}

	}

	/**
	 * update function runs the proximity function and generates random movement for the atttached objects
	 * */
	void Update() {
		if (isClose() != true) {
			RandomMovement ();

		} else {
			Debug.Log ("Run Sheep Run!");
		}
	}
}


