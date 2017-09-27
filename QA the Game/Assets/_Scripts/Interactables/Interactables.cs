using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactables : MonoBehaviour {

	public GameObject player;
	public float interactTime = 0.01f;
	public string interactType;
	public GameObject portalExit;
	public string Scene;


	public void interact(){
		Invoke (interactType, interactTime);
	}
		

	public void portal(){
		player.transform.position = portalExit.transform.position;
	}

	public void sceneSwitcher(){
		SceneManager.LoadScene (Scene);
	}


}
