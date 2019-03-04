using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyNewScript : MonoBehaviour {

	private Animator anim;
	public FruitButtonController carrotButton;
	public FruitButtonController shroomButton;
	public FruitButtonController burgerButton;
	public WaterButtonController waterButton;

	public Camera cam;

	public GameObject pointer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		bunny = GetComponent<RabbitController> ();
	}
	public bool lerping;
	public bool smoothMovement;
	public RabbitController bunny;
	Vector3 point;
	Vector3 initialPoint;

	public float speed = 0.005f;

	// Update is called once per frame
	void Update () {
		if (lerping) {
			if (smoothMovement) {
				bunny.transform.position = Vector3.Lerp (bunny.transform.position, point, speed * Time.deltaTime);
			}else {
				bunny.transform.position += moving ();
			}
			var bunnyPoint = new Vector3 (bunny.transform.position.x, 0, bunny.transform.position.z);
			var destPoint = new Vector3 (point.x, 0, point.z);

			if (Vector3.Distance (bunnyPoint, destPoint) / bunny.transform.localScale.x < 0.05f) {
				lerping = false;
				anim.SetBool ("Running", false);
			}
		} else {
			pointer.SetActive (false);
		}


		if (!buttonIsClicked() && Input.GetKeyDown(KeyCode.Mouse0))
		{	
			RaycastHit hit;
			var ray = cam.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{	
				initialPoint = bunny.transform.position;

				//Debug.Log (hit.transform.gameObject.name);
				if (hit.transform.gameObject.tag == "Fruit") {
					bunny.setEatingTarget(hit.transform.gameObject);
					if (hit.transform.gameObject.GetComponent<CapsuleCollider> ().bounds.Intersects (bunny.GetComponent<CapsuleCollider> ().bounds)) {
						StartCoroutine (eat(hit.transform));
					}
					pointer.SetActive (false);
				} else {
					bunny.disableEatingTarget ();
					pointer.SetActive (true);
					pointer.transform.position = new Vector3 (hit.point.x, pointer.transform.position.y, hit.point.z);
					//Debug.Log (pointer.transform.position );
				}
				lerping = true;
				anim.SetBool ("Running", true);
				point = hit.point;
				var X = point.x  - bunny.transform.position.x;
				var Z = point.z - bunny.transform.position.z;
				var rot = Mathf.Atan (X/Z) * Mathf.Rad2Deg;
				if (Z < 0)
					rot += 180;
				bunny.transform.rotation = Quaternion.Euler (0,rot,0);
			}
		}

	}

	bool buttonIsClicked(){
		return carrotButton.clickedState || burgerButton.clickedState || shroomButton.clickedState || waterButton.clickedState;
	}


	IEnumerator eat(Transform trans){
		yield return new WaitForSeconds (0.1f);
		bunny.eat (trans);
	}


	private Vector3 moving(){
		var X = point.x - initialPoint.x;
		var Z = point.z - initialPoint.z;
		var C = Mathf.Sqrt (X * X + Z * Z);
		Debug.Log(X);
		Debug.Log (Z);
		return new Vector3 (speed*X/C,0,speed * Z/C);
	}

}
