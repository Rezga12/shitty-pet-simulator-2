using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	public GameObject marker;





	private Renderer _renderer;
	private MaterialPropertyBlock propBlock;


	bool eaten;

	//pubics for cool dissapearing
	public float dissapearingSpeed;
	public float verticalSpeed;
	public float growingSpeed;

	// Use this for initialization
	void Start () {
		


		//rendering stuff
		_renderer = GetComponent<Renderer> ();
		propBlock = new MaterialPropertyBlock();

		_renderer.GetPropertyBlock (propBlock);
		propBlock.SetFloat ("_Alpha",1);
		_renderer.SetPropertyBlock (propBlock);
	}

	// Update is called once per frame
	void Update () {
		
			
		



		if (eaten) {
			transform.localScale = transform.localScale + new Vector3 (growingSpeed, growingSpeed, growingSpeed);
			transform.position += new Vector3 (0, verticalSpeed, 0);

			//Making It Transparent
			_renderer.GetPropertyBlock (propBlock);
			Debug.Log (propBlock.GetFloat ("_Alpha"));
			propBlock.SetFloat ("_Alpha", Mathf.Lerp (propBlock.GetFloat ("_Alpha"), 0, dissapearingSpeed * Time.deltaTime));

			if (propBlock.GetFloat ("_Alpha") <= 0.005f) {
				Destroy (gameObject);
			}

			_renderer.SetPropertyBlock (propBlock);

		}

	}

	public void mark(bool val){
		marker.SetActive (val);
	}





	public void dissapear(){
		mark (false);
		eaten = true;
		GetComponent<CapsuleCollider> ().enabled = false;
	}



}
