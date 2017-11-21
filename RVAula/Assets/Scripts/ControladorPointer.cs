using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPointer : MonoBehaviour {

	bool seleccionar=false;
	public static float factor;


	public void pointerEnter(){
		factor = 3.0f;
		seleccionar = true;
		InvokeRepeating ("disminuirTiempo", 0, 0.1f);
	}

	public void pointerExit(){
		factor = 1f;
		seleccionar = false;
		CancelInvoke ("disminuirTiempo");
	}


	public void disminuirTiempo(){
		if (seleccionar) {
			if (factor > 1)
				factor -= 0.1f;
			else {
				Debug.Log ("presiono el boton");
				Seek.avanzar = true;
			}
		}
	}


}
