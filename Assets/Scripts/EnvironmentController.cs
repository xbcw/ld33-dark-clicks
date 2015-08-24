using UnityEngine;
using System.Collections;

public class EnvironmentController : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	private float colorValue = 1.0f;
	private float colorChange = 0.01f;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		InvokeRepeating ("DayNight", 0, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void DayNight() {
		if (colorValue >= 1.0f || colorValue <= 0.3f) {
			colorChange = -colorChange;
		}
		colorValue += colorChange;
		spriteRenderer.color = new Color(colorValue, colorValue, colorValue);
	}
}
