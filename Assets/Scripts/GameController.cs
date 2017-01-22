using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	//GameState
	public bool continueGame = true;


	//Game configuration
	public float zombieSpawnRate = 3.5f;
	public Camera cam;
	public GameObject player;
	public GameObject zombie;
	public GameObject bird;

	private float maxWidth;


	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);

		//Starts zombie waves
		StartCoroutine (SpawnZombie());

	}
	
	// Update is called once per frame
	void Update () {
		//TODO: Check if game should end?
		continueGame = shouldContinueGame ();
		if (!continueGame) {
			endGame ();
		}
	}

	bool shouldContinueGame () {

		return Player.playerHealth > 0 && Player.distance < 10.0f;
	}

	void endGame () {
		
		Debug.Log (" End game ");


	}

	IEnumerator SpawnZombie() {

		//Wait before starting the zombie waves
		yield return new WaitForSeconds (3.0f); 

		while (continueGame) {
			//Debug.Log ("Spawning Zombie ");
			float spawningPointX = transform.position.x;
	
			Vector3 spawnPos = new Vector3 (
				Random.Range (spawningPointX - 2, spawningPointX + 2),
				//Random.Range(-2.08f, 2.49f),
				transform.position.y,
				0.0f
			);

			Vector3 spawnPosF = new Vector3 (
				Random.Range (spawningPointX - 2, spawningPointX + 2),
				Random.Range(-0.8f, 2.49f),
				//transform.position.y,
				0.0f
			);

			Quaternion spawnRot = Quaternion.identity;
			Instantiate (zombie, spawnPos, spawnRot); 
			Instantiate (bird, spawnPosF, spawnRot);

			//Yield is just to stop unity from freezing
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
		}
	}
}
