using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorrido : MonoBehaviour {

	public Transform[] posiciones;
	public Transform camara;
	private Transform target;
	public int speed;
	public float rotationSpeed;
	public int umbralDistancia;
	private int pos;
	public bool hayQueAvanzar=true;

	// Use this for initialization
	void Start () {
		pos = 0;
		target = posiciones [pos];
		GameObject.Find ("ControladorGeneral").GetComponent<ControladorGeneral> ().establecerRecorrido (this);
	}
	
	// Update is called once per frame
	void Update () {
		if (hayQueAvanzar) {
			Vector3 nueva = Vector3.Slerp (camara.position, target.position, Time.deltaTime);
			//transform.LookAt(nueva);
			Quaternion fwTarget = Quaternion.LookRotation (target.position - camara.position);
			camara.rotation = Quaternion.Lerp (camara.rotation, fwTarget, rotationSpeed * Time.deltaTime);
			camara.position = camara.position + camara.forward * speed * Time.deltaTime;
			if (Vector3.Distance (camara.position, target.position) < umbralDistancia) {
				if (pos < posiciones.Length - 1) {
					pos++;
					target = posiciones [pos];
					hayQueAvanzar = false;
					ControladorPointer.activo = true;
				} 
			}
		}
	}

	public void avanzar(){
		hayQueAvanzar = true;
		ControladorPointer.activo = false;
	}
}
