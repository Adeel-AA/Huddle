using UnityEngine;
using System.Collections;

public class Player1Script : MonoBehaviour
{

    public Vector2 speed = new Vector2(50, 50);

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
}
