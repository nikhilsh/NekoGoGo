using UnityEngine;
using System.Collections;


public class CatController : MonoBehaviour {

	//public float walkSpeed = 1.0f;
	//public bool jumping = false;

	public bool grounded;
	//public Transform groundCheck;
	//public float groundCheckRadius;
	public LayerMask whatIsGround;
	private Collider2D myCollider;

	public bool initialized = false;
	private bool meowDone = false;


	public float jumpHeight;

	//public float timeLeft = 0.0f;


	//public float addscore = 0;

	private int _walking = 50;
	private bool _running = false;
	private float runTime;
	public float runTimeMultiplier = 0.025f;

	//SOUNDS
	public AudioClip meowing;
	public AudioClip startMeow;
	public AudioClip clipStartIntro;
	public AudioClip clipChillLoop;
	public AudioClip clipParanoidTransit;
	public AudioClip clipParanoidLoop;

	//public float clipStartIntroTime;
	//public float clipStartTimer = 0.01f;


	public bool dogIsClose=false;
	AudioSource audio;

	//score prompts
	public Transform scoreComment;
	public GameObject _excellent;
	public GameObject _great;
	public GameObject _cool;
	public GameObject _bad;
	public GameObject _nekoGOGO;
	public GameObject _instructions;

	private int tempAnim;

	Animator animator;

	const int STATE_REST = 0;
	const int STATE_WALK = 1;
	const int STATE_RUN = 2;
	const int STATE_JUMP = 3;

	public int _currentAnimationState = STATE_REST;

	private static float accelerometerUpdateInterval = 1.0F / 60.0F;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
	private static float lowPassKernelWidthInSeconds = 1.0F;
	// This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! ;)
	private static float shakeDetectionThreshold = 2.0F;

	private static float lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
	private static Vector3 lowPassValue = Vector3.zero;
	private static Vector3 acceleration;
	private static Vector3 deltaAcceleration;


	// Use this for initialization
	void Start () {
		myCollider = GetComponent<Collider2D> ();
		animator = this.GetComponent<Animator> ();

		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
		//audio = GetComponent<AudioSource> ();
	
	}

	void FixedUpdate(){
	
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space) && grounded && _currentAnimationState != 0) {
			tempAnim = _currentAnimationState;
			
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
			changeState (STATE_JUMP);

		}


	
		if (grounded && _currentAnimationState == 3) {
			changeState (tempAnim);
			tempAnim = _currentAnimationState;
		}


		if (grounded == true) {
		
			animator.SetBool ("grounded", true);
		} else {
			animator.SetBool ("grounded", false);
		}


		//for debugging
		if (Input.GetKeyDown (KeyCode.F)){
			addscore(50);
		}


		if (_currentAnimationState != 3) {

			if (_running && runTime > 0) {

				changeState (STATE_RUN);
				runTime -= Time.deltaTime;
			} else if (_running && runTime <= 0) {
				_running = false;
				changeState (STATE_WALK);
			}
			
		}

		
		if (initialized || Input.GetKeyDown (KeyCode.A)) {
			//AudioSource.PlayClipAtPoint(startMeow, transform.position); 

			_instructions.SetActive (false);
			if (meowDone == false){
				Instantiate(_nekoGOGO,scoreComment.position, scoreComment.rotation);
				AudioSource.PlayClipAtPoint(startMeow, transform.position); 
				AudioSource.PlayClipAtPoint (clipStartIntro, transform.position);
				//audio.PlayOneShot (clipStartIntro, 1.0f);
				/* clipStartTimer += clipStartIntroTime;
				if (clipStartTimer >= 0) {
					clipStartTimer -= Time.deltaTime;
					AudioSource.PlayClipAtPoint (clipStartIntro, transform.position);
				} */
			}
			meowDone = true;
			animator.SetBool ("initialized", true);
			changeState (STATE_WALK);

		}

		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;
		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold && grounded && _currentAnimationState != 0) {
			// Perform your "shaking actions" here, with suitable guards in the if check above, if necessary to not, to not fire again if they're already being performed.
			tempAnim = _currentAnimationState;

			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
			changeState (STATE_JUMP);
		}

		/*if (audio.isPlaying && !dogIsClose) {
			AudioSource.PlayClipAtPoint (clipChillLoop, transform.position);
		}*/


	}

	void changeState(int state){
		if (_currentAnimationState == state) {
			return;
		}

		switch (state) {
		case STATE_REST:
			animator.SetInteger ("state", STATE_REST);
			break;
		case STATE_WALK:
			animator.SetInteger ("state", STATE_WALK);
			break;
		case STATE_RUN:
			animator.SetInteger ("state", STATE_RUN);
			break;
		case STATE_JUMP:
			animator.SetInteger ("state", STATE_JUMP);
			break;

		}
		_currentAnimationState = state;
	}

	public void addscore(int points){
		//audio.PlayOneShot (meowing, 2.0f);
		AudioSource.PlayClipAtPoint(meowing, transform.position);  
		runTime = points * runTimeMultiplier;
		_running = true;

		if (points < 5) {
			Instantiate (_bad, scoreComment.position, scoreComment.rotation);
		} else if (points >= 5 && points < 10) {
			Instantiate (_cool, scoreComment.position, scoreComment.rotation);
		}else if (points >= 10 && points < 15) {
			Instantiate (_great, scoreComment.position, scoreComment.rotation);
		}else if (points >= 15) {
			Instantiate (_excellent, scoreComment.position, scoreComment.rotation);
		}



	}





	/*void catRun(float score){
		// function to make cat run for period of time proportional to score added
		changeState(STATE_RUN);
		timeLeft = score * runTimeMultiplier;
		while (timeLeft >= 0) {
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0) {
				changeState (STATE_WALK);
				break;
			};
		}


	private void OnDrawGizmosSelected(){

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position + m_Position, m_radius);
	}
	*/


	
	}





