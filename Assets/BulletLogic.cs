using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour {
	public GameObject bullet;
	public static int currentNumberOfBullets;
	private int maxBullets = 6;
	// Use this for initialization

	void Start () {
		currentNumberOfBullets = 0;
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space) && currentNumberOfBullets <= maxBullets)   {
			Fire ();
		}
	}

	void Fire() {
		Debug.Log (currentNumberOfBullets);
		Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Quaternion spawnRotation = Quaternion.identity;
		currentNumberOfBullets++;

		Instantiate (bullet, spawnPosition, spawnRotation);
	}

}
