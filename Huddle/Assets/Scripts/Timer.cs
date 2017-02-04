using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour {
	public float timeLimit;
	private Text timer; 
	public static int time;
	// Use this for initialization
	void Start () {
		timer = GameObject.Find ("Timer_Counter").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		timeLimit -= Time.deltaTime;
		time = (int)timeLimit;

		timer.text = timeLimit.ToString ("F0");

	}
}
