using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGeneral : MonoBehaviour {

	public Recorrido recorrido;
	public Cliente cliente;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void continuarRecorrido(){
		recorrido.avanzar ();
	}

	public void preguntaRespondida(string respuesta){
		cliente.enviarRespuesta (respuesta);
		continuarRecorrido ();
	}

	public void establecerRecorrido (Recorrido r){
		recorrido = r;
	}
}
