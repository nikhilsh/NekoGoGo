
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
				var ray2 = Camera.main.ScreenPointToRay (touch.position);

				var halo = (Behaviour)GetComponent ("Halo");
				RaycastHit hit;
				float thickness = 1f; //<-- Desired thickness here.
				Vector3 origin = transform.position + new Vector3(0,0.6f,-1.6f);
				Vector3 direction = transform.TransformDirection(Vector3.forward);

				if (Physics.SphereCast(ray.origin, thickness, ray.direction, out hit) && hit.transform.gameObject.GetComponent ("Halo")) {
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