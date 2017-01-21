using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

	public Text scoreText;
	public static int score;

	// Use this for initialization
	void Start () {
		score = 0;
		updateScore (); 
	}
	
	// Update is called once per frame
	void updateScore () {
		scoreText.text = "Score: " + score;
	}

	void FixedUpdate() {
		scoreText.text = "Score: " + score;
	}
}
