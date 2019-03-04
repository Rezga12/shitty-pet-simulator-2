using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureRotator : MonoBehaviour {

	public Transform[] pets;
	CameraControll cam;
	Vector3 previousPoint;
	// Use this for initialization



	void Start () {
		cam = GetComponent<CameraControll> ();




	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {	
				previousPoint = hit.point;
			}
		}

		if(Input.GetKey(KeyCode.Mouse0)){
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {	
				pets[cam.currentPos].transform.Rotate(0,getAngle (hit.point),0);

			}
	
		}
	}

	private float getAngle(Vector3 point){
		
		float A = Vector3.Distance (pets[cam.currentPos].transform.position,point);
		float B = Vector3.Distance (pets[cam.currentPos].transform.position,previousPoint);
		float C = Vector3.Distance (point,previousPoint);



		var cosT = (A * A + B * B - C * C) / (2 * A * B);

		float angel = Mathf.Acos (cosT) * Mathf.Rad2Deg;
		var pet = pets [cam.currentPos].transform.position;

		Vector3 preVector = previousPoint - pet;
		Vector3 currVector = point - pet;
		Vector3 axis = new Vector3 (0,0,1);

		var angle = Vector3.Angle (axis,preVector);
		var testVector = Quaternion.Euler(0,(preVector.x < 0 ? 1 : -1) * angle, 0) * currVector;



		previousPoint = point;

		return angel * (testVector.x < 0 ? -1 : 1);
	}
}
