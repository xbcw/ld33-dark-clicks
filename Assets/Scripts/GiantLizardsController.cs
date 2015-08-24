using UnityEngine;
using System.Collections;

public class GiantLizardsController : Monster {
	public ParticleSystem crunch;
	
	private Animator animator;
	private float maxSpeed;


	void Awake(){
		maxSpeed = speed;
		animator = GetComponent<Animator> ();

		//float newScale = Random.Range (0.8f, 1.4f);
		//transform.localScale = new Vector3 (newScale, newScale, newScale);
		InvokeRepeating ("Damage", 2, 5.0f);
	}
	
	void Start(){
		InvokeRepeating ("ChangeSpeed", Random.Range (0, 10), Random.Range (5, 30));
		float rColor = Random.value;
		float gColor = Random.value;
		float bColor = Random.value;
		foreach(SpriteRenderer c in GetComponentsInChildren<SpriteRenderer> ()) {
			c.color = new Color(rColor, gColor, bColor);
		}
		float randSize = Random.Range (0.6f, 0.8f);
		transform.localScale = new Vector3 (randSize, randSize, randSize);
	}
	
	void Update(){
		transform.Translate (speed * Time.deltaTime, 0f, 0f);
		if (Mathf.Abs (transform.position.x) > xEnd) {
			speed *= -1.0f;
			maxSpeed = -maxSpeed;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		if (speed != 0) {
			animator.SetBool ("isMoving", true);
		} else {
			animator.SetBool("isMoving", false);
		}
	}

	void ChangeSpeed() {
		if (speed != 0) {
			speed = 0;
		} else {
			speed = maxSpeed;
		}
	}

	void Damage(){
		animator.SetTrigger("isAttacking");
		Score.score += damage;
		float rand = Random.value;
		if (rand > 0.80) {
			Vector3 startPos = new Vector3 (transform.position.x, transform.position.y + Random.value * 2 + transform.position.z);
			Instantiate(crunch, startPos, Quaternion.identity);
			if(rand > 0.90) {			
				CityController.shake = 20;
			}
		}
	}
}
