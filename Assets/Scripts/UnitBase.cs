using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class UnitBase : MonoBehaviour {

	protected Health health;
	protected GameObject healthBar;

	// Use this for initialization
	public void Start () {
		health = GetComponent<Health>();
	}
}
