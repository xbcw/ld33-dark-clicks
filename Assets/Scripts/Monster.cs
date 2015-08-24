using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Monster : MonoBehaviour {

	public float speed = 1.0f;
	public int damage = 1;
	public int cost = 1;

	public float xStart = -1.4f;
	public float xEnd = 1.4f;
	public float yStart = -0.8f;
	public float yEnd = -1.1f;

	void Update(){
		transform.Translate (speed * Time.deltaTime, 0f, 0f);
		if ((transform.position.x > xEnd && speed > 0) || (transform.position.x < xStart && speed < 0)) {
			speed *= -1.0f;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}