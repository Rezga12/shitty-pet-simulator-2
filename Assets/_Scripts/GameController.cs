using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	void Awake(){
		transform.GetChild (GameInfo.SelectedPet).gameObject.SetActive (true);
	}

}
