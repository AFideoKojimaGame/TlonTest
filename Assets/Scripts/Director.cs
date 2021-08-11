using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

//Director now only displays values in the UI

public class Director : MonoBehaviour {

	[SerializeField] private Text txtInfo;

	private int hitsPerSecond = 0;
	private float hitsCounter = 1;


	void Update () {

		//counter defining when the hits per second value is refreshed
		if (hitsCounter >= 1) {
			hitsPerSecond = Globals.instance.hitsPerSecond;
			Globals.instance.hitsPerSecond = 0;
			hitsCounter = 0;
		}else {
			hitsCounter += Time.deltaTime;
		}

		//Update stats
		txtInfo.text =
			$"{Globals.instance.activeAliens.Count} aliens alive"
			+ $"\n{hitsPerSecond} cocoons hits p/sec"
			+ $"\n{Globals.instance.GetAvgAngle():F2}° average angle"
			;

	}
}
