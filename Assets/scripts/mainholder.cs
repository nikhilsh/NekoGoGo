﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mainholder : MonoBehaviour {
	public static string leftShape = "star";
	public static string rightShape = "star";
	public static string[] shapes = { "square", "circle", "star"};

	// Update is called once per frame
	void Update () {
		if (leftholder.check () && rightholder.check ()) {
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
				int y = 3;
				for (float x = -3; x <= 3; x += 0.5f) {
					float[] temp = {x,y};
					coordinates.Add (temp);
				}
			} else if (sides == 1) {
				// right
				int x = 3;
				for (float y = 3; y >= -3; y -= 0.5f) {
					float[] temp = {x,y};
					coordinates.Add (temp);
				}
			} else if (sides == 2) {
				// bottom
				int y = -3;
				for (float x = 3; x >= -3; x -= 0.5f) {
					float[] temp = {x,y};
					coordinates.Add (temp);
				}
			} else {
				// left
				int x = -3;
				for (float y = -3; y <= 3; y += 0.5f) {
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
}
