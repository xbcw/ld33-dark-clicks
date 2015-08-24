using UnityEngine;
using System.Collections;

public class SummoningPortalController : MonoBehaviour {

	private int buildLevel = 0;
	private int[] monsterCosts = new int[] {250, 1000, 2500, 5000, 10000, 20000, 50000, 500000};
	private string[] monsterNames = new string[] {"Imp", "Witch", "Mummy", "Abomination", "Tentacles", "Giant Lizard", "Demonlord", "Dark God"};
	private string[] summoningPhrases = new string[] {
		" steps out of the shadows...",
		" tears its way into reality!",
		" joins your legion...",
		" returns!",
		" claws its way from the depths...",
		" approachs..."
	};

	public GameObject imp;
	public GameObject witch;
	public GameObject mummy;
	public GameObject abomination;
	public GameObject tentacle;
	public GameObject giantLizard;
	public GameObject demonlord;
	public GameObject darkGod;

	private bool monsterUpgradeActive = true;

	private GameObject obj;
	private Object new_obj;

	public ParticleSystem ps;

	void Start() {
		Spawn ();
	}

	// Update is called once per frame
	void Update () {
		if (monsterUpgradeActive) {
			if (Score.score >= monsterCosts [buildLevel]) {
				Message.message = "The " + monsterNames [buildLevel] + summoningPhrases [Random.Range (0, summoningPhrases.Length)];
				MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour> ();
				foreach (MonoBehaviour script in scripts) {
					script.enabled = true;
				}
				obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				CreateMonster ();
			} else {
				ps.startSize = ((Score.score * 1.0f) / (monsterCosts [buildLevel] * 1.0f)) * 0.7f;
			}
		} 
	}

	void Spawn () {
		switch (monsterNames [buildLevel]) {
		case "Imp":
			obj = imp;
			break;
		case "Witch":
			obj = witch;
			break;
		case "Mummy":
			obj = mummy;
			break;
		case "Abomination":
			obj = abomination;
			break;
		case "Tentacles":
			obj = tentacle;
			obj.transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);
			break;
		case "Giant Lizard":
			obj = giantLizard;
			obj.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			break;
		case "Demonlord":
			obj = demonlord;
			break;
		case "Dark God":
			obj = darkGod;
			break;
		default:
			obj = imp;
			Debug.Log ("invalid monster object");
			break;
		}
		MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour> ();
		foreach (MonoBehaviour script in scripts) {
			script.enabled = false;
		}

		if (buildLevel < monsterNames.Length) {
			new_obj = Instantiate (obj, new Vector3 (-2.9f, -1.05f, 0.0f), Quaternion.identity);
		}
	}

	void CreateMonster() {
		Destroy (new_obj);
		UIController.showButton = true;
		buildLevel += 1;
		if (buildLevel < monsterNames.Length) {
			Spawn ();
		} else {
			monsterUpgradeActive = false;
			ps.startSize = 0.04f;
		}
	}
}
