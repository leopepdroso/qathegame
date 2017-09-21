using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {

	public GameObject player;
	public float interactTime = 0.01f;
	public string interactType;
	public GameObject portalExit;

	public void interact(){
		Invoke (interactType, interactTime);
	}
		

	public void portal(){
		player.transform.position = portalExit.transform.position;
	}

}
