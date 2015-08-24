using UnityEngine;
using System.Collections;

public class TentacleController : Monster {

	// Use this for initialization
	void Start () {
		if (Random.value > 0.5) {
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	void Update(){
		transform.Translate (0f, speed * Time.deltaTime, 0f);
		if ((transform.position.y > yEnd && speed > 0) || (transform.position.y < yStart && speed < 0)) {
			speed *= -1.0f;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
