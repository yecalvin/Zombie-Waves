using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSky : MonoBehaviour {
	private float originalPos;
	// Use this for initialization
	void Start () {
		originalPos = transform.position.x;
	}
	
	// Update is called once per frame

	void FixedUpdate() {
		transform.position = new Vector3 (transform.position.x-0.1f, transform.position.y, transform.position.z);
		if (transform.position.x < -10.2f) {
			transform.position = new Vector3 (10.2f, transform.position.y, transform.position.z);
		} 
	}
}
