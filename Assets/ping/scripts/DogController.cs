using UnityEngine;
using System.Collections;

public class DogController : MonoBehaviour {

	public Transform cat;
	public Transform dog;
	//public Transform sweatSpot;

	public GameObject catSprite;
	public GameObject dogSprite;
	public GameObject sweatAnim;

	public GameObject explosion;

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

	Animator animator;

	const int STATE_NOBARK = 0;
	const int STATE_BARK = 1;

	public int _currentAnimationState = STATE_NOBARK;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.F)){
			addScore (50);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			initialized = true;
		}



		if (cat.position.x - dog.position.x > tooCloseDistance) {
			changeState (STATE_NOBARK);
			tooClose = false;
		} else if (cat.position.x - dog.position.x <= tooCloseDistance && cat.position.x - dog.position.x >0){
			changeState (STATE_BARK);
			tooClose = true;
		} else if (cat.position.x - dog.position.x <= 0 && gameOver== false){
			endGame();
		}

		if (tooClose) {
			sweatAnim.SetActive (true);

		
		} else {
			sweatAnim.SetActive (false);
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
		catSprite.SetActive (false);
		dogSprite.SetActive (false);
		gameOver = true;
		Debug.Log("STOP");

	}
		
}
