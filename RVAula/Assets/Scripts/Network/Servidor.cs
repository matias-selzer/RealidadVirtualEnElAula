using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servidor : MonoBehaviour {

	public string connectionIP="127.0.0.1";
	public int connectionPort=25001;

	// Use this for initialization
	void Start () {
		NetworkView networkView = new NetworkView ();
		initializeServer();
	}
	
	public void initializeServer(){
		Network.InitializeServer(3, connectionPort, false);
	}


	[RPC]
	void transmitirMensaje(string msg)
	{
		Debug.Log ("mensaje");
	}
}
