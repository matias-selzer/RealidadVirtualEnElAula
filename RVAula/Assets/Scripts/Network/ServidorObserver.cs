using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServidorObserver : Observer {

	public Servidor servidor;

	public ServidorObserver( Servidor c){
		servidor = c;
	}

	public override void consumirMensaje(string mensaje){
		string[] mensajes = mensaje.Split ('&');
		if (mensajes [0].Equals ("nombre")) {
			servidor.agregarNuevoUsuario (mensajes [2], mensajes [1]);
		} else if (mensajes [0].Equals ("respuestas")) {
			servidor.asignarRespuestas (mensajes [1], mensajes [2]);
		} else {
			Debug.Log ("problema "+mensaje);
		}
		Debug.Log ("mensaje "+mensaje);
	}

	public override void conexionEstablecida(){
		//cliente.conexionEstablecida ();
	}
}
