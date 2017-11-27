using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Servidor : MonoBehaviour {

	public string connectionIP="127.0.0.1";
	public string connectionPort=25001+"";
	private NetworkView networkView;
	public CoordinadorDeRed coord;

	// Use this for initialization
	void Start () {
		networkView = GetComponent<NetworkView> ();
		initializeServer();
	}
	
	public void initializeServer(){
		Network.InitializeServer(3, int.Parse( connectionPort), false);
		coord.setearObserver(new ServidorObserver(this));
	}

	public void comenzarRecorrido(){
		coord.enviarAClientes ("comenzar&"+connectionIP);
	}

}
