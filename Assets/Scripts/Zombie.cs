using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {
	private float speed = 0.06f;
	public int STARTINGHP = 100;
	public int CURRENTHP;


	// Use this for initialization
	void Start () {
		CURRENTHP = STARTINGHP;
	}
		
	// Update is called once per frame
	void Update() {
		moveZombie ();
		if (CURRENTHP < 0) {
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
		Debug.Log ("collision");
		if (coll.gameObject != null) {
			Destroy (coll.gameObject);
			CURRENTHP = CURRENTHP - 50;
		}
	}

//	void checkEdge(){
//		Vector2 position = this.transform.position;
//		Debug.Log (position.x);
//		if (position.x < -6f) {
//			Destroy (gameObject);
//		}
//	}

}
