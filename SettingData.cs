using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingData : MonoBehaviour {
	public static int blueNum;
	public static int greenNum;
	public static int redNum;
	public static int maxTankNum = 5;


	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);
	}

	void Update() {
		Debug.Log ("Green: "+greenNum +" Red: "+redNum + " Blue: "+blueNum);
	}
}
