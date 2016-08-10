using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSecond;

	public bool initialized;

	public float pointsHolder;

	public AudioClip clickSound;

	public GameObject _endGamePanel;
	public GameObject _gold;
	public GameObject _silver;
	public GameObject _bronze;
	public GameObject _finalScore;
	public GameObject _bestScore;
	public GameObject _homeButton;
	public GameObject _restartButton;
	public GameObject _newScore;
	public Text finalScore;
	public Text bestScore;

	private bool newScore = false;

	// Use this for initialization
	void Start () {
		_endGamePanel.SetActive (false);
		_finalScore.SetActive (false);
		_bestScore.SetActive (false);
		_gold.SetActive (false);
		_silver.SetActive (false);
		_bronze.SetActive (false);
		_homeButton.SetActive (false);
		_restartButton.SetActive (false);
		_newScore.SetActive (false);
		
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
			newScore = true;
			
		}
		scoreText.text = "Distance: " + (int)Mathf.Round(scoreCount);
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
		initialized = false;

		Handheld.Vibrate();

		_endGamePanel.SetActive (true);
		_finalScore.SetActive (true);
		_bestScore.SetActive (true);
		_homeButton.SetActive (true);
		_restartButton.SetActive (true);
		if (newScore) {
			_newScore.SetActive (true);
		}

		if (scoreCount >= 100.0f && scoreCount < 200.0f) {
			_bronze.SetActive (true);
		} else if (scoreCount >= 200.0f && scoreCount < 300.0f) {
			_silver.SetActive (true);
		} else if (scoreCount >= 400.0f) {
			_gold.SetActive (true);
		}

		#if UNITY_IOS
		MoPub.createBanner("86f939fa9c1b4baeab244dbbc89bb094", MoPubAdPosition.BottomCenter );
		#elif UNITY_ANDROID 
		MoPub.createBanner("a9c44550748449d69c44cd3069ddf5f1", MoPubAdPosition.BottomCenter );
		#endif

		PlayerPrefs.SetInt("HighestScore", (int)Mathf.Round(hiScoreCount));
		int currentStarfishCount = PlayerPrefs.GetInt ("StarfishCount");
		PlayerPrefs.SetInt("StarfishCount", currentStarfishCount+(int)Mathf.Round(scoreCount/100));
		finalScore.text = "" + (int)Mathf.Round(scoreCount);
		bestScore.text = "" + (int)Mathf.Round(hiScoreCount);
		PlayerPrefs.Save ();

		PointScript.active = false;
	}

	public void restartGame(){
		AudioSource.PlayClipAtPoint (clickSound, transform.position);
		Application.LoadLevel (Application.loadedLevel);

	}
	public void homeMenu(){
		AudioSource.PlayClipAtPoint (clickSound, transform.position);
		Application.LoadLevel("GameStartMenu");

	}

}
