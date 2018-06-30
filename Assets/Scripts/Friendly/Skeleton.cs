using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : FriendlyUnit {

	// Use this for initialization
	void Start () {
		base.Start();
		name = "Skeleton";
		health.setHealth(20);
		health.setMaxhealth(20);
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
