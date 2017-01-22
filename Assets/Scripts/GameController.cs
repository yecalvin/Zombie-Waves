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
	public GameObject startButton;
	public GameObject endButton;

	private float maxWidth;


	public void StartGame() {
		//Debug.Log ("Button Event Handler");
		startButton.SetActive (false);
		//Starts zombie waves
		StartCoroutine (SpawnZombie());
		Player.playerHealth = 3;
		endButton.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		endButton.SetActive (false);
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
		//return (playerHealth > 0) && (playerWidth > goalWidth);
		return Player.playerHealth > 0;
	}

	void endGame () {
		Debug.Log (" End game ");
		Score.score = 0;
		endButton.SetActive (true);
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
