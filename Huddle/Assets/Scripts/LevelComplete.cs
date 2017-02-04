using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*
* class in charge of checking the winning condition of the game and checks if the player collected all the sheep in the pen
*/

public class LevelComplete : MonoBehaviour {
	private GameObject[] allObj; // dirty arrayList contains all the objects of the scene currently
	public static ArrayList sheep{get;set;} // all active sheep on scene needs to be static and public in order to be modified by other classes incase sheep escape game boundaries
	// Use this for initialization
	
	void Start () {
		allObj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		sheep = new ArrayList ();
		addSheepToArrayList ();
	
	}
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

	private int getCountSheep(){
		return sheep.Count;
	}
		

	
	// Update is called once per frame
	/*
	* triggered every frame compares the sheep in the current scene to the sheep in the pen if theyre equal then user wins and level is progressed
	*/
	void Update () {
		if (sheep.Count == SheepColide.count) {
			int current = SceneManager.GetActiveScene ().buildIndex;
			current = current + 1;
			SceneManager.LoadScene (current);


		} else {
			Debug.Log ("didn't catch all the sheep");
		}
	}
			}

