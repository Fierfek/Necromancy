using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private GameObject player;
	private Vector2 newPosition;
	private Rigidbody2D body;
	private float speed = 5f;

	public GameObject[] positions;
	public bool[] taken;
	public int numPositions = 64;
	private int numFollowers;
	private float row;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		body = GetComponent<Rigidbody2D>();

		positions = new GameObject[numPositions];
		taken = new bool[numPositions];
		numFollowers = 0;
		row = Mathf.Sqrt(numPositions);

		setupTransforms();
	}

	private void setupTransforms() {

		GameObject temp;

		float x = -row/4, y = -x, z = 0f;

		for (int count = 0; count < numPositions; count++) {
			temp = new GameObject();
			temp.transform.parent = transform;

			//place and offset to center
			temp.transform.localPosition = new Vector3(x + .25f, y -.25f, z);

			//set into array
			positions[count] = temp;
			taken[count] = false;

			//iterate to next position
			x += .5f;

			if ((count > 0) && ((count % row) == 0)) {
				y -= .5f;
				x = -row/4;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null && player.activeSelf) {
			if (Vector2.Distance(transform.position, player.transform.position) >= 3f) {
				newPosition = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

				body.MovePosition(newPosition);

				Vector2 dir = player.transform.position - transform.position;
				dir = player.transform.InverseTransformDirection(dir);
				float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

				body.MoveRotation(angle + 90f);
			}
		}
	}

	public Transform getFollowTransform(int size) {
		bool skip = true;

		switch(size) {
			case 1:
				for (int i = 0; i < numPositions; i++) {
					if ((i % 4 == 0) && (i > 0)) {
						if (skip) {
							i += (int)row - 4;
						}
						else {
							i -= (int)row;
						}
						skip = !skip;
					}

					if ((i % row == 0) && (i > 0)) {
						skip = !skip;
					}

					//Debug.Log(i);

					if (!taken[i]) {
						taken[i] = true;
						return positions[i].transform;
					}
				}
				break;

			case 4:
				for (int i = 0; i < numPositions; i += 2) {
					if((i%4 == 0) && (i > 0)) {
						if(skip) {
							i += (int)row - 4;
						} else {
							i -= (int)row;
						}
						skip = !skip;
					}

					if((i%row == 0) && (i > 0)) {
						skip = !skip;
					}

					if (!taken[i]) {
						taken[i] = true;
						taken[i + 1] = true;
						taken[i + (int)row] = true;
						taken[i + (int)row + 1] = true;
						return positions[i].transform;
					}
				}
				break;

			case 16:
				for (int i = 0; i < numPositions; i += 4) {
					if (!taken[i]) {

						//Set all 16 positions to true;

						taken[i] = true;
						taken[i + 1] = true;
						taken[i + 2] = true;
						taken[i + 3] = true;
						taken[i + (int)row] = true;
						taken[i + (int)row + 1] = true;
						taken[i + (int)row + 2] = true;
						taken[i + (int)row + 3] = true;
						taken[i + (int)row + (int)row] = true;
						taken[i + (int)row + (int)row + 1] = true;
						taken[i + (int)row + (int)row + 2] = true;
						taken[i + (int)row + (int)row + 3] = true;
						taken[i + (int)row + (int)row + (int)row] = true;
						taken[i + (int)row + (int)row + (int)row + 1] = true;
						taken[i + (int)row + (int)row + (int)row + 2] = true;
						taken[i + (int)row + (int)row + (int)row + 3] = true;

						return positions[i].transform;
					}
				}
				break;
		}

		return null;
	}

	public void unFollow(Transform t, int size) {

		//math it out
		float x = t.localPosition.x, y = t.localPosition.y;

		x -= .25f; y += .25f;

		float xpos = ((x + (row / 4f)) * 2f);
		float ypos = ((y + (row / 4f)) * 2f);

		int pos = (int)(ypos * row + xpos);

		switch(size) {
			case 1: taken[pos] = false; break;
			case 2:
				taken[pos] = false;
				taken[pos + 1] = false;
				taken[pos + (int)row] = false;
				taken[pos + (int)row + 1] = false;
				break;
			case 3:
				taken[pos] = false;
				taken[pos + 1] = false;
				taken[pos + 2] = false;
				taken[pos + 3] = false;
				taken[pos + (int)row] = false;
				taken[pos + (int)row + 1] = false;
				taken[pos + (int)row + 2] = false;
				taken[pos + (int)row + 3] = false;
				taken[pos + (int)row + (int)row] = false;
				taken[pos + (int)row + (int)row + 1] = false;
				taken[pos + (int)row + (int)row + 2] = false;
				taken[pos + (int)row + (int)row + 3] = false;
				taken[pos + (int)row + (int)row + (int)row] = false;
				taken[pos + (int)row + (int)row + (int)row + 1] = false;
				taken[pos + (int)row + (int)row + (int)row + 2] = false;
				taken[pos + (int)row + (int)row + (int)row + 3] = false;
				break;
		}
	}
}
