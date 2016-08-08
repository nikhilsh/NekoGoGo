using UnityEngine;
using System.Collections;

public class touchscript : MonoBehaviour {
	public int index;
	private Vector3 mousePosition;
	float moveSpeed = 10.0f;

	void Update () {            
		for (var i = 0; i < Input.touchCount; ++i) {
			Touch touch = Input.GetTouch(index);
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
				mousePosition = touch.position;
				mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
				transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
			} else if (touch.phase == TouchPhase.Ended){
				rightholder.clearAllHalo ();
				leftholder.clearAllHalo ();
			}
		}
	}
}
