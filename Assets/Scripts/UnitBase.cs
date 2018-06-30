using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class UnitBase : MonoBehaviour {

	protected Health health;
	protected GameObject healthBar;
	protected Animator animator;
	protected Rigidbody2D body;

	protected Vector2 newPositon, changePosition;

	public float speed = 3;

	// Use this for initialization
	public void Start () {
		health = GetComponent<Health>();
		animator = GetComponentInChildren<Animator>();
		body = GetComponent<Rigidbody2D>();
	}

	public void Update() {

		//Update Animation direction and state.
		if (changePosition.magnitude > .01f) {
			animator.SetFloat("x", changePosition.x);
			animator.SetFloat("y", changePosition.y);
		}

		if (changePosition.magnitude > 0f) {
			animator.Play("Move");
		}
		else {
			animator.Play("Idle");
		}
	}
}