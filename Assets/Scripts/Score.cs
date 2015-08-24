using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
		
	public static int score;
	Text text;

	void Awake () {
		text = GetComponent <Text> ();
		score = 0;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Dark Power: " + score;
	}
}
