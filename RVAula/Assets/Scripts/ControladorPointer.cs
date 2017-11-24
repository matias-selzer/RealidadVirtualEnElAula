using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControladorPointer : MonoBehaviour {

	bool seleccionar=false;
	public static float factor;
	private Pregunta pregunta;
	public int indiceRespuesta;
	public static bool activo=false;

	void Start(){
		pregunta = transform.parent.GetComponent<Pregunta> ();
		asignarEventos ();
	}

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
		if (ControladorPointer.activo) {
			if (seleccionar) {
				if (factor > 1)
					factor -= 0.1f;
				else {
					preguntaRespondida ();
				}
			}
		}
	}

	public void preguntaRespondida(){
		pregunta.asignarRespuesta (indiceRespuesta);
		CancelInvoke ("disminuirTiempo");
		/*activo = false;
		ControladorPointer[] losBotones = transform.parent.GetComponentsInChildren<ControladorPointer> ();
		for (int i = 0; i < losBotones.Length; i++) {
			losBotones [i].activo = false;
		}*/
	}

	public void OnPointerEnter(PointerEventData data)
	{
		pointerEnter ();
	}

	public  void OnPointerExit(PointerEventData data)
	{
		pointerExit ();
	}


	void asignarEventos(){
		EventTrigger trigger = GetComponent<EventTrigger>();
		EventTrigger.Entry entryEnter = new EventTrigger.Entry();
		entryEnter.eventID = EventTriggerType.PointerEnter;
		entryEnter.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
		trigger.triggers.Add(entryEnter);

		EventTrigger.Entry entryExit = new EventTrigger.Entry();
		entryExit.eventID = EventTriggerType.PointerExit;
		entryExit.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
		trigger.triggers.Add(entryExit);
	}


}
