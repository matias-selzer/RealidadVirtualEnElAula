using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {

	public Transform[] posiciones;
	private Transform target;
	public int speed;
	public float rotationSpeed;
	public int umbralDistancia;
	private int pos;
	public static bool avanzar=true;

	// Use this for initialization
	void Start () {
		pos = 0;
		target = posiciones [pos];
	}
	
	// Update is called once per frame
	void Update () {
		if (Seek.avanzar) {
			Vector3 nueva = Vector3.Slerp (transform.position, target.position, Time.deltaTime);
			//transform.LookAt(nueva);
			Quaternion fwTarget = Quaternion.LookRotation (target.position - transform.position);
			transform.rotation = Quaternion.Lerp (transform.rotation, fwTarget, rotationSpeed * Time.deltaTime);
			transform.position = transform.position + transform.forward * speed * Time.deltaTime;
			if (Vector3.Distance (transform.position, target.position) < umbralDistancia) {
				if (pos < posiciones.Length - 1) {
					pos++;
					target = posiciones [pos];
					Seek.avanzar = false;
				} else {
					pos = 0;
				}
			}
		}
	}
}
