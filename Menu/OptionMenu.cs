using UnityEngine;
using System.Collections;
using TMPro;

public class OptionMenu : MonoBehaviour
{
	//public SettingData settingData;
	
	public TextMeshProUGUI redText;
	public TextMeshProUGUI greenText;
	public TextMeshProUGUI blueText;

	private int maxTankNum = 5;

	void Start() {
		greenText.text = ""+SettingData.greenNum;
		redText.text = ""+SettingData.redNum;
		blueText.text = ""+SettingData.blueNum;
	}

	public void setRed(float num) {
		//Debug.Log ((int)(num*5));
		SettingData.redNum = (int)(num*maxTankNum);
		redText.text = ""+SettingData.redNum;
	}

	public void setGreen(float num) {
		SettingData.greenNum = (int)(num*maxTankNum);
		greenText.text = ""+SettingData.greenNum;
	}

	public void setBlue(float num) {
		SettingData.blueNum = (int)(num*maxTankNum);
		blueText.text = ""+SettingData.blueNum;
	}
}

