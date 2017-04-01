using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
* class in charge of when the sheep escapes out of the pen
*/
public class Test : MonoBehaviour {



/*
* on collision with sheep it removes the sheep from the pen collection and decreases counter
*/
	void OnTriggerEnter2D(Collider2D Sheep) {
		

		if (Sheep.gameObject.layer==10) {
			for (int i = 0; i < SheepColide.namesToStrike.Count; i++) {
				if (SheepColide.namesToStrike [i].Equals (Sheep.gameObject.transform.name)) { // checks the alrady stored sheep object and compares it to the parameter 
					//Debug.Log ("sheep trying to escape!");
					SheepColide.sheepIn.Remove (Sheep); // removes the sheep object from the pen collection
					SheepColide.namesToStrike.Remove (Sheep.gameObject.transform.name); // removes the sheep from the names to watch out for collection
					SheepColide.count = SheepColide.count - 1; // decreases sheep count

	}
}
		}
	}
}
