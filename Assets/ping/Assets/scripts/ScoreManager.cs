using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSecond;

	public bool initialized;

	public float pointsHolder;

	// Use this for initialization
	void Start () {
		
		initialized = false;

		////////////
		scoreCount = 0;
		pointsHolder = 0;

		if (PlayerPrefs.GetInt ("HighestScore") != null) {
		
			hiScoreCount = PlayerPrefs.GetInt ("HighestScore");
		} else {
			hiScoreCount = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.F)){
			addScore (50);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			initialized = true;
		}

		if (initialized) {
			
			scoreCount += pointsPerSecond * Time.deltaTime;

		
		}
		if (scoreCount > hiScoreCount) {
			hiScoreCount = scoreCount;
			
		}

		scoreText.text = "" + (int)Mathf.Round(scoreCount);

	
	}

	public void addScore(int points){
		StopCoroutine ("CountTo");
		StartCoroutine ("CountTo", scoreCount+points);

	}


	IEnumerator CountTo (int target) {
		int start = (int)Mathf.Round(scoreCount);
		for (float timer = 0; timer < 1.0F; timer += Time.deltaTime) {
			float progress = timer / 1.0F;
			scoreCount = (int)Mathf.Lerp (start, target, progress);
			yield return null;
		}
		scoreCount = target;
	}

}
