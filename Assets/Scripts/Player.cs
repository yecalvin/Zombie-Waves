using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Camera cam;
	public GameObject bullet;

	private float maxWidth;
	Vector3 pos;
	private Vector3 normalizedDirection;
	private float xDiff;
	private float yDiff;
	private int maxBullets = 6;
	public int currentNumberOfBullets;

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		currentNumberOfBullets = 0;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float playerWidth = GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - playerWidth/2;

		pos = Input.mousePosition;
		pos.z = 20;

	}

	public int getCurrentNumberOfBullets() {
		return currentNumberOfBullets;
	}

	/*
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space) && currentNumberOfBullets < maxBullets) {
			Fire ();
		}
	}

	void Fire() {
		Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Quaternion spawnRotation = Quaternion.identity;
		currentNumberOfBullets++;
		Instantiate (bullet, spawnPosition, spawnRotation);
	}
	*/

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey ("d")) {
			Vector3 newPosition = new Vector3 (transform.position.x + 0.1f, transform.position.y, transform.position.z);
			if (newPosition.x < maxWidth / 10) {
				transform.position = newPosition;
			}
				
		} else if (Input.GetKey ("a")) {
			Vector3 newPosition = new Vector3 (transform.position.x - 0.1f, transform.position.y, transform.position.z);
			if (newPosition.x > -maxWidth) {
				transform.position = newPosition;
			}
		} 
	}



}
