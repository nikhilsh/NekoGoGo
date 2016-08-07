
using UnityEngine;
using System.Collections;

public class PointScript : MonoBehaviour
{
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch (i);
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
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
						halo.enabled = leftholder.check (int.Parse (hit.transform.gameObject.name));
					} else if (string.Compare (hit.transform.parent.name, "holderright") == 0) {
						halo.enabled = rightholder.check (int.Parse (hit.transform.gameObject.name));
					}

				}
			}
		}
	}


}