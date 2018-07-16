using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {
	Camera camera;
	public float cameraHeight = -10;
	public float cameraSpeed;
	public Transform target;

	private float maxDelta = 0f;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//Reduces Jitter during movement. 1.02 eliminates jitter of character movement while maximizing jitter reduction fo world.
		maxDelta = Vector3.Distance(transform.position, target.position) / (Mathf.Pow(1.02f, 2));
		transform.position = Vector3.MoveTowards(transform.position, target.position, maxDelta);
		//transform.Translate(target.position - transform.position);
	}

	public void setTarget(Transform newTarget) {
		target = newTarget;
	}
}
