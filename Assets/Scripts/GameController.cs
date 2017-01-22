using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


	//GameState
	public bool continueGame = true;
	public static bool gameStarted = false;

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
		gameStarted = true;
		endButton.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);

		if (startButton.activeSelf == false) {
			startButton.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: Check if game should end?
		continueGame = playerIsAlive ();
		if (!continueGame) {
			endGame ();
		}
	}

	bool playerIsAlive () {
		//return (playerHealth > 0) && (playerWidth > goalWidth);
		return Player.playerHealth > 0; //&& Player.distance < 10.0f;
	}

	public void restartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//Application.LoadLevel(Application.loadedLevel);
		Application.LoadLevel (0); 
		StartGame();
	}
		

	void endGame () {
		Debug.Log (" End game ");

		endButton.SetActive (true);
	}
		

	IEnumerator SpawnZombie() {

		//Wait before starting the zombie waves
		yield return new WaitForSeconds (3.0f); 

		while (continueGame) {
			//Debug.Log ("Spawning Zombie ");
			float spawningPointX = transform.position.x;

			//Camera.main.transform.positi

			Vector3 spawnPos = new Vector3 (
				Random.Range (spawningPointX - 2, spawningPointX + 2),
				transform.position.y,
				0.0f
			);

			Vector3 spawnPosF = new Vector3 (
				Random.Range (spawningPointX - 2, spawningPointX + 2),
				Random.Range(-0.8f, 2.49f),
				0.0f
			);

			Quaternion spawnRot = Quaternion.identity;

			int r = Random.Range (0, 99);

			if (r < 50) {
				Instantiate (zombie, spawnPos, spawnRot); 
			} else {
				Instantiate (bird, spawnPosF, spawnRot);
			}

			//Yield is just to stop unity from freezing
			yield return new WaitForSeconds (Random.Range (2.0f, 5.0f));
		}
	}
}
