using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyer : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		//Debug.Log ("inside WallDestroyer");
		Destroy (other.gameObject);
		if (other.gameObject.tag == "bullet") {
			BulletLogic.currentNumberOfBullets--;
		}
	}
}
