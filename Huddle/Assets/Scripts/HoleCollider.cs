using UnityEngine;
using System.Collections;

public class HoleCollider : MonoBehaviour {

	/*
    * method triggered when box object crosses over the boundary of a hole
    * it decreases the total boxes in the scene and kills the box object
    */
	void OnTriggerEnter2D(Collider2D box) {
		Debug.Log ("approached HOle");
		if (box.gameObject.layer == 13) {
			removal (box);
		} else if (box.gameObject.layer == 18) {
			box.gameObject.SetActive (false);
		}
}

	void removal(Collider2D box) {
		LevelComplete.Boxes.Remove (box.gameObject.transform.name); //TODO
		Debug.Log ("box is destroyed"+LevelComplete.Boxes.Count+"left"); //TODO
		box.gameObject.SetActive (false);
	}
}
