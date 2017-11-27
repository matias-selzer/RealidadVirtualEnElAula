using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento : MonoBehaviour {

	private ControladorGeneral controlador;

	// Use this for initialization
	void Start () {
		controlador = GameObject.Find ("ControladorGeneral").GetComponent<ControladorGeneral>() ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void avisarEventoFinalizado(){
		controlador.preguntaRespondida ();
	}

}
