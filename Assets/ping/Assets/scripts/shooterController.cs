using UnityEngine;
using System.Collections;

public class shooterController : MonoBehaviour {
	public GameObject spawnObject;
	public float maxTime = 5;
	public float minTime = 2;

	private float time;
	private float spawnTime;

	public AudioClip flySound;

	GameObject scoremanager;
	ScoreManager _scoremanager;

	// Use this for initialization
	void Start () {
		setRandomTime ();
		time = minTime;

		scoremanager = GameObject.FindWithTag ("ScoreManager");
		_scoremanager = scoremanager.GetComponent<ScoreManager>();
	}

	void FixedUpdate(){
		if (_scoremanager.initialized) {
			time += Time.deltaTime;
			if (time >= spawnTime) {
				SpawnObject ();
				setRandomTime ();
			}
		}
	}
	
	void SpawnObject(){
		time = 0;
		Instantiate (spawnObject, transform.position, spawnObject.transform.rotation);
		AudioSource.PlayClipAtPoint(flySound, transform.position);  

	}

	void setRandomTime(){
		spawnTime = Random.Range (minTime, maxTime);
	}
}
