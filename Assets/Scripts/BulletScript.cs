using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public Camera cam;
	private Vector3 speed;
	// Use this for initialization

	Rigidbody2D rb;
	void Start () {
		Vector3 mousePos = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 currentPos = transform.position;
		speed = mousePos - currentPos;
//		if (speed.x > 0) {
//			speed.x = 3;
//		} else if (speed.x < 0) {
//			speed.x = -3;
//		} else {
//			speed.x = 0;
//		}
		speed.z = 0;
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = speed;
	}
	
	// Update is called once per frame

	void FixedUpdate() {
		rb.velocity = speed;
	}
}
