using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenuPrincipal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UnityEngine.XR.XRSettings.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ejecutarServidor(){
		SceneManager.LoadScene ("PantallaServidor");
	}

	public void ejecutarCliente(){
		SceneManager.LoadScene ("PantallaConexion");
	}
}
