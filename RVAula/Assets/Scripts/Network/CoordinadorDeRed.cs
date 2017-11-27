using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinadorDeRed : MonoBehaviour {

	NetworkView networkView;
	Observer observador;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		networkView = GetComponent<NetworkView>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setearObserver(Observer o){
		observador = o;
	}

	public void clientConnect(string connectionIP,string connectionPort){
		Network.Connect (connectionIP, int.Parse (connectionPort));
		Debug.Log ("Conectando a " + connectionIP + " por el puerto " + connectionPort);
	}

	void OnConnectedToServer(){
		observador.conexionEstablecida ();
	}



	[RPC]
	void transmitirMensaje(string msg)
	{
		Debug.Log ("Mensaje recibido: " + msg);
		observador.consumirMensaje (msg);
	}

	public void enviarAServidor(string mensaje){
		networkView.RPC("transmitirMensaje", RPCMode.Server, mensaje);
	}

	public void enviarAClientes(string mensaje){
		networkView.RPC("transmitirMensaje", RPCMode.Others, mensaje);
	}

}
