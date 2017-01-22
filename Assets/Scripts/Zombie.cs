using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {
	private float speed = 0.06f;
	public int STARTINGHP = 100;
	public int CURRENTHP;

	public Image healthBar;
	public GameObject bl;

	// Use this for initialization
	void Start () {
		CURRENTHP = STARTINGHP;
	}
		
	// Update is called once per frame
	void Update() {
		moveZombie ();
		if (CURRENTHP <= 0) {
			Score.score += 1;
			Destroy (gameObject);
		}
		//checkEdge ();
	}

	void moveZombie(){
		Vector2 position = this.transform.position;
		position.x=position.x - speed;
		this.transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D coll){
		//Debug.Log ("collision");

		if (coll.gameObject.CompareTag("bullet")) {
			Debug.Log ("bulletColl");
		}
		if (coll.gameObject != null) {
			Destroy (coll.gameObject);
			BulletLogic.currentNumberOfBullets--;

			CURRENTHP = CURRENTHP - 50;
			healthBar.fillAmount = CURRENTHP / (float)STARTINGHP;
		}
	}
}
