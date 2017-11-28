using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta : MonoBehaviour {

	Evento miEvento;
	public string pregunta,r1,r2,r3,rElegida,respuesta;

	// Use this for initialization
	void Start () {
		miEvento = GetComponent<Evento> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void asignarRespuesta(int r){
		rElegida = r + "";
		string salida = pregunta + "\n" + rElegida;
		if (rElegida.Equals (respuesta)) {
			salida += "\nCORRECTO";
		} else {
			salida+="\nINCORRECTO";
		}
		miEvento.avisarEventoFinalizado (salida);
	}


}
