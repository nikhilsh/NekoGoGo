using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public Vector3 cloud_3_posMin, cloud_3_posMax;
}

public class StartMenu_Animation : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public GameObject cloud_3;

	void Update () {
	}
}
