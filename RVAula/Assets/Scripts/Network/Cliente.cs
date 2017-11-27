using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cliente : MonoBehaviour {

	public CoordinadorDeRed coord;
	public bool trabajarConConexion=true;

	public string connectionIP="127.0.0.1";
	public string connectionPort=25001+"";
	public string nombre;

	public InputField inputNombre;
	public InputField inputIP;
	public InputField inputPort;


	// Use this for initialization
	void Start () {
		//networkView = new NetworkView ();
		coord.setearObserver(new ClienteObserver(this));
	}




	public void iniciarConexión(){
		nombre = inputNombre.text;
		connectionIP = inputIP.text;
		connectionPort = inputPort.text;

		coord.clientConnect (connectionIP,connectionPort);
		coord.enviarAServidor ("nombre&" + connectionIP + "&" + nombre);
		SceneManager.LoadScene("PantallaEspera");
	}

	public void iniciarSinConexion(){
		trabajarConConexion = false;
		//arrancar recorrido
	}


	public void comenzar(){
		//iiniciar recorrido
		SceneManager.LoadScene("EscenaHumedal");
	}


}