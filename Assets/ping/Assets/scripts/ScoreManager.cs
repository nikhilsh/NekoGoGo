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
	public GameObject _finalScore;
	public GameObject _bestScore;
	public Text finalScore;
	public Text bestScore;


	// Use this for initialization
	void Start () {
		_endGamePanel.SetActive (false);
		_finalScore.SetActive (false);
		_bestScore.SetActive (false);
		_gold.SetActive (false);
		_silver.SetActive (false);
		_bronze.SetActive (false);
		
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

		_endGamePanel.SetActive (true);
		_finalScore.SetActive (true);
		_bestScore.SetActive (true);

		if (scoreCount >= 100.0f && scoreCount < 200.0f) {
			_bronze.SetActive (true);
		} else if (scoreCount >= 200.0f && scoreCount < 300.0f) {
			_silver.SetActive (true);
		} else if (scoreCount >= 400.0f) {
			_gold.SetActive (true);
		}


		PlayerPrefs.SetInt("HighestScore", (int)Mathf.Round(hiScoreCount));
		int currentStarfishCount = PlayerPrefs.GetInt ("StarfishCount");
		PlayerPrefs.SetInt("StarfishCount", currentStarfishCount+(int)Mathf.Round(scoreCount/100));
		finalScore.text = "" + (int)Mathf.Round(scoreCount);
		bestScore.text = "" + (int)Mathf.Round(hiScoreCount);
		PlayerPrefs.Save ();
	}

}
