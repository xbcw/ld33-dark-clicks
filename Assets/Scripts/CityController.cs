using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityController : MonoBehaviour {

	public ParticleSystem crunch;
	public float speed = 60.0f;
	public float amount = 0.03f;
	public static int shake = 0;
	public Transform ptsPrefab; // drag the prefab to this variable in Inspector
	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
		// Update is called once per frame
	void Update () {
		if (shake > 0) {
			transform.position = new Vector3 (Mathf.Sin(Time.time * speed)*amount, transform.position.y, transform.position.z);
			shake--;
		}
	}

	void OnMouseDown() {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Instantiate(crunch, ray.GetPoint (10), Quaternion.identity);
		crunch.Play ();
		MouseDamageText (player.damage, ray.GetPoint (10).x, ray.GetPoint (10).y);
		Score.score += player.damage;
		if (Random.value > 0.90) {
			shake = 20;
		}
	}
		
	void MouseDamageText(float points, float x, float y){
		x = Mathf.Clamp(x,0.05f,0.95f); // clamp position to screen to ensure
		y = Mathf.Clamp(y,0.05f,0.9f);  // the string will be visible
		Transform gui = Instantiate(ptsPrefab,new Vector3(x,y,0.0f),Quaternion.identity) as Transform;
		GameObject canvas = GameObject.Find ("Canvas");
		gui.SetParent (canvas.transform);
		gui.GetComponent<Text>().text = points.ToString();
		gui.transform.position = Input.mousePosition;
	}
}
