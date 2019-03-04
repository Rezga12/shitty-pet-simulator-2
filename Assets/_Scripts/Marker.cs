using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour {

	public Material markerMaterial;

	public Color lowerColor;
	public Color upperColor;
	Color targetColor;

	// Use this for initialization
	void Start () {
		targetColor = upperColor;
	}
	
	// Update is called once per frame
	void Update () {
		var col = Color.Lerp (markerMaterial.GetColor("_EmissionColor"),targetColor,0.06f);

		if(Vector4.Distance(col,targetColor) < 0.09f){
			changeTargetColor ();
	
		}
		markerMaterial.SetColor ("_EmissionColor",col);
	}

	void changeTargetColor (){
		if(targetColor == lowerColor){
			targetColor = upperColor;
		}else{
			targetColor = lowerColor;
		}
	}
}
