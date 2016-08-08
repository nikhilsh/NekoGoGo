using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class rightholder : MonoBehaviour {

	public Sprite SquareSprite;
	public Sprite CircleSprite;
	public GameObject urstoff;

	string shape;
	static int count = -1;
	static int hitIndex = -1;
	private static SpriteRenderer spriteRenderer; 
	static List<GameObject> listofurstoff = new List<GameObject>();

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		shape = mainholder.getLeftShape ();
		initialise (shape);
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
		} else {
			coordinates = new List<float[]> ();
		}

		for (int i = 0; i < coordinates.Count; i++) {
			GameObject temp = Instantiate (urstoff, new Vector3 (coordinates[i][0], coordinates[i][1], 0), Quaternion.identity) as GameObject;
			temp.transform.parent = gameObject.transform;
			temp.transform.position += temp.transform.parent.position;
			temp.name = ""+count;
			count++;
			listofurstoff.Add (temp);
		}
	}

	public static bool check(){
		hitIndex++;

		if (hitIndex >= count*0.5) {
			return true;
		}
		return false;
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
