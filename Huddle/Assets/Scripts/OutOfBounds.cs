using UnityEngine;
using System.Collections;
/*
* class in charge of watching sheep get out of the boundary it is attached to a box colider or a sensor which is trigger upon collision with object source
*/
public class OutOfBounds : MonoBehaviour {

	// Use this for initialization

    /*
    * method triggered when sheep object crosses over the borders it decreases the total sheep in the scene and kills the sheep object
    */
	void OnTriggerEnter2D(Collider2D Sheep) {
		if (Sheep.gameObject.layer == 10) {
			LevelComplete.sheep.Remove (Sheep.gameObject.transform.name);
			//Debug.Log ("Sheep have left bound goodbye!"+LevelComplete.sheep.Count+"left");
			Sheep.gameObject.SetActive (false);



		}

	}
}
