using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarCamara : MonoBehaviour {

	private Transform camara;

	// Use this for initialization
	void Start () {
		camara = GameObject.Find ("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (2 * transform.position - camara.position);
	}
}
