using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {

	public GameObject currentGameObject = null;

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Interactable")) {
			currentGameObject = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Interactable")) {
			if (other.gameObject == currentGameObject) {
				currentGameObject = null;
			}
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.W) && currentGameObject != null) {
			currentGameObject.GetComponent<Interactables>().portal();
			Debug.Log ("Telported");
		}
	}

}
