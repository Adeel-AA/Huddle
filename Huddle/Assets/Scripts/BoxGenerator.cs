using UnityEngine;
using System.Collections;

public class BoxGenerator : MonoBehaviour {
	private int counter_red;
	private int counter_blue;
	private int counter_yellow;

	/*
	 * constructs the machine with 0 counts for the 
	 * */
	void Start() {
		counter_red = 0;
		counter_blue = 0;
		counter_yellow = 0;

	}

	// Use this for initialization
	/*
	 * waits for box to trigger action of stacking
	 * */
	void OnTriggerEnter2D (Collider2D Box) {
		if (Box.gameObject.layer == 13) {
			if (Box.transform.tag.Equals ("rBox")) {
				caseRed (Box);


			}
			else if  (Box.transform.tag.Equals ("yBox")){
				caseYellow(Box);


				}
			else if (Box.transform.tag.Equals ("bBox")) {
				caseBlue(Box);

					}
			
		}
			else {

						Debug.Log ("Not a valid object");
					}

	}
	/**
	 *  handles the generate condfition for the  red box case
	 * */
	private void caseRed(Collider2D box){
		
			if (counter_blue > 0 || counter_yellow > 0) {
				Debug.Log ("incorrect box !");
			} else {
				counter_red = counter_red + 1;
			box.gameObject.SetActive (false);
			}
		
	}
	/**
	 * handles the generate condition blue box case
	 * */
	private void caseBlue(Collider2D box){
			
				if (counter_red > 0 || counter_yellow > 0) {
					Debug.Log ("incorrect box");
				} 
				else {
					counter_blue = counter_blue + 1;
					box.gameObject.SetActive (false);
				}
			

	}
	/**
	 *  handles the generate condition for the yellow boxes
	 * */
	private void caseYellow(Collider2D box){
		
			if (counter_red > 0 || counter_blue > 0) {
				Debug.Log ("incorrect box!");
			} else {
				counter_yellow = counter_yellow + 1;
				box.gameObject.SetActive (false);
			}
		


	}
	/**
	 * generates big box from the scene and initates it near the machine
	 * */

	private void generateBox(string boxColor) {
		if (boxColor.Equals ("red")) {
			//former Vector3 = (0,0,0)
			GameObject box_r=	GameObject.Instantiate (Resources.Load("Objects/HBox_Red"), new Vector3 (10, 23, 0), Quaternion.identity) as GameObject ; // loads the resources for the box prefab located in resources
		
		} else if (boxColor.Equals ("blue")) {
			//former Vector3 = (2,0,0)
			GameObject box_b = GameObject.Instantiate (Resources.Load("Objects/HBox_Blue"), new Vector3 (10, 23, 0), Quaternion.identity) as GameObject ; // note the prefab must be in a seperate folder Resources.../dir


		} else if (boxColor.Equals ("yellow")) {
			//former Vector3 = (4,0,0)
			GameObject box_y = GameObject.Instantiate (Resources.Load("Objects/HBox_Yellow"), new Vector3 (10, 23, 0), Quaternion.identity) as GameObject ;

		} else {
			Debug.Log ("you hven't picked a proper color");
		}

	}

	/*
	 * updates to check if the counter of box stacking in the machine reached 3 counts so it can call generate Box and 
	 * initiate a box in the scene
	 * */
	void Update(){
		if (counter_red == 3){
			generateBox ("red");
			counter_red = 0;
		}
	else if (counter_blue ==3) {
			generateBox ("blue");
			counter_blue = 0;
	}
		else if (counter_yellow==3) {
			generateBox ("yellow");
			counter_yellow = 0;

	}

}
}