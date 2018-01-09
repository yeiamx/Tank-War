using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Start(){
		SettingData.redNum = 3;
		SettingData.blueNum = 3;
		SettingData.greenNum = 2;
	}

	public void player() {
		SceneManager.LoadScene ("2player");
	}

	public void AI() {
		SceneManager.LoadScene ("Level1");
	}

	public void Quit() {
		Debug.Log ("Quit Game.");
		Application.Quit();
	}
}
