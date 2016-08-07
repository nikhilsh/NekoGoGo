using UnityEngine;
using System.Collections;

public class leftholder : MonoBehaviour {

	public GameObject urstoff;
	static int count = -1;
	static int index = -1;

	void Start () {
		initialise ("square");
	}

	void initialise(string shape){
		if (string.Compare (shape, "square") == 0) {
			square ();
		} else if (string.Compare (shape, "circle") == 0){
			
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
		count = 0;
		index = 0;

		for (int sides=0 ; sides<4 ; sides++) {
			if (sides == 0) {
				// top
				int y = 3;
				for (float x = -3; x <= 3; x += 0.4f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name = ""+count;
					count++;
				}
			} else if (sides == 1) {
				// right
				int x = 3;
				for (float y = 3; y >= -3; y -= 0.4f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name =  ""+count;
					count++;
				}
			} else if (sides == 2) {
				// bottom
				int y = -3;
				for (float x = 3; x >= -3; x -= 0.4f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name =  ""+count;
					count++;
				}
			} else {
				// left
				int x = -3;
				for (float y = -3; y <= 3; y += 0.4f) {
					GameObject temp = Instantiate (urstoff, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
					temp.transform.parent = gameObject.transform;
					temp.transform.position += temp.transform.parent.position;
					temp.name = ""+count;
					count++;
				}
			}
		}
	}

}
