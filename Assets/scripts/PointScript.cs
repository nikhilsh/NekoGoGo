
using UnityEngine;
using System.Collections;

public class PointScript : MonoBehaviour
{
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch (i);
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
				leftholder.endIntroduction ();
				rightholder.endIntroduction ();
				var ray = Camera.main.ScreenPointToRay (touch.position);
				var halo = (Behaviour)GetComponent ("Halo");
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit) && hit.transform.gameObject.GetComponent ("Halo")) {
					halo = (Behaviour)hit.transform.gameObject.GetComponent ("Halo");
				} else {
					return;
				}

				if (!halo.enabled) {
					if (string.Compare (hit.transform.parent.name, "holderleft") == 0) {
						leftholder.hit ();
						halo.enabled = true;
					} else if (string.Compare (hit.transform.parent.name, "holderright") == 0) {
						rightholder.hit ();
						halo.enabled = true;
					}

				}
			}
		}
	}


}