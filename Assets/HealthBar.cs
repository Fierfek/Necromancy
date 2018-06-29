using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	private Health health;
	private float maxHealth, current;

	// Use this for initialization
	void Start () {
		health = GetComponentInParent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		maxHealth = health.getMaxHealth();
		current = health.getHealth();
	}
}
