using UnityEngine;
using System.Collections;

public class mainholder : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (leftholder.check () && rightholder.check ()) {
			leftholder.destroyAllChild ();
			rightholder.destroyAllChild ();
		}
	}
}
