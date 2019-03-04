using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControll : MonoBehaviour {

	public Transform[] positions;

	public int currentPos;

	Transform target;
	public float speed;




	// Use this for initialization
	void Start () {
		currentPos = 0;
		transform.position = positions [currentPos].position;
		transform.rotation = positions [currentPos].rotation;
		transform.localScale = positions [currentPos].localScale;
	}

	void Update(){
		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, speed /** Time.deltaTime*/);
			transform.rotation = Quaternion.Lerp (transform.rotation, target.rotation, speed /** Time.deltaTime*/);
			if(Vector3.Distance(target.position,transform.position) + Vector3.Distance(transform.rotation.eulerAngles,target.rotation.eulerAngles) < 0.5f){
				target = null;
			}
		}
	}

	public void NextPet(){
		currentPos = (currentPos + 1) % positions.Length;
		target = positions[currentPos];
	}

	public void PreviousPet(){
		currentPos = (currentPos - 1 + positions.Length) % positions.Length;
		target = positions[currentPos];
	}

	public void Play(){
		if(currentPos == 2){
			return;
		}
		GameInfo.SelectedPet = currentPos;
		SceneManager.LoadScene (1);
	}
}
