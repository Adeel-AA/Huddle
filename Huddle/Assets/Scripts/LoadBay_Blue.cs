using UnityEngine;
using System.Collections;

public class LoadBay_Blue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter2D(Collider2D box) {
		if (box.gameObject.tag.Equals ("HbBox")) {
			LevelComplete.bigBoxCount = LevelComplete.bigBoxCount - 1;
			box.gameObject.SetActive (false);
			Debug.Log ("Remaining Big Boxes to Complete Round" + LevelComplete.bigBoxCount);

		} else {
			Debug.Log ("wrong form of box entered in the parameter");

		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
