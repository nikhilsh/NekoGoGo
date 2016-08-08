using UnityEngine;
using System.Collections;

public class touchscript : MonoBehaviour {
	private Vector3 mousePosition;
	float moveSpeed = 10.0f;

	void Update () {            
		for (var i = 0; i < Input.touchCount; ++i) {
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began) {
				if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
					mousePosition = touch.position;
					mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
					transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
				}
			}
		}

		if (Input.GetMouseButton(0)) {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
		}
	}
}
