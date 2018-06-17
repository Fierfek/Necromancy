using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour {

    protected Health health;

	// Use this for initialization
    public void Start () {
        health = GetComponent<Health>();
	} 
}
