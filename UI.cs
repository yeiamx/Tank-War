using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {
	public Unit player;
	public Image healthBar;
	public Text healthLabel;

	private bool firstMove = true;

	public void Update() {
		if (player != null) {
			healthBar.fillAmount = (float)player.getCurrentHealth () / (float)player.health;	
			healthLabel.text = player.getCurrentHealth ().ToString ();
		} else {
			healthBar.fillAmount = 0;
			healthLabel.text = "0";
		}

		if (player.getCurrentHealth ()<10 && firstMove) {
			healthLabel.transform.Translate (9, 0, 0);
			firstMove = false;
		}
	}
}
