using UnityEngine;
using System.Collections;
using System;

public class Player2Script : MonoBehaviour
{

    public Vector2 speed = new Vector2(50, 50);
	private Vector3 movement;
	private bool isboxStuck;
	private Collision2D boxStuck;

    // Update is called once per frame
    void Update()
    {
		if (isboxStuck != false) {
			if (Input.GetKey (KeyCode.RightShift)) {
				boxStuck = null;
			}
		}
        float inputX = Input.GetAxis("2Horizontal");
        float inputY = Input.GetAxis("2Vertical");

        movement = new Vector3(speed.x * inputX, speed.y * inputY);

        movement *= Time.deltaTime;

        transform.Translate(movement);
		try {boxStuck.transform.Translate (movement);}
		catch (Exception e) {
		}
    }
	void OnCollisionEnter2D(Collision2D box) {


		if (box.gameObject.layer == 13 || box.gameObject.layer == 19) {

			Debug.Log ("the correct box is here");
			isboxStuck = true;
			boxStuck = box;


		}
}
}