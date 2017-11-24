using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour {

	public string connectionIP="127.0.0.1";
	public int connectionPort=25001;
	NetworkView networkView;

	// Use this for initialization
	void Start () {
		networkView = new NetworkView ();
	}
	
	public void clientConnect(){
		Network.Connect(connectionIP, connectionPort);
	}


	[RPC]
	void transmitirMensaje(string msg)
	{
		
	}

	public void enviar(){
		networkView.RPC("transmitirMensaje", RPCMode.Others, "mensaje de prueba");
	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			clientConnect ();
		}
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			enviar ();
		}
	}
}
