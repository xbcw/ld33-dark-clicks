using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public int damage = 2;
	private int darkPowerUpgradeCost;
	public Text upgradeButtonText;
	// Use this for initialization

	void Start () {
		darkPowerUpgradeCost = 100;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void IncreaseDarkPower(){
		if (Score.score >= darkPowerUpgradeCost) {
			Score.score -= darkPowerUpgradeCost;
			damage += darkPowerUpgradeCost / 100;
			darkPowerUpgradeCost = darkPowerUpgradeCost * 5;
			upgradeButtonText.text = "Dark Clicks\n" + darkPowerUpgradeCost + " Power";
		}
	}
}
