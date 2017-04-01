using UnityEngine;
using System.Collections;

public class Player2Script : MonoBehaviour
{

    public Vector2 speed = new Vector2(50, 50);
	private bool isboxStuck;
	private Collision2D boxStuck;

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("2Horizontal");
        float inputY = Input.GetAxis("2Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

	// drag object
	void OnCollisionEnter2D(Collision2D box) {


		if (box.gameObject.layer == 18 || box.gameObject.layer == 19) {
			//Debug.Log ("the correct box is here");
			isboxStuck = true;
			boxStuck = box;
		}
	}
}
