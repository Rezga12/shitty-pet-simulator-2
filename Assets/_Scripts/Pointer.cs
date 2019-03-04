using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public Transform upLimit;
	public Transform downLimit;

	public float speed;


	bool growing;
	// Update is called once per frame
	void Update () {
		if (growing) {
			transform.position += new Vector3 (0,speed,0);
			if (transform.position.y >= upLimit.position.y) {
				growing = false;
			}
		} else {
			transform.position += new Vector3 (0,-speed,0);
			if (transform.position.y <= downLimit.position.y) {
				growing = true;
			}
		}
	}


}
