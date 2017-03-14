using UnityEngine;

using System.Collections;

using UnityEngine.UI;


/*
* class in charge of checking if sheep has entered the pen and updates the counter UI
*/
public class SheepColide : MonoBehaviour {

	 //

	public static ArrayList sheepIn{get;set;}// sheep registered in the array

	private Text counter;// UI element text the counter board

	public static ArrayList namesToStrike {get;set;} // sheep objects that shouldn't trigger the counter since they're alreay in the pen

	public static int count; // static counter whcih will be used to update text UI



	// Use this for initialization

/*
* constructor which creates a new empty arrayList of sheeps
*/

	void Start (){

		
		counter = GameObject.Find ("Text (1)").GetComponent <Text>();
		sheepIn = new ArrayList ();//array list for the sheep to store the once they're in

		namesToStrike = new ArrayList();

		count = 0;





	}
    /*
    * checks if the object that collided with a sensor is sheep and then increases sheep in counter by 1
    */
	void OnTriggerEnter2D(Collider2D Sheep) {

		bool strike=false;

		Debug.Log ("enter Collision");

		if (Sheep.gameObject.layer==10) { // layer 10 is where all sheep reside

			for (int i = 0; i < namesToStrike.Count; i++) {

				if (namesToStrike [i].Equals (Sheep.gameObject.transform.name)) { // checks if the object that collided with the sensor didnt collide with it before while inside the pen

					Debug.Log ("sheep don't register");

					strike = true;



				} 



					

			}

			if (strike == false) { // if the object is new and didn't exist it will declare new sheep

				Debug.Log ("new sheep came in");

				sheepIn.Add (Sheep); // adds te sheep to the pen 

				namesToStrike.Add (Sheep.gameObject.transform.name); // adds the sheep to the collection to make sure if the sheep triggeres the sensor from within the coutner again it will not register as a new sheeep

				SheepBehave behave = Sheep.GetComponent <SheepBehave> ();
				behave.isInPen = true;

				count++; // increases the count by 1 since new sheep came in



			} else {

				Debug.Log ("no sheep registry");



			}





		}

		}


/*
* runs every frame to amake sure that the huddle counter is being updated
*/
	void Update(){

		counter.text = count.ToString ();

	}







}





	// Update is called once per frame

	



