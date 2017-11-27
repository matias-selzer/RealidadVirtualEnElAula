using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer  {

	abstract public void conexionEstablecida ();
	abstract public void consumirMensaje (string mensaje);

}
