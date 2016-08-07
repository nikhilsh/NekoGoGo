using UnityEngine;
using System.Collections;

public class rightholder : MonoBehaviour {
	public Sprite SquareSprite;
	public Sprite CircleSprite;
	public GameObject urstoff;
	static int count = -1;
	static int index = -1;
	private SpriteRenderer spriteRenderer; 
	Sprite publicSprite;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		initialise ("circle");
	}

	void initialise(string shape){
		if (string.Compare (shape, "square") == 0) {
			square ();
		} else if (string.Compare (shape, "circle") == 0){
			circle ();
		}
	}

	public static bool check(int hitIndex){
		if (index == -1) {
			return false;
		}
		if (hitIndex == index) {
			index++;
			return true;
		} 

		if (hitIndex == count) {
			// UPDATE THE CAT
			// SOMEHOW MAKE THE FUCKING CAT TAKE ANOTHER STEP!
		}

		return false;
	}

	void square(){

		spriteRenderer.sprite = SquareSprite;
		count = 0;
		index = 0;

		for (int sides=0 ; sides<4 ; sides++) {
			if (sides == 0) {
				// top
				int y = 3;
				for (float x = -3; x <= 3; x += 0.2f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name = ""+count;
					count++;
				}
			} else if (sides == 1) {
				// right
				int x = 3;
				for (float y = 3; y >= -3; y -= 0.2f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name =  ""+count;
					count++;
				}
			} else if (sides == 2) {
				// bottom
				int y = -3;
				for (float x = 3; x >= -3; x -= 0.2f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name =  ""+count;
					count++;
				}
			} else {
				// left
				int x = -3;
				for (float y = -3; y <= 3; y += 0.2f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name = ""+count;
					count++;
				}
			}
		}
	}

	void circle(){
		spriteRenderer.sprite = CircleSprite;
		count = 0;
		index = 0;
		float radius = 3.0f;
		for (float angle = Mathf.PI*2; angle>0.0f ; angle-=0.1f){
			GameObject temp = Instantiate (urstoff, new Vector3 (Mathf.Cos(angle+90.0f)*radius, Mathf.Sin(angle+90.0f)*radius, 0), Quaternion.identity) as GameObject;
			temp.transform.parent = gameObject.transform;
			temp.transform.position += temp.transform.parent.position;
			temp.name = ""+count;
			count++;
		}
	}
}
