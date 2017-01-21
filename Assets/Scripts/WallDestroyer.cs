using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyer : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		Destroy (other.gameObject);
		Debug.Log ("inside WallDestroyer");
	}
}
