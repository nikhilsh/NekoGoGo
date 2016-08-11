using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour {
	public float moveSpeed;

	public GameObject smoke;
	GameObject scoremanager;
	ScoreManager _scoremanager;

	public AudioClip meowing;


	private float smokeTimer=0.0f;
	public float smokeTime;
	public float offset = 0.1f;

	// Use this for initialization
	void Start () {
		scoremanager = GameObject.FindWithTag ("ScoreManager");
		_scoremanager = scoremanager.GetComponent<ScoreManager>();

		smokeTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		smokeTimer += Time.deltaTime;
		if (smokeTimer > smokeTime) {
			
			
			Instantiate(smoke, new Vector3(transform.position.x + offset,transform.position.y, transform.position.z ), transform.rotation);
			smokeTimer = 0.0f;
		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void FixedUpdate(){
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "CatController")
		{
			AudioSource.PlayClipAtPoint(meowing, transform.position);  
			Destroy (this.gameObject);
			_scoremanager.addScore (5);


		}
	}
	
}
