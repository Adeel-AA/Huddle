using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigBoxesCount : MonoBehaviour {
	private Text counter;
	// Use this for initialization
	void Start () {
		counter = GameObject.Find ("Text (1)").GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = LevelComplete.bigBoxCount.ToString ();

	}
}
