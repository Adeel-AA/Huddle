using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour{
	public float timeLimit;
	private Text timer; 
	public static int time;
	public bool isTimed;
	// Use this for initialization
	void Start () {
		if (isTimed != false) {
			timer = GameObject.Find ("Timer_Counter").GetComponent<Text> ();
		} else {
			//Debug.Log ("not timed");
		}
	}
	
	// Update is called once per frame
	private void countDown (bool isTimed) {
		if (isTimed == true) {
			timeLimit -= Time.deltaTime;
			time = (int)timeLimit;
			timer.text = timeLimit.ToString ("F0");
			if (time == 0) {
				ChangeScene change = new ChangeScene();
				change.ReloadScene();

			}
		}

	}

	void Update () {
		countDown (isTimed);


	}
}
