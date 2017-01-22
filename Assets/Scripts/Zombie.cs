using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {
	private float speed = 0.03f;
	public int STARTINGHP = 100;
	public int CURRENTHP;

	public float fastZombieSpawnRate = 0.3f;

	public Image healthBar;
	public GameObject bl;

	// Use this for initialization
	void Start () {
		CURRENTHP = STARTINGHP;

		float prob = Random.Range (0.0f, 1.0f);
		if (prob > fastZombieSpawnRate) {
			speed = 0.06f;
		} else {
			speed = 0.03f;
		}
	}
		
	// Update is called once per frame
	void Update() {
		moveZombie ();
		if (CURRENTHP <= 0) {
			Score.score += 1;
			Destroy (gameObject);
		}
	}

	void moveZombie(){
		Vector2 position = this.transform.position;
		if (Player.moving) {
			position.x = position.x - 0.09f;
		} else {
			position.x=position.x - speed;
		}
		position.x=position.x - speed;
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject != null) {
			Destroy (coll.gameObject);
			BulletLogic.currentNumberOfBullets--;

			CURRENTHP = CURRENTHP - 50;
			healthBar.fillAmount = CURRENTHP / (float)STARTINGHP;
		}
	}
}
