﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CustomisePage : MonoBehaviour {

	private int counter;
	private int number_of_skins;

	public GameObject skin_0;
	public GameObject skin_1;
	public GameObject skin_2;
	public GameObject skin_3;

	public AudioClip barkBark;
	AudioSource audio;
	public Text starFishesText;
	public int starFishes;



	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		if (PlayerPrefs.HasKey ("StarfishCount")) {

			starFishes = PlayerPrefs.GetInt ("StarfishCount");
		} else {
			starFishes = 0;
		}
		counter = 0;
		number_of_skins = 4;
		starFishesText.text = "X" + starFishes;
	}
	
	// Update is called once per frame
	void Update () {
		updateImage (counter);
	}

	public void left () {
		counter = (counter + (number_of_skins - 1)) % number_of_skins;
	}

	public void right () {
		counter = (counter + 1) % number_of_skins;
	}

	public void goHome() {
		Application.LoadLevel("GameStartMenu");
	}

	public void purchase() {
		audio.PlayOneShot (barkBark, 2.0f);
		//AudioSource.PlayClipAtPoint(barkBark, transform.position); 
	}

	void updateImage(int counter) {
		switch (counter) {
		case 0:
			skin_0.SetActive (true);
			skin_1.SetActive (false);
			skin_2.SetActive (false);
			skin_3.SetActive (false);
			break;
		case 1:
			skin_0.SetActive (false);
			skin_1.SetActive (true);
			skin_2.SetActive (false);
			skin_3.SetActive (false);
			break;
		case 2:
			skin_0.SetActive (false);
			skin_1.SetActive (false);
			skin_2.SetActive (true);
			skin_3.SetActive (false);
			break;
		case 3:
			skin_0.SetActive (false);
			skin_1.SetActive (false);
			skin_2.SetActive (false);
			skin_3.SetActive (true);
			break;
		}
	}
}
