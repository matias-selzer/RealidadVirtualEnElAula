using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Servidor : MonoBehaviour {

	public string connectionIP="127.0.0.1";
	public string connectionPort=25001+"";
	private NetworkView networkView;
	public CoordinadorDeRed coord;

	public InputField fieldIP,fieldPort;
	public Text cantidadConectados;
	public Button bComenzar,bIniciarServidor;
	public Dropdown listaAlumnos,listaAlumnosRes;
	private int cConectados;
	private List<string> listaAlumnosParaMostrar;

	public Text cuadroTexto;

	public GameObject panelResultados;

	private Dictionary<string,Usuario> usuarios;

	// Use this for initialization
	void Start () {
		listaAlumnosParaMostrar = new List<string> ();
		usuarios = new Dictionary<string,Usuario> ();
		fieldIP.text=(Network.player.ipAddress);

		/*listaAlumnosRes.onValueChanged.AddListener(delegate{
			seleccionarUsuarioParaMostrar(listaAlumnosRes.options[listaAlumnosRes.value].text+"");
		});*/

		networkView = GetComponent<NetworkView> ();
		//initializeServer();
	}

	public void seleccionarUsuarioParaMostrar(){
		string ip = (listaAlumnosRes.options[listaAlumnosRes.value].text+"").Split ('-') [1];
		Debug.Log ("ip: " + ip);
		Usuario u;
		usuarios.TryGetValue(ip,out u);
		cuadroTexto.text = u.respuestas;
	}
	
	public void initializeServer(){
		bComenzar.interactable = true;
		bIniciarServidor.interactable = false;
		connectionIP = fieldIP.text;
		connectionPort = fieldPort.text;
		Network.InitializeServer(10, int.Parse( connectionPort), false);
		coord.setearObserver(new ServidorObserver(this));
	}

	public void comenzarRecorrido(){
		coord.enviarAClientes ("comenzar&"+connectionIP);
		panelResultados.SetActive (true);
	}



	public void agregarNuevoUsuario(string nombre,string ip){
		// Genero y almaceno un nuevo usuario
		Usuario nuevo = new Usuario ();
		nuevo.nombre = nombre;
		nuevo.ip = ip;
		usuarios.Add (ip, nuevo);

		// Incremento contador de usuarios conectados
		cConectados++;
		cantidadConectados.text = cConectados+"";

		// Incorporo el usuario al dropdown
		listaAlumnosParaMostrar.Add (nombre+"-"+ip);
		listaAlumnos.options.Clear ();
		listaAlumnosRes.options.Clear ();
		listaAlumnos.AddOptions (listaAlumnosParaMostrar);
		listaAlumnosRes.AddOptions (listaAlumnosParaMostrar);

	}

	public void asignarRespuestas(string ip, string respuesta){
		Usuario u;
		usuarios.TryGetValue (ip, out u);
		u.respuestas = respuesta;
	}




}
