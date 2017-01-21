﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	private float speed = 0.06f;
	private float speedY = 0.01f;
	public int STARTINGHP = 100;
	public int CURRENTHP;

	// Use this for initialization
	void Start () {
		CURRENTHP = STARTINGHP;
	}
	
	// Update is called once per frame
	void Update () {
		moveBird();
		if (CURRENTHP < 0) {
			Destroy (gameObject);
		}
		//checkEdge ();
	}

	void moveBird(){
		Vector2 position = this.transform.position;
		float playerY = GameObject.Find ("CoinSprite").transform.position.y;
		float playerX = GameObject.Find ("CoinSprite").transform.position.x;

		float currentPositionY = position.y;
		if (currentPositionY > playerY) {
			position.y -= speedY;
		} else {
			position.y += speedY;
		}

		float currentPositionX = position.x;
		if (currentPositionX > playerX) {
			position.x -= speed;
		} else {
			position.x += speed;
		}
			
		this.transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D coll){
		Debug.Log ("collision");
		if (coll.gameObject != null) {
			Destroy (coll.gameObject);
			CURRENTHP = CURRENTHP - 50;
		}
	}
	/*
	void checkEdge(){
		Vector2 position = this.transform.position;
		Debug.Log (position.x);
		if (position.x < -6f) {
			Destroy (gameObject);
		}
	}
	
	*/
}
