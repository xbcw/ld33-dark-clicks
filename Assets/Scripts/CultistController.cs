using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CultistController : Monster {
	public ParticleSystem crunch;

	void Awake(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Start(){
		if (Random.value > 0.5) {
			speed = -speed;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
		InvokeRepeating ("Damage", 2, 2.0f);
	}

	void Damage(){
		Score.score += damage;
		float rand = Random.value;
		if (rand > 0.90) {
			Vector3 startPos = new Vector3 (transform.position.x, transform.position.y + Random.value * 2 + transform.position.z);
			Instantiate(crunch, startPos, Quaternion.identity);
			if(rand > 0.95) {			
				CityController.shake = 20;
			}
		}
	}
}
