using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class StartMenu_Button : MonoBehaviour {

	public AudioClip click;
	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource> ();
	}

	public void startGame() {
		audio.PlayOneShot (click, 2.0f);
		Application.LoadLevel ("DUMMY_GameStart");
	}
		
}
