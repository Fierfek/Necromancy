using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {
	Camera camera;
	public float cameraHeight = -10;
	public Transform target;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.Translate(target.position - transform.position);
	}

	public void setTarget(Transform newTarget) {
		target = newTarget;
	}
}
