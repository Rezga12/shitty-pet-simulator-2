using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		movement = GetComponent<MyNewScript> ();
	}

	public Fruit eatingTarget;

	bool growing;
	public float growingSpeed;
	public float growingAmount;
	Vector3 goalSize;

	private MyNewScript movement;

	public FruitButtonController carrotButton;

	// Update is called once per frame
	void Update () {
		if(growing){
			transform.localScale = Vector3.Lerp (transform.localScale, goalSize,Time.deltaTime * growingSpeed);
			if(Vector3.Distance(transform.localScale,goalSize) <= 0.005f){
				growing = false;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		
		if(col.transform.gameObject.tag == "Fruit" && (!eatingTarget || eatingTarget.gameObject == col.transform.gameObject)){
			if (!eatingTarget && movement.lerping) {
				return;
			}
			eat (col.transform);

		}
	}

	public void eat(Transform fruit){
		fruit.gameObject.GetComponent<Fruit> ().dissapear ();
		growing = true;
		goalSize = transform.localScale + new Vector3 (growingAmount, growingAmount, growingAmount);
	}


	public void setEatingTarget(GameObject target){

		if(eatingTarget){
			eatingTarget.mark (false);
		}

		eatingTarget = target.GetComponent<Fruit> ();
		eatingTarget.mark (true);
	}

	public void disableEatingTarget(){
		if (!eatingTarget)
			return;
		eatingTarget.mark (false);
		eatingTarget = null;
	}



}
