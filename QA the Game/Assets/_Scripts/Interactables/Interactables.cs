using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {

	public GameObject player;

	public void portal(){
		player.transform.position = new Vector3 (0, 0, 0);
		Debug.Log ("Telported");
	}

}
