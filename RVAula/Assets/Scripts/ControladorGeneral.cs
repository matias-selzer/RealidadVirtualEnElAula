using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGeneral : MonoBehaviour {

	public Recorrido recorrido;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void continuarRecorrido(){
		recorrido.avanzar ();
	}

	public void preguntaRespondida(){
		continuarRecorrido ();
	}
}
