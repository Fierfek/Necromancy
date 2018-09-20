using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public float speed = 4;
	private float x, y;
	private Rigidbody2D body;
	private Vector2 direction;

	GameObject[] friendlies;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		direction = Vector2.zero;

		friendlies = GameObject.FindGameObjectsWithTag("Friendly");
	}
	
	void FixedUpdate() {
		body.MovePosition(body.position + (direction.normalized * speed) * Time.fixedDeltaTime);
		//transform.position = body.position + (direction.normalized * speed) * Time.fixedDeltaTime;

		
	}

	// Update is called once per frame
	void Update () {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		direction.Set(x, y);

		if(Input.GetButtonDown("FKey")) {
			foreach(GameObject go in friendlies) {
				go.GetComponent<FriendlyUnit>().FollowPlayer();
			}
		}

		//body.velocity = (direction.normalized * speed);
	}
}
