using UnityEngine;
using System.Collections;

public class commentDestroyScript : MonoBehaviour {
	public float destroyTime;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = destroyTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			Destroy (gameObject);
		
		}
	}
}
