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
		if(r==1)
			rElegida = r1 + "";
		else if(r==2)
			rElegida = r2 + "";
		else if(r==3)
			rElegida = r3 + "";

		string salida = pregunta + "\n" + rElegida;
		if (rElegida.Equals (respuesta)) {
			salida += "\nCORRECTO";
		} else {
			salida+="\nINCORRECTO";
		}
		miEvento.avisarEventoFinalizado (salida);
	}


}
