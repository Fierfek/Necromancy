using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FriendlyUnit : UnitBase {

	protected GameObject player;
	protected Transform target;

	public GameObject follow;
	protected FollowPlayer followPlayer;

	// Use this for initialization
	public void Start () {
		base.Start();

		followPlayer = follow.GetComponent<FollowPlayer>();
	}

	public void Update() {
		if (target != null) {
			if (Vector2.Distance(transform.position, target.position) > 0) {
				newPosition = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
				changePosition = newPosition - body.position;

				transform.position = new Vector3(newPosition.x, newPosition.y, (newPosition.y - 10000) / 10000 * 1.5f);

				body.MovePosition(newPosition);
			} else {
				changePosition = Vector2.zero;
			}
		}

		base.Update();
	}

	public void FollowPlayer() {
		target = followPlayer.getFollowTransform(1);
		Debug.Log(target.localPosition);
		Debug.Log(target.position);
	}

	public void setTarget(Transform target) {
		this.target = target;
	}

	public Transform getTarget() {
		return target;
	}
}
