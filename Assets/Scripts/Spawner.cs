using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Spawner : MonoBehaviour {

	///Public fields converted to serialized privates due to not access not being required by other classes
	[SerializeField] private Transform start;
	[SerializeField] private Transform finish;

	//Alien Prefab replaced by Alien pool
	//Alien UI Prefab gone, integrated into Alien GameObject to amount of pooled objects
	[SerializeField] private Pool alienPool;

	//Used for keeping track of spawn rate
	private float spawnCounter = 0;


	//Function changed: "CreateAlien" no longer returns an Alien value, instead merely adding it to the activeAliens list.
	//Alien is reset then added to list.
	void CreateAlien() {

		Alien a = alienPool.Spawn().GetComponent<Alien>();
		ResetAlien(a);
		Globals.instance.activeAliens.Add(a);
	}

	//Alien's transform is set then its NavMeshAgent is initialized within the Alien script
	void ResetAlien(Alien alien) {

		alien.transform.position = start.position;
		alien.transform.rotation = start.rotation;
		alien.Initialize(finish);
	}

	private void Update() {

		//A timer of 1 second divided by the spawn rate per second

		if(Globals.instance.rate > 0) {

			if(spawnCounter < 1f / Globals.instance.rate) {
				spawnCounter += Time.deltaTime;
			}else {
				CreateAlien();
				spawnCounter = 0;
			}
		}
	}

}
