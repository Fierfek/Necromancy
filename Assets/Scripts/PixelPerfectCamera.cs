using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour {

	public int ppi = 48;
	private Camera camera;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
		camera.orthographicSize = (Screen.height / (2 * ppi));
	}
}
