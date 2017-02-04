using UnityEngine;
using System.Collections;

public class CircleColl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (11, 8);
		Physics2D.IgnoreLayerCollision (11, 10);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
