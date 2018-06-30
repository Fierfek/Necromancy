using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FriendlyUnit : UnitBase {

	protected GameObject player;

	// Use this for initialization
	public void Start () {
		base.Start();
		player = GameObject.FindGameObjectWithTag("Player"); //TODO: Optimize with dependency injection.
	}

	public void Update() {
		if (player != null && player.activeSelf) {
			if (Vector2.Distance(transform.position, player.transform.position) >= 3f) {
				newPositon = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
				changePosition = newPositon - body.position;
				body.MovePosition(newPositon);
			} else {
				changePosition = Vector2.zero;
			}
		}

		base.Update();
	}
}
