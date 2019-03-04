using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		mat.color = ContentSaver.getWashColor ();
	}


	public Material mat;

	void OnParticleCollision(GameObject other){
		if (mat.color.r >= 0.99f || mat.color.g >= 0.99f || mat.color.b >= 0.99f) {
			return;
		}
		mat.color += new Color (0.005f,0.005f,0.005f);
	}

	void OnApplicationQuit(){
		ContentSaver.saveWashState (mat.color);
	}
}
