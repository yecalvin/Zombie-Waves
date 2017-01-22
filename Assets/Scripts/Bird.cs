using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour {
	private float speed = 0.06f;
	private float speedY = 0.02f;
	public int STARTINGHP = 100;
	public int CURRENTHP;
	private float maxWidth;
	private float maxHeight;
	public Image healthBar;

	private int a = 0;
	public Camera cam;

	// Use this for initialization
	void Start () {
		if (Score.score >= 5) {
			int scale = Score.score / (int)5;
			int appliedScale = Mathf.Max (1, scale);
			CURRENTHP = STARTINGHP + (appliedScale * 50);
			STARTINGHP = CURRENTHP;
		} else {
			CURRENTHP = STARTINGHP;
			STARTINGHP = CURRENTHP;
		}
		if (cam == null) {
			cam = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update () {
		moveBird();
		if (CURRENTHP <= 0) {
			Score.score += 1;
			Destroy (gameObject);
		}
		//checkEdge ();
	}

//	void moveBird(){
//		Vector2 position = this.transform.position;
//		float playerY = GameObject.Find ("CoinSprite").transform.position.y;
//		float playerX = GameObject.Find ("CoinSprite").transform.position.x;
//
//		float currentPositionY = position.y;
//		if (currentPositionY > playerY) {
//			position.y -= speedY;
//		} else {
//			position.y += speedY;
//		}
//
//		float currentPositionX = position.x;
//		if (currentPositionX > playerX) {
//			position.x -= speed;
//		} else {
//			position.x += speed;
//		}
//			
//		this.transform.position = position;
//	}


	void moveBird(){
		Vector2 position = this.transform.position;
		float playerY = GameObject.Find ("CoinSprite").transform.position.y;
		float playerX = GameObject.Find ("CoinSprite").transform.position.x;

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float playerWidth = GetComponent<Renderer> ().bounds.extents.x;
		maxHeight = targetWidth.y;
		maxWidth = targetWidth.x - playerWidth/2;
		float currentPositionY = position.y;
		float currentPositionX = position.x;



		if (a > 0) {
			if (currentPositionY > playerY) {
				position.y += speedY;
			} else {
				position.y -= speedY;
			}


			if (currentPositionX > playerX) {
				position.x += speed;
			} else {
				position.x -= speed;
			}
			a--;
		} else {

			if (( playerY - 0.2f < currentPositionY && currentPositionY  < playerY + 0.2f) &&
				( playerX - 0.2f < currentPositionX && currentPositionX < playerX + 0.2f)) {
				if (currentPositionY > playerY) {
					position.y += speedY;
				} else {
					position.y -= speedY;
				}


				if (currentPositionX > playerX) {
					position.x += speed;
				} else {
					position.x -= speed;
				}

				a = 100;


			} else {

				if (currentPositionY > playerY) {
					position.y -= speedY;
				} else {
					position.y += speedY;
				}


				if (currentPositionX > playerX) {
					position.x -= speed;
				} else {
					position.x += speed;
				}


			}

		}


		this.transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D coll){
		Debug.Log ("collision");
		if (coll.gameObject != null) {
			Destroy (coll.gameObject);
			BulletLogic.currentNumberOfBullets--;
			CURRENTHP = CURRENTHP - 50;
			healthBar.fillAmount = CURRENTHP / (float) STARTINGHP;
		}
	}
}

