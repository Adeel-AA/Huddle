using UnityEngine;
using System.Collections;
/*
* CamerFollow in charge of following the players and changing the camera zoom dynamically
*/
public class CameraFollow : MonoBehaviour {
	public Transform player1;
	public Transform player2;
	public float minSizeY = 5f;
	public Camera cam;

	void start () {
		cam.orthographicSize = 15;
	}
    /*
    * follows both players by drawing a middle vector and transforming the camera position alog that vector
    */
	void SetCameraPos() {
		Vector3 middle = (player1.position + player2.position) * 0.5f; // creates a middle vector

		transform.position = new Vector3( //transforms camera posiion along the middle vector
			middle.x,
			middle.y,
			transform.position.z
		);
	}



    /*
    * invokes the update method for every frame and follows the players for every frame
    */
	void Update() {
		cam.orthographicSize = 20;
		SetCameraPos();

	}
}