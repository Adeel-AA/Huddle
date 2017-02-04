using UnityEngine;
using System.Collections;

public class SheepBehave : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	private int maxDistance = 15; //gets set in editor
	public int speed = 0; //gets set in editor

	public float rotationSpeed=5;
	public float movementSpeed=4;
	public float rotationTime=7;}

	/*
	 * 
	 * 
	 * 
	 * void Start()
	{
		


	}

	void Update()
	{
		
		if (GetDistance(player1)<=maxDistance){
			
			MoveAway(player1);

		}

		else  {
			ChangeRotation ();
			WanderAround();
		}

		if (GetDistance (player2) <= maxDistance) {
			MoveAway (player2);

		} else {
			ChangeRotation ();
			WanderAround ();
		}

	}

	int GetDistance(GameObject player){
		int distance;
		distance = (int) Vector3.Distance (player.transform.position, transform.position);
		return distance;
	}



	Vector3 GetPosition(GameObject player)
	{
		return player.transform.position;
	}

	void MoveAway(GameObject player)
	{
		//Vector2 direction = transform.position - GetPosition (player);
		//direction.Normalize ();
		//transform.position = Vector2.MoveTowards (transform.position, direction * maxDistance, Time.deltaTime * speed); //There is no .MoveAway, for example
	}

	void WanderAround() {
		
		int x = Random.Range (-8, 25);
		int y = Random.Range (-8, 25);
		transform.position = new Vector2 (x, y);





	}

	void ChangeRotation() {
		if(Random.value > 0.5f)
		{
			movementSpeed = -movementSpeed;
		}

	}

}
*/


