using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletLogic : MonoBehaviour {
	public GameObject bullet;
	public static int currentNumberOfBullets;
	private int maxBullets = 4;
	public Image aggroBar;


	// Use this for initialization

	void Start () {
		currentNumberOfBullets = 0;
		Debug.Log (currentNumberOfBullets);
		aggroBar.fillAmount = 0;
		//bullet.gameObject.tag = "bullet";

	}
	
	// Update is called once per frame
	void Update() {
		if (aggroBar.fillAmount > 0) {
			aggroBar.fillAmount -= 0.01f;
		}
		if (Input.GetKeyDown(KeyCode.Space) && currentNumberOfBullets <= maxBullets)   {
			Fire ();
			aggroBar.fillAmount += 0.1f;
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
