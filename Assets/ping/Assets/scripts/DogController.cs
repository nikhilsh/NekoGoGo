using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogController : MonoBehaviour {

	public Transform cat;
	public Transform dog;
	//public Transform sweatSpot;

	public GameObject catSprite;
	public GameObject dogSprite;
	public GameObject sweatAnim;

	public GameObject explosion;
	public GameObject dogBark;

	public float moveSpeed = 3.0f;
	public float tooCloseDistance = 5.0f;
	public bool tooClose = false;

	public bool moveBack = false;
	public float moveDistance; 
	public float moveBackMultiplier = 0.1f;
	//public const float movementTime = 0.5;
	//private float movementTimer = 0.0f;

	public bool initialized = false;
	public bool gameOver = false;

	public AudioClip barking;
	public AudioClip growling;
	public AudioClip endGameSound;
	//AudioSource audio;
	public float soundTime;
	private float soundTimeCounter;

	public float growlTime;
	private float growlTimeCounter;

	GameObject[] theClouds;
	List<bgLooper> _bgLooperController = new List<bgLooper>();


	Animator animator;

	const int STATE_NOBARK = 0;
	const int STATE_BARK = 1;

	public int _currentAnimationState = STATE_NOBARK;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();

		theClouds = GameObject.FindGameObjectsWithTag ("BGLooper");
		for (int i = 0; i < theClouds.Length; i++) {
			_bgLooperController.Add (theClouds [i].GetComponent<bgLooper> ());
		}
	}

	// Update is called once per frame
	void Update () {
		//INPUT CONTROLS

		if (Input.GetKeyDown (KeyCode.F)){
			addScore (50);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			initialized = true;
		}
		/////////
		//SETACTIVE CONTROLS

		if (gameObject.transform.position.x < -9.65 && gameObject.transform.position.x >= -11.15) {
			dogBark.SetActive (true);
			growlTimeCounter -= Time.deltaTime;
			if (growlTimeCounter <= 0) {
				AudioSource.PlayClipAtPoint (growling, transform.position);
				growlTimeCounter = growlTime;
			}
		} else {
			dogBark.SetActive (false);
		}

		if (tooClose) {
			sweatAnim.SetActive (true);

		} else {
			sweatAnim.SetActive (false);
		}
		////////////////
		//PROXIMITY CONTROL
		if (cat.position.x - dog.position.x > tooCloseDistance) {
			changeState (STATE_NOBARK);
			tooClose = false;
		} else if (cat.position.x - dog.position.x <= tooCloseDistance && cat.position.x - dog.position.x >0){
			changeState (STATE_BARK);
			tooClose = true;
			//audio.PlayOneShot (barking, 2.0f);
			//AudioSource.PlayClipAtPoint(barking, transform.position); 
			soundTimeCounter -= Time.deltaTime;

			if (soundTimeCounter <= 0) {
			
				AudioSource.PlayClipAtPoint (barking, transform.position);
				soundTimeCounter = soundTime;
			}


		} else if (cat.position.x - dog.position.x <= 0 && gameOver== false){
			endGame();
			AudioSource.PlayClipAtPoint(endGameSound, transform.position); 
			foreach (bgLooper looper in _bgLooperController) {
				looper.initialized = false;
			}
		}



	
		if (initialized) {

			if (moveBack && moveDistance > 0) {
				moveDistance -= Time.deltaTime;

				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		
			} else if (moveBack && moveDistance <= 0) {
		
				moveBack = false;
			} else {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			}
		}


	}

	void changeState(int state){
		if (_currentAnimationState == state) {
			return;
		}

		switch (state) {
		case STATE_NOBARK:
			animator.SetInteger ("state", STATE_NOBARK);
			break;
		case STATE_BARK:
			animator.SetInteger ("state", STATE_BARK);
			break;

		}
		_currentAnimationState = state;
	}

	public void addScore(int points){
		moveBack = true;
		moveDistance = points * moveBackMultiplier;
		//movementTimer = movementTime;
		
	}



	public void endGame(){
		Instantiate (explosion, cat.position, cat.rotation);
		gameOver = true;
		catSprite.SetActive (false);
		dogSprite.SetActive (false);
		Debug.Log("STOP");

	}
		
}
