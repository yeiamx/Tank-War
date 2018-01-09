using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour {

	public string currentScene;
	public TextMeshProUGUI pauseText;
	private bool pause = false;

	public void back() {
		SceneManager.LoadScene ("main");
	}

	public void resart() {
		SceneManager.LoadScene (currentScene);
	}

	public void Pause() {
		if (!pause) {
			pause = true;
			pauseText.text = "Continue";
			Time.timeScale = 0;
		} else {
			pause = false;
			pauseText.text = "Pause";
			Time.timeScale = 1;
		}
	}
}
