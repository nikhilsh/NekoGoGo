using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mainholder : MonoBehaviour {
	public static Sprite SquareSprite;
	public static Sprite CircleSprite;
	public static GameObject urstoff;

	// Update is called once per frame
	void Update () {
		if (leftholder.check () && rightholder.check ()) {
			leftholder.destroyAllChild ();
			rightholder.destroyAllChild ();
		}
	}

	public static void setLeftHolder(string shape){
		leftholder.initialise (shape);
	}

	public static void setRightHolder(string shape){
		rightholder.initialise (shape);
	}

	public static GameObject getUrstoff(){
		return urstoff;
	}

	public static Sprite getSquareSprite(){
		return SquareSprite;
	}

	public static Sprite getCircleSprite(){
		return CircleSprite;
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
}
