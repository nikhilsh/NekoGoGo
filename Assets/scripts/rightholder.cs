﻿// rightholder

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rightholder : MonoBehaviour {
	public Sprite SquareSprite;
	public Sprite CircleSprite;
	public Sprite StarSprite;
	public Sprite TriangleSprite;
	public Sprite HexagonSprite;
	public Sprite RightHandSprite;

	public GameObject urstoff;

	static float rotateAngle;
	string shape;
	static int count = -1;
	static int hitIndex = -1;
	private static SpriteRenderer spriteRenderer; 
	static List<GameObject> listofurstoff = new List<GameObject>();

	private static GameObject go;
	private static GameObject goUrstoff;
	private Vector3 goUrstoff_Offset = new Vector3 (-0.5f, 0.5f, 0.0f);
	public static bool change = false;
	float angle = 90.0F;
	float speed = (-2 * Mathf.PI) / 5;
	float radius= 2.7F;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		shape = mainholder.getRightShape ();
		initialise (shape);

		go = new GameObject("RightHandSprite");
		SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
		renderer.sprite = RightHandSprite;
		go.transform.parent = transform; // make righthandsprite a child of leftholder
		go.transform.localScale = new Vector3 (0.15F, 0.15F, 1.0F);
		go.transform.position = new Vector3 (spriteRenderer.bounds.center.x, spriteRenderer.bounds.center.y+1.95F, 0);
		go.transform.Rotate (Vector3.forward * 30); 

		goUrstoff = Instantiate(urstoff, new Vector3 (0,0, 0), transform.rotation) as GameObject;
		goUrstoff.transform.parent = transform;
		((Behaviour)goUrstoff.GetComponent ("Halo")).enabled = true;
		goUrstoff.transform.position = go.transform.position + goUrstoff_Offset;
	}

	void Update(){
		if (change) {
			shape = mainholder.getRightShape ();
			initialise (shape);
			rotate ();
		}
		if (go) {
			angle -= 0.025F;
			go.transform.position = new Vector3 (-1.0f*Mathf.Cos (angle * speed) * radius + 4F, -1.0f*Mathf.Sin (-angle * speed) * radius - 1.5F, 0);
			goUrstoff.transform.position = go.transform.position + goUrstoff_Offset;
		} 
	}

	public static void endIntroduction() {
		Destroy (go);
		Destroy (goUrstoff);
	}

	public static void changeShape(float angle){
		change = true;
		rotateAngle = angle;
	}


	void initialise(string shape){
		hitIndex = 0;
		List<float[]> coordinates ;
		if (string.Compare (shape, "square") == 0) {
			coordinates = mainholder.getSquareCoordinates ();
			count = coordinates.Count;
			spriteRenderer.sprite = SquareSprite;
			//square ();
		} else if (string.Compare (shape, "circle") == 0){
			coordinates = mainholder.getCircleCoordinates ();
			count = coordinates.Count;
			spriteRenderer.sprite = CircleSprite;
			//circle ();
		} else if (string.Compare (shape, "star") == 0) { 
			coordinates = mainholder.getStarCoordinates ();
			count = coordinates.Count;
			spriteRenderer.sprite = StarSprite;
		} else if (string.Compare (shape, "triangle") == 0) { 
			coordinates = mainholder.getTriangleCoordinates ();
			count = coordinates.Count;
			spriteRenderer.sprite = TriangleSprite;
		} else if (string.Compare (shape, "hexagon") == 0) { 
			coordinates = mainholder.getHexagonCoordinates ();
			count = coordinates.Count;
			spriteRenderer.sprite = HexagonSprite;
		} else {
			coordinates = new List<float[]> ();
		}

		for (int i = 0; i < coordinates.Count; i++) {
			//			GameObject temp = Instantiate (urstoff, new Vector3 (coordinates[i][0], coordinates[i][1], 0), Quaternion.identity) as GameObject;
			//			temp.transform.parent = gameObject.transform;
			//			temp.transform.position += temp.transform.parent.position;
			//			temp.name = ""+i;
			//			listofurstoff.Add (temp);

			GameObject temp = Instantiate(urstoff, new Vector3 (coordinates[i][0], coordinates[i][1], 0), transform.rotation)  as GameObject;
			// temp.velocity = transform.TransformDirection( Vector3 (0, 1,     speed));
			temp.transform.parent = transform;
			temp.transform.localPosition = new Vector3 (coordinates[i][0], coordinates[i][1], 0);
			temp.name = ""+i;
			listofurstoff.Add (temp);
		}

		change = false;
	}

	public static bool check(){
//		Debug.Log ("right check: " + hitIndex);

		if (hitIndex >= count*0.65) {
			Debug.Log ("right check: True");
			return true;
		}
		return false;
	}

	public static void hit(){
		hitIndex++;
	}

	public static void clearAllHalo(){
		foreach (GameObject child in listofurstoff) {
			var temp = (Behaviour)child.GetComponent ("Halo");
			temp.enabled = false;
		}
		hitIndex = 0;
	}

	public static void destroyAllChild(){
		foreach (GameObject child in listofurstoff) {
			GameObject.Destroy(child);
		}
		spriteRenderer.sprite = new Sprite ();
		listofurstoff.Clear ();
	}

	void rotate (){
		gameObject.transform.Rotate (Vector3.forward * rotateAngle);
	}

	//	void square(){
	//		spriteRenderer.sprite = SquareSprite;
	//		count = 0;
	//		hitIndex = 0;
	//
	//		for (int sides=0 ; sides<4 ; sides++) {
	//			if (sides == 0) {
	//				// top
	//				int y = 3;
	//				for (float x = -3; x <= 3; x += 0.5f) {
	//					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
	//					temp.transform.parent = gameObject.transform;
	//					temp.transform.position += temp.transform.parent.position;
	//					temp.name = ""+count;
	//					count++;
	//					listofrightpoints.Add (temp);
	//				}
	//			} else if (sides == 1) {
	//				// right
	//				int x = 3;
	//				for (float y = 3; y >= -3; y -= 0.5f) {
	//					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
	//					temp.transform.parent = gameObject.transform;
	//					temp.transform.position += temp.transform.parent.position;
	//					temp.name =  ""+count;
	//					count++;
	//					listofrightpoints.Add (temp);
	//				}
	//			} else if (sides == 2) {
	//				// bottom
	//				int y = -3;
	//				for (float x = 3; x >= -3; x -= 0.5f) {
	//					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
	//					temp.transform.parent = gameObject.transform;
	//					temp.transform.position += temp.transform.parent.position;
	//					temp.name =  ""+count;
	//					count++;
	//					listofrightpoints.Add (temp);
	//				}
	//			} else {
	//				// left
	//				int x = -3;
	//				for (float y = -3; y <= 3; y += 0.5f) {
	//					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
	//					temp.transform.parent = gameObject.transform;
	//					temp.transform.position += temp.transform.parent.position;
	//					temp.name = ""+count;
	//					count++;
	//					listofrightpoints.Add (temp);
	//				}
	//			}
	//		}
	//	}
	//
	//	void circle(){
	//		spriteRenderer.sprite = CircleSprite;
	//		count = 0;
	//		hitIndex = 0;
	//		float radius = 3.0f;
	//		for (float angle = Mathf.PI*2; angle>0.0f ; angle-=0.15f){
	//			GameObject temp = Instantiate (urstoff, new Vector3 (Mathf.Cos(angle+90.0f)*radius, Mathf.Sin(angle+90.0f)*radius, 0), Quaternion.identity) as GameObject;
	//			temp.transform.parent = gameObject.transform;
	//			temp.transform.position += temp.transform.parent.position;
	//			temp.name = ""+count;
	//			count++;
	//			listofrightpoints.Add (temp);
	//		}
	//	}
}
