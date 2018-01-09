using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankInit : MonoBehaviour {

	public Transform[] redPositions= new Transform[5];
	public Transform[] bluePositions= new Transform[5];
	public Transform[] greenPositions= new Transform[5];
	public GameObject redTank;
	public GameObject blueTank;
	public GameObject greenTank;

	//private SettingData settingData;


	// Use this for initialization
	void Start () {
		//settingData = GameObject.Find ("SettingData").GetComponent<SettingData>();
		InitTanks ();
	}

	public void InitTanks() {	
		for (int i = 0; i < SettingData.redNum; i++) {
			Instantiate (redTank, redPositions[i].position, redPositions[i].rotation);
		}

		for (int i = 0; i < SettingData.greenNum; i++) {
			Instantiate (greenTank, greenPositions[i].position, greenPositions[i].rotation);
		}

		for (int i = 0; i < SettingData.blueNum; i++) {
			Instantiate (blueTank, bluePositions[i].position, bluePositions[i].rotation);
		}

	}

}
