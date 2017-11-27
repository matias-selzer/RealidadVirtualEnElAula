using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServidorObserver : Observer {

	public Servidor servidor;

	public ServidorObserver( Servidor c){
		servidor = c;
	}

	public override void consumirMensaje(string mensaje){

	}

	public override void conexionEstablecida(){
		//cliente.conexionEstablecida ();
	}
}
