using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public Vector3 holdingZone = new Vector3(100, 100, -100);
	private Quaternion holdingRotation;

	private Dictionary<string, Queue<GameObject>> types;
	private Queue<GameObject> pool;

    // Use this for initialization
    void Awake () {
        types = new Dictionary<string, Queue<GameObject>>();
		holdingRotation.eulerAngles = new Vector3(0, 0, 0);
    }

	public void addType(string type, GameObject prefab, int number) {
		if(!types.ContainsKey(type)) {
			pool = new Queue<GameObject>();
			for(int i = 0; i < number; i ++) {
				pool.Enqueue(Instantiate(prefab, holdingZone, holdingRotation));
			}
			types.Add(type, pool);
		}
	}

	public void removeType(string type) {
		if(types.ContainsKey(type)) {
			types.Remove(type);
		}
	}

	public GameObject unPool(string type) {
		if(types.ContainsKey(type)) {
			types.TryGetValue(type, out pool);
			if(pool.Count >= 0) {
				return pool.Dequeue();
			}
		}
		return null;
	}

	public void rePool(string type, GameObject go) {
		if(types.ContainsKey(type)) {
			types.TryGetValue(type, out pool);
			pool.Enqueue(go);
		}
	}
}
