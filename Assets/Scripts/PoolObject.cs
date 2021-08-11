using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour {
    Pool pool;
	// Use this for initialization
	public void SetPool (Pool po) {
        pool = po;
	}
	
	// Update is called once per frame
	public void Recycl () {
        pool.Recycl(this);
	}
}
