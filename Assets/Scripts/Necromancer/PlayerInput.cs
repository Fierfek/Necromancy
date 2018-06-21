using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public float speed = 1;
	private float x, y;
	private Rigidbody2D body;
	private Vector2 direction;
	Vector2 newPosition;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		direction = Vector2.zero;
		newPosition = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		direction.Set(x, y);

		body.MovePosition(body.position + (direction.normalized * speed) * Time.deltaTime);
	}
}
