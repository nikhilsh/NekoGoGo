using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mainholder : MonoBehaviour {
	public static string leftShape = "circle";
	public static string rightShape = "circle";
	public static string[] shapes = { "square", "circle", "star", "triangle", "hexagon"};
	public static float tempLoggedTime;
	GameObject theCat;
	CatController _catController;
	GameObject theDog;
	DogController _dogController;
	GameObject[] theClouds;
	List<bgLooper> _bgLooperController = new List<bgLooper>();

	void Start(){
		tempLoggedTime = Time.deltaTime;
		theCat = GameObject.FindWithTag ("CatController");
		_catController = theCat.GetComponent<CatController>();
		theDog = GameObject.FindWithTag ("DogController");
		_dogController = theDog.GetComponent<DogController>();
		theClouds = GameObject.FindGameObjectsWithTag ("BGLooper");
		for (int i = 0; i < theClouds.Length; i++) {
			_bgLooperController.Add (theClouds [i].GetComponent<bgLooper> ());
		}
	}

	// Update is called once per frame
	void Update () {
		if (leftholder.check () && rightholder.check ()) {
			// call ng ping's script!! HERE ADD THE FUCKING POINTS 
			// totalScore += calculateScore(Time.deltaTime-temploggedTime);
			if (!_catController.initialized) {
				_catController.initialized = true;
				_dogController.initialized = true;
				foreach (bgLooper looper in _bgLooperController) {
					looper.initialized = true;
				}
			}
			int score = (int)calculateScore (Time.deltaTime - tempLoggedTime);
			_catController.addscore(score);
			_dogController.addScore(score);
			foreach (bgLooper looper in _bgLooperController) {
				looper.addScore (score);
			}
			// reset tempLoggedTime;
			tempLoggedTime = Time.deltaTime;

			leftholder.destroyAllChild ();
			rightholder.destroyAllChild ();

			int randomnumber = Random.Range (0,shapes.Length);
			leftShape = shapes [randomnumber];
			randomnumber = Random.Range (0,shapes.Length);
			rightShape = shapes [randomnumber];

			randomnumber = Random.Range (0, 361);
			leftholder.changeShape (randomnumber);
			randomnumber = Random.Range (0, 361);
			rightholder.changeShape (randomnumber);
		}
	}

	public static float calculateScore(float timeElapsed){
		if (timeElapsed > 5.0f) {
			return 50;
		} else if ( timeElapsed == 0.0f){
			return 250;
		} else {
			return (250 - timeElapsed*40);
		}
	}

	public static void setLeftShape(string shape){
		leftShape = shape;
	}

	public static void setRightShape(string shape){
		rightShape = shape;
	}

	public static string getLeftShape(){
		return leftShape;
	}

	public static string getRightShape(){
		return rightShape;
	}

	public static List<float[]> getSquareCoordinates(){
		List<float[]> coordinates = new List<float[]> ();
		for (int sides=0 ; sides<4 ; sides++) {
			if (sides == 0) {
				// top
				float y = 2.5f;
				for (float x = -2.5f; x <= 2.5f; x += 0.25f) {
					float[] temp = {x,y};
					coordinates.Add (temp);
				}
			} else if (sides == 1) {
				// right
				float x = 2.5f;
				for (float y = 2.5f; y >= -2.5f; y -= 0.25f) {
					float[] temp = {x,y};
					coordinates.Add (temp);
				}
			} else if (sides == 2) {
				// bottom
				float y = -2.5f;
				for (float x = 2.5f; x >= -2.5f; x -= 0.25f) {
					float[] temp = {x,y};
					coordinates.Add (temp);
				}
			} else {
				// left
				float x = -2.5f;
				for (float y = -2.5f; y <= 2.5f; y += 0.25f) {
					float[] temp = {x,y};
					coordinates.Add (temp);
				}
			}
		}
		return coordinates;
	}

	public static List<float[]> getCircleCoordinates(){
		List<float[]> coordinates = new List<float[]> ();
		float radius = 3.0f;
		for (float angle = Mathf.PI*2; angle>0.0f ; angle-=0.15f){
			float[] temp = {Mathf.Cos(angle+90.0f)*radius, Mathf.Sin(angle+90.0f)*radius};
			coordinates.Add (temp);
		}
		return coordinates;
	}

	public static List<float[]> getStarCoordinates(){
		List<float[]> coordinates = new List<float[]> ();
		List<float[]> endpoints = new List<float[]> ();
		float alpha = (2 * Mathf.PI) / 10.0f; 
		float radius = 3.0f;
		float[] starXY = {0,0};
		for (int i = 11; i != 0; i--){
			var r = radius*(i % 2 + 1)/2;
			var omega = alpha * i;
			float[] temp = {(r * Mathf.Sin(omega)) + starXY[0], (r * Mathf.Cos(omega)) + starXY[1]};
			endpoints.Add(temp);
		}

		for (int i=1 ; i<endpoints.Count ; i++){
			float[] point1 = endpoints [i - 1];
			float[] point2 = endpoints [i];
			float step_x = ( point2[0] - point1[0] )/10.0f;
			float step_y = ( point2[1] - point1[1] )/10.0f;

			// generate points between these 2 endpoints
			for (int step=0 ; step<10 ; step++){
				float[] temp = { point1[0]+(step*step_x), point1[1]+(step*step_y) };
				coordinates.Add (temp);
			}

		}
		return coordinates;
	}

	public static List<float[]> getTriangleCoordinates(){
		float[] triOffset = { 0.0f, 0.0f };
		List<float[]> coordinates = new List<float[]> ();
		List<float[]> endpoints = new List<float[]> ();
		float[] temp1 = { 0, (6.0f * Mathf.Cos (Mathf.PI/6.0f))/2 };
		endpoints.Add(temp1);
		float[] temp2 = { -3.0f, -(6.0f * Mathf.Cos (Mathf.PI/6.0f) )/2};
		endpoints.Add(temp2);
		float[] temp3 = { 3.0f, -(6.0f * Mathf.Cos (Mathf.PI/6.0f) )/2};
		endpoints.Add(temp3);
		float[] temp4 = { 0, (6.0f * Mathf.Cos (Mathf.PI/6.0f))/2};
		endpoints.Add(temp4);

		for (int i=1 ; i<endpoints.Count ; i++){
			float[] point1 = endpoints [i - 1];
			float[] point2 = endpoints [i];
			float step_x = ( point2[0] - point1[0] )/30.0f;
			float step_y = ( point2[1] - point1[1] )/30.0f;

			// generate points between these 2 endpoints
			for (int step=0 ; step<30 ; step++){
				float[] temp = { point1[0]+(step*step_x) + triOffset[0], point1[1]+(step*step_y) + triOffset[1] };
				coordinates.Add (temp);
			}
		}
		return coordinates;
	}

	public static List<float[]> getHexagonCoordinates(){
		List<float[]> coordinates = new List<float[]> ();
		List<float[]> endpoints = new List<float[]> ();

		for (int i=0; i<7 ; i++){
			int angle_deg = 60 * i + 30;
			var angle_rad = Mathf.PI / 180 * angle_deg;
			float[] tempEndPoint = { 3.0f * Mathf.Cos (angle_rad), 3.0f * Mathf.Sin (angle_rad) };
			endpoints.Add (tempEndPoint);
		}

		for (int i=1 ; i<endpoints.Count ; i++){
			float[] point1 = endpoints [i - 1];
			float[] point2 = endpoints [i];
			float step_x = ( point2[0] - point1[0] )/10.0f;
			float step_y = ( point2[1] - point1[1] )/10.0f;

			// generate points between these 2 endpoints
			for (int step=0 ; step<10 ; step++){
				float[] temp = { point1[0]+(step*step_x), point1[1]+(step*step_y) };
				coordinates.Add (temp);
			}
		}
		return coordinates;
	}
}
