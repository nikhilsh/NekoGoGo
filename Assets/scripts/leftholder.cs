using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class leftholder : MonoBehaviour {
	public Sprite SquareSprite;
	public Sprite CircleSprite;
	public static Sprite MoveSprite;
	public GameObject urstoff;
	static int count = -1;
	static int hitIndex = -1;
	private static SpriteRenderer spriteRenderer; 
	Sprite publicSprite;
	static List<GameObject> listofleftpoints = new List<GameObject>();

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		initialise ("square");
	}

	void initialise(string shape){
		if (string.Compare (shape, "square") == 0) {
			square ();
		} else if (string.Compare (shape, "circle") == 0){
			circle ();
		}
	}

	public static void check(){
		hitIndex++;

		if (hitIndex >= count*0.7) {
			return true;
		}
		return false;
	}

	public static void clearAllHalo(){
		foreach (GameObject child in listofleftpoints) {
			var temp = (Behaviour)child.GetComponent ("Halo");
			temp.enabled = false;
		}
		hitIndex = 0;
	}

	public static void destroyAllChild(){
		foreach (GameObject child in listofleftpoints) {
			GameObject.Destroy(child);
		}
		listofleftpoints.Clear ();
	}

	void square(Sprite square){
		spriteRenderer.sprite = square;
		count = 0;
		hitIndex = 0;

		for (int sides=0 ; sides<4 ; sides++) {
			if (sides == 0) {
				// top
				int y = 3;
				for (float x = -3; x <= 3; x += 0.5f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name = ""+count;
					count++;
					listofleftpoints.Add (temp);
				}
			} else if (sides == 1) {
				// right
				int x = 3;
				for (float y = 3; y >= -3; y -= 0.5f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name =  ""+count;
					count++;
					listofleftpoints.Add (temp);
				}
			} else if (sides == 2) {
				// bottom
				int y = -3;
				for (float x = 3; x >= -3; x -= 0.5f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name =  ""+count;
					count++;
					listofleftpoints.Add (temp);
				}
			} else {
				// left
				int x = -3;
				for (float y = -3; y <= 3; y += 0.5f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name = ""+count;
					count++;
					listofleftpoints.Add (temp);
				}
			}
		}
	}

	void circle(Sprite circle){
		spriteRenderer.sprite = circle;
		count = 0;
		hitIndex = 0;
		float radius = 3.0f;
		for (float angle = Mathf.PI*2; angle>0.0f ; angle-=0.15f){
			GameObject temp = Instantiate (urstoff, new Vector3 (Mathf.Cos(angle+90.0f)*radius, Mathf.Sin(angle+90.0f)*radius, 0), Quaternion.identity) as GameObject;
			temp.transform.parent = gameObject.transform;
			temp.transform.position += temp.transform.parent.position;
			temp.name = ""+count;
			count++;
			listofleftpoints.Add (temp);
		}
	}

}
