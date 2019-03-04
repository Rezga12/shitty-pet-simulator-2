using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//cam = transform.parent.gameObject.GetComponent<Camera> ();
	}
	Camera cam;
	Vector3 previousPoint;
	
	// Update is called once per frame
	void Update () {
		
		/*if(Input.GetKey(KeyCode.Mouse0)){
			RaycastHit hit;
			var ray = cam.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {	
				var point = hit.point;
				var X = point.x  - transform.position.x;
				var Z = point.z - transform.position.z;
				var rot = Mathf.Atan (X/Z) * Mathf.Rad2Deg;
				if (Z < 0)
					rot += 180;
				transform.rotation = Quaternion.Euler (0,rot,0);

			}

		}*/
	}


}
