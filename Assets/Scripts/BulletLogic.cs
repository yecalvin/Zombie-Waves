using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletLogic : MonoBehaviour {
	public GameObject bullet;
	public static int currentNumberOfBullets;
	private int maxBullets = 5;
	public Image aggroBar;


	// Use this for initialization
	private bool fullAggro;

	void Start () {
		currentNumberOfBullets = 0;
		Debug.Log (currentNumberOfBullets);
		aggroBar.fillAmount = 0;
		fullAggro = false;

	}

	// Update is called once per frame
	void Update() {
		if (aggroBar.fillAmount > 0) {
			aggroBar.fillAmount -= 0.005f;
		}
		if ((Input.GetKeyDown(KeyCode.Mouse0) ||Input.GetKeyDown(KeyCode.Space)) && currentNumberOfBullets <= maxBullets && !fullAggro && GameController.gameStarted) {
			Fire ();
			aggroBar.fillAmount += 0.3f;
		}

		if (aggroBar.fillAmount >= 1.0f) {
			fullAggro = true;
		}

		if (aggroBar.fillAmount <= 0) {
			fullAggro = false;
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
