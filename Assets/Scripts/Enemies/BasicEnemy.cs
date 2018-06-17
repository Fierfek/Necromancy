using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy {

	// Use this for initialization
	void Start () {
        base.Start();
		name = "Basic Enemy";
		health.setHealth(40);
		health.setMaxhealth(40);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
