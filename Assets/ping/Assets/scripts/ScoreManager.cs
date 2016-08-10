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

	public GameObject _endGamePanel;
	public GameObject _gold;
	public GameObject _silver;
	public GameObject _bronze;
	public Text finalScore;
	public Text bestScore;


	// Use this for initialization
	void Start () {
		
		initialized = false;

		////////////
		scoreCount = 0;
		pointsHolder = 0;

		if (PlayerPrefs.HasKey ("HighestScore")) {
		
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
		scoreText.text = "" + (int)Mathf.Ceil(scoreCount);
	}

	public void addScore(int points){
		StopCoroutine ("CountTo");
		StartCoroutine ("CountTo", scoreCount+points);

	}


	IEnumerator CountTo (int target) {
		int start = (int)Mathf.Round(scoreCount + pointsPerSecond);
		for (float timer = 0; timer < 1.0F; timer += Time.deltaTime) {
			float progress = timer / 1.0F;
			scoreCount = (int)Mathf.Lerp (start, target, progress);
			yield return null;
		}
		scoreCount = target;
	}

	//call to save high score
	public void endGameScore() {
		PlayerPrefs.SetInt("HighestScore", (int)Mathf.Round(scoreCount));
		int currentStarfishCount = PlayerPrefs.GetInt ("StarfishCount");
		PlayerPrefs.SetInt("StarfishCount", currentStarfishCount+(int)Mathf.Round(scoreCount/100));

		PlayerPrefs.Save ();
	}

}
