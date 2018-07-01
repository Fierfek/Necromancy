using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	private SpriteMask mask;
	private Transform colorBar;
	private SpriteRenderer healthColor;

	//Define a color range
	public float percentHealth, newHealth;
	private Vector3 maskScale;

	private Color color;

	// Use this for initialization
	void Start () {
		mask = GetComponentInChildren<SpriteMask>();
		colorBar = transform.GetChild(0);
		healthColor = colorBar.GetComponent<SpriteRenderer>();

		maskScale = Vector3.one;
		newHealth = percentHealth = 1f;

		color = new Color(1f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(newHealth != percentHealth) {
			percentHealth = newHealth;
			maskScale.x = percentHealth;
			mask.transform.localScale = maskScale;

			if(percentHealth >= .5f) {
				color.r = (-2f * percentHealth) + 2;
				color.g = 1f;
			} else {
				color.r = 1f;
				color.g = percentHealth * 2;
			}

			healthColor.color = color;
		}
	}

	public void set(float percentHealth) {
		newHealth = percentHealth;
	}
}
