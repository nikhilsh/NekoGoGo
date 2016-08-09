﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public Vector3 cloud_3_posMin, cloud_3_posMax;
	public Vector3 cloud_2_posMin, cloud_2_posMax;
	public Vector3 cloud_1_posMin, cloud_1_posMax;
}

public class StartMenu_Animation : MonoBehaviour {
	
	private bool cloud_3_dirRight = true;
	private bool cloud_2_dirRight = true;
	private bool cloud_1_dirRight = true;

	public float speed;
	public Boundary boundary;
	public GameObject cloud_3;
	public GameObject cloud_2;
	public GameObject cloud_1;

	void Update () {
		Debug.Log (cloud_1.transform.position.x);
		animate_cloud_3 ();
		animate_cloud_2 ();
		animate_cloud_1 ();
	}

	private void animate_cloud_3() {
		if (cloud_3_dirRight)
			cloud_3.transform.Translate (Vector3.right * speed * Time.deltaTime);
		else
			cloud_3.transform.Translate (-Vector3.right * speed * Time.deltaTime);
		if (cloud_3.transform.position.x >= boundary.cloud_3_posMax.x) {
			cloud_3_dirRight = false;
		}
		if (cloud_3.transform.position.x <= boundary.cloud_3_posMin.x) {
			cloud_3_dirRight = true;
		}
	}

	private void animate_cloud_2() {
		if (cloud_2_dirRight)
			cloud_2.transform.Translate (Vector3.right * speed * Time.deltaTime);
		else
			cloud_2.transform.Translate (-Vector3.right * speed * Time.deltaTime);
		if (cloud_2.transform.position.x >= boundary.cloud_2_posMax.x) {
			cloud_2_dirRight = false;
		}
		if (cloud_2.transform.position.x <= boundary.cloud_2_posMin.x) {
			cloud_2_dirRight = true;
		}
	}

	private void animate_cloud_1() {
		if (cloud_1_dirRight)
			cloud_1.transform.Translate (Vector3.right * speed * Time.deltaTime);
		else
			cloud_1.transform.Translate (-Vector3.right * speed * Time.deltaTime);
		if (cloud_1.transform.position.x >= boundary.cloud_1_posMax.x) {
			cloud_1_dirRight = false;
		}
		if (cloud_1.transform.position.x <= boundary.cloud_1_posMin.x) {
			cloud_1_dirRight = true;
		}
	}
}
