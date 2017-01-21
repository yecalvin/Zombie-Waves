using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

	//public Text scoreText;
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
		updateScore (); 
	}
	
	// Update is called once per frame
	void updateScore () {
		//scoreText = "Score: " + score;
	}
}
