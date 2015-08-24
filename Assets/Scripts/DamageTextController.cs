using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageTextController : MonoBehaviour {

	public Color color = new Color(0.8f,0.8f,0.0f,1.0f);
	public float scroll = 0.05f;  // scrolling velocity
	public float duration = 1.5f; // time to die
	public float alpha;

	// Use this for initialization
	void Start () {
		GetComponent<Text>().material.color = color; // set text color
		alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (alpha>0){
			//transform.position.y += scroll*Time.deltaTime;
			transform.position = new Vector3(transform.position.x, transform.position.y + scroll+Time.deltaTime, transform.position.z);
			alpha -= Time.deltaTime/duration; 
			//GetComponent<GUIText>().material.color.a = alpha;        
		} else {
			Destroy(gameObject); // text vanished - destroy itself
		}
	}
}
