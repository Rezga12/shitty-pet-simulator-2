using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyNewScript))]
public class VufEditor : Editor {

	bool toggle = true;
	public int a;
	public override void OnInspectorGUI(){
		base.OnInspectorGUI ();
		MyNewScript scr = (MyNewScript)target;
		if(GUILayout.Button("Toggle Debug Mode")){
			var cams = Resources.FindObjectsOfTypeAll<Camera> ();
			if (toggle == true) {
				scr.cam = cams [1];
				cams [1].gameObject.SetActive (true);
				cams [2].gameObject.SetActive (false);
				toggle = false;
				UnityEditor.PlayerSettings.SetPlatformVuforiaEnabled (BuildTargetGroup.Android, true);
			}else{
				scr.cam = cams [2];
				cams [2].gameObject.SetActive (true);
				cams [1].gameObject.SetActive (false);
				toggle = true;
				UnityEditor.PlayerSettings.SetPlatformVuforiaEnabled (BuildTargetGroup.Android, false);
			}

			scr.carrotButton.cam = scr.cam;
			scr.shroomButton.cam = scr.cam;
			scr.burgerButton.cam = scr.cam;


		}
	}

}
