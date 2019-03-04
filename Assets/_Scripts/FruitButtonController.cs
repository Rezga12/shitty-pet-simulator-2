using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FruitButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
	
	public GameObject carrotPrefab;
	private GameObject carrot;

	public Transform plane;
	public Camera cam;
	public bool clickedState;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		if (carrot) {
			
			RaycastHit hit;
			var ray = cam.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast (ray, out hit)){
				carrot.transform.position = hit.point;
				carrot.transform.position = Vector3.Lerp (carrot.transform.position, hit.point, 0.2f);
			}
		}

	}

	public void OnPointerDown(PointerEventData eventData)
	{	
		carrot = Instantiate (carrotPrefab,plane);
		carrot.transform.position = new Vector3 (0,-1000,0);
		clickedState = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{	
		carrot.GetComponent<CapsuleCollider> ().enabled = true;
		carrot = null;
		clickedState = false;


	}



}
