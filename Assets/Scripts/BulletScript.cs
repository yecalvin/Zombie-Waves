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
		speed = mousePos-currentPos;
		rb = GetComponent<Rigidbody2D> ();
		//speed.y = speed.y + 1;
		rb.velocity = speed;

	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = speed;
	}

	void FixedUpdate() {
	}
}
