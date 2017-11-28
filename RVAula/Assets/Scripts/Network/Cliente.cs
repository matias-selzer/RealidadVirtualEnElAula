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

	public string respuestas="";
	private string miIp;


	// Use this for initialization
	void Start () {
		miIp = Network.player.ipAddress;
		//networkView = new NetworkView ();
		coord.setearObserver(new ClienteObserver(this));
	}




	public void iniciarConexión(){
		nombre = inputNombre.text;
		connectionIP = inputIP.text;
		connectionPort = inputPort.text;
		Debug.Log ("me intento conectar a " + connectionIP + ":" + connectionPort);
		coord.clientConnect (connectionIP,connectionPort);

		SceneManager.LoadScene("PantallaEspera");
	}

	public void iniciarSinConexion(){
		trabajarConConexion = false;
		SceneManager.LoadScene("EscenaHumedal");
	}


	public void comenzar(){
		//iiniciar recorrido
		SceneManager.LoadScene("EscenaHumedal");
	}

	public void conexionEstablecida(){
		coord.enviarAServidor ("nombre&" + miIp + "&" + nombre);
	}

	public void enviarRespuesta(string respuesta){
		if (trabajarConConexion) {
			respuestas += "\n--- PREGUNTA ---\n" + respuesta;
			coord.enviarAServidor ("respuestas&" + miIp + "&" + respuestas);
		}
	}


}