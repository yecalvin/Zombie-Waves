using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {
	private float speed = 0.03f;
	public int STARTINGHP = 100;
	public int CURRENTHP;

	public float fastZombieSpawnRate = 0.1f;

	public Image healthBar;
	public GameObject bl;

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

		float prob = Random.Range (0.0f, 1.0f);
		speed = prob > fastZombieSpawnRate ? Random.Range (0.05f, 0.07f) : speed;
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
		} 
		position.x = position.x - speed;
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject != null) {
			Destroy (coll.gameObject);
			BulletLogic.currentNumberOfBullets--;

			CURRENTHP = CURRENTHP - 50;
			healthBar.fillAmount = CURRENTHP / (float) STARTINGHP;
		}
	}
}
