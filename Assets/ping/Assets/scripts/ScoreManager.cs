using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSecond;

	public bool initialized;
	public float CountInterval = 0.05f, timer=0;
	int i=0;
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
			//Debug.Log (scoreCount);
		
		}
		if (scoreCount > hiScoreCount) {
			hiScoreCount = scoreCount;
			
		}


		if(i<scoreCount && timer>=CountInterval)
		{
			i++;
			scoreText.text = "" + Mathf.Round(scoreCount);
			timer=0;
		}
	
	}

	public void addScore(int points){
		pointsHolder += points;

	}

}
