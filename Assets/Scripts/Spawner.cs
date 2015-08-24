using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private float xPadding = 0.1f;
	
	public void Spawn(Monster obj) {
		if (Score.score - obj.cost >= 0) {
			Score.score -= obj.cost;
			float x = Random.Range (obj.xStart, obj.xEnd);
			float y = Random.Range (obj.yStart, obj.yEnd);
			Instantiate (obj, new Vector3 (x,y, 0.0f), Quaternion.identity);
		}
	}

	public void SpawnRandomMonster(Monster obj) {
		if (Score.score - obj.cost >= 0) {
			Score.score -= obj.cost;
			float x = Random.Range (obj.xStart + xPadding, obj.xEnd - xPadding);
			float y = Random.Range (obj.yStart, obj.yEnd);
			Instantiate (obj, new Vector3 (x, y, 0.0f), Quaternion.identity);
		}
		gameObject.SetActive (false);
	}
}