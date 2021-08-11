using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class Alien : MonoBehaviour
{

	//Public fields converted to serialized privates due to not access not being required by other classes
	[SerializeField] private Canvas ui;
	[SerializeField] private Text txtAlien;

	//movement script switched to NavMeshAgent for simplification. Objective is basic enough that creating a custom pathfinding solution would be more troublesome, while Navmesh allows it
	//to remain dynamic. Speed variable removed in favor of pulling it from a Globals class.
	[SerializeField] private NavMeshAgent nav;

	//keeps track of current amount of cocoons
	private int cocoonCount = 0;


	void Start()
	{		
		txtAlien = ui.GetComponentInChildren<Text>();
		txtAlien.text = "0";
	}

	//initialization of local elements like cocoon count, navmesh & target now happen within alien script
	public void Initialize(Transform target)
	{
		cocoonCount = 0;
		txtAlien.text = "0";
		nav.SetDestination(target.position);
		GetComponent<Animator>().Play("Grounded");
		GetComponent<Animator>().SetFloat("Forward", 1f);

	}

	void Update ()
	{
		//pull navmeshagent speed from Globals
		nav.speed = Globals.instance.speed;

		//keep ui rotation as if alien is facing forward for readability
		ui.transform.eulerAngles = new Vector3(90, 270, 0);
	}

	private void OnTriggerEnter(Collider other) 
	{
		if(other.CompareTag("Goal"))
		{
			//remove from active alien list and recycle pooled object

			if(Globals.instance.activeAliens.Contains(this))
				Globals.instance.activeAliens.Remove(this);
			GetComponent<PoolObject>().Recycl();
		}

		if(other.CompareTag("Cocoon"))
		{
			Globals.instance.hitsPerSecond++;
			cocoonCount++;
			txtAlien.text = cocoonCount.ToString();
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Cocoon"))
        {
			cocoonCount--;
			txtAlien.text = cocoonCount.ToString();
        }
    }
}
