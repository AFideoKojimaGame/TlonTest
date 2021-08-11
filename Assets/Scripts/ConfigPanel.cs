using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//ConfigPanel turned purely into a class for modifying Globals values from the UI. TxtInfo is also removed as it meant for displaying other values.

public class ConfigPanel : MonoBehaviour {

	///Public fields converted to serialized privates due to not access not being required by other classes
	[SerializeField] private Slider sliderRate;
	[SerializeField] private Slider sliderSpeed;
	[SerializeField] private Text txtRate;
	[SerializeField] private Text txtSpeed;

	void Awake () {
		UpdateValues();
	}

	//Called on startup and whenever one of the sliders is modified
	public void UpdateValues() {
		
		Globals.instance.rate = Mathf.RoundToInt(sliderRate.value);
		txtRate.text = Globals.instance.rate.ToString("0.");
		
		Globals.instance.speed = sliderSpeed.value;
		txtSpeed.text = Globals.instance.speed.ToString("0.");
	}

}
