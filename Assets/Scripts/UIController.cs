using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	// Update is called once per frame

	public GameObject cultistButton;
	public GameObject impButton;
	public GameObject witchButton;
	public GameObject mummyButton;
	public GameObject abominationButton;
	public GameObject tentacleButton;
	public GameObject giantLizardButton;
	public GameObject demonlordButton;
	public GameObject darkGodButton;
	
	public GameObject summonButton1;
	public GameObject summonButton2;
	public GameObject summonButton3;

	public static bool showButton = false;

	private bool cultistButtonDisabled = true;

	public void ShowSummonButton(){

		if (impButton.activeSelf == false) {
			impButton.SetActive (true);
		} else if (witchButton.activeSelf == false) {
			witchButton.SetActive (true);
		} else if (mummyButton.activeSelf == false) {
			mummyButton.SetActive (true);
		} else if (abominationButton.activeSelf == false) {
			abominationButton.SetActive (true);
		} else if (tentacleButton.activeSelf == false) {
			tentacleButton.SetActive (true);
		} else if (giantLizardButton.activeSelf == false) {
			giantLizardButton.SetActive (true);
		} else if (demonlordButton.activeSelf == false) {
			demonlordButton.SetActive (true);
		} else if (darkGodButton.activeSelf == false) {
			darkGodButton.SetActive (true);
		}
	}

	void Update () {
		if (showButton == true) {
			ShowSummonButton();
			showButton = false;
		}
		if (cultistButtonDisabled && Score.score >= 50) {
			cultistButton.SetActive(true);
			cultistButtonDisabled = false;
		}
	}
}
