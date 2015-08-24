using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Message : MonoBehaviour {
	
	public static string message;
	Text messageText;
	
	void Awake () {
		messageText = GetComponent <Text> ();
	}
	
	// Use this for initialization
	void Start () {
		message = "";
		InvokeRepeating ("UpdateMessage", 0, 3.0f);
	}

	void UpdateMessage(){
		messageText.text = message;
		message = "";
	}

	// Update is called once per frame
	void Update () {

	}
}
