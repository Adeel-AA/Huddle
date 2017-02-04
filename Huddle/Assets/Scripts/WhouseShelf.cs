using UnityEngine;
using System.Collections;

public class WhouseShelf : MonoBehaviour {
	// edited by abe note keep variables private instead use the fetch object method to get objects from the active scene i wrote it for you down below
	/*
	 * ---forget this --->you still need to modify obsbox to fetch the object if you wana see how to instantiate an object refer to BoxGenerator script method ---generateBox--- you need to manually load it from resources
	 * Notes:
	 * your script just needed you to intialize GameObject because it was null 
	 * also your translate method needed to have the correct parameters it cannot be assigned by an equals operand
	 * */

	private BoxCollider2D sensor; //the collider itself
	// no need for obs box --review createbox method
	private Vector2 size; //holds the size of the collider
	private Vector2 centerPoint; //centre point of the collider
	private Vector2 worldPos; //used to produce the boundary objects

	//boudary fields- used to define boundary where a box may be produced
	private float top; //top
	private float btm; //bottom
	private float lft; //left
	private float rgt; // right

	// Use this for initialization
	void Start () {
		
		sensor = gameObject.GetComponent<BoxCollider2D>();
		size = sensor.size; //stores size
		centerPoint = new Vector2 (sensor.offset.x, sensor.offset.y); //gets centre point of the sensor
		worldPos = transform.TransformPoint (centerPoint); //contains the position. used to set up boundary fields

		//defines boundary fields relative to coordinates
		top = worldPos.y + (size.y / 2f);
		btm = worldPos.y - (size.y / 2f);
		lft = worldPos.x - (size.x / 2f);
		rgt = worldPos.x + (size.x / 2f);
	}
	private GameObject fetchObject (string nameofObject){
		GameObject objectToFind=GameObject.Find (nameofObject);
		return objectToFind;


	}
	// try to use trigger instead of collision itś less fiddly
	void OnCollisionEnter2D(BoxCollider2D player) {
		if (player.gameObject.layer == 15 || player.gameObject.layer == 16) {
			createBox ();
			Debug.Log ("create box");
		} else {
			Debug.Log ("a box was not created");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * Creates a box with a position within the range of the collider
	 */
	void createBox() {
		GameObject box;
		float x = getCoord(lft, rgt);
		float y = getCoord(btm, top);
		box=GameObject.Instantiate (Resources.Load("Objects/BoxObs"), new Vector3 (x, y, 0), Quaternion.identity) as GameObject ; // initiates a box from resources s
	}

	/**
	 * Finds a coordinate within the range provided
	 * Takes a minimum, and maximum, and returns a random number between them.
	 */
	private float getCoord(float min, float max) {
		float coord = Random.Range(min, max); 
		return coord;
	}
}
