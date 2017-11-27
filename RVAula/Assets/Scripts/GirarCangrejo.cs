using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarCangrejo : MonoBehaviour {

	private int r;

	// Use this for initialization
	void Start () {
		r = Random.Range (-4, 4);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, r * Time.deltaTime*10, 0));
	}
}
