using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaterButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler  {

	public ParticleSystem system;
	public bool clickedState;

	void Start(){

		system = GameObject.FindGameObjectWithTag ("Pet").transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();

	}

	public void OnPointerDown(PointerEventData eventData){	
		Debug.Log ("1");
		if(!system.isPlaying)
			system.Play ();
		clickedState = true;
	}

	public void OnPointerUp(PointerEventData eventData){	
		system.Stop ();
		clickedState = false;

	}

}
