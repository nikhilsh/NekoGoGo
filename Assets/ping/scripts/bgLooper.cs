using UnityEngine;
using System.Collections;

public class bgLooper : MonoBehaviour {

	//public Transform spawner;
	//public Transform destroyer;

	public bool initialized;

	public GameObject addOn;

	public float speedMultiplier = 1.5f;
	public float speed;

	public bool faster = false;
	public float movementMultiplier;
	private float moveDistance;

	public float endPoint = -24.0f;
	public float startPoint = 37.44f;

	// Use this for initialization
	void Start () {
	
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
			
			if (faster && moveDistance > 0) {
				moveDistance -= Time.deltaTime;
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed * speedMultiplier, GetComponent<Rigidbody2D> ().velocity.y);
			
			} else if (faster && moveDistance <= 0) {
				faster = false;
			
			} else {
			
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
			}

		}


		if (transform.position.x <= -24.0f) {
			Debug.Log("SPAWN CLOUD");
			newBG ();
		
		}



	}

	public void addScore(int points){
		faster = true;
		moveDistance = points * movementMultiplier;
		//movementTimer = movementTime;
	}

	void newBG(){
		
		Instantiate (addOn,  new Vector3 (37.44f, transform.position.y, transform.position.z), transform.rotation);
		Destroy(this.gameObject);
	
	}
}
