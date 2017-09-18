using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHazard : MonoBehaviour {

	public PlayerHealth playerH;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			playerH.TakeDamage (5f);
		}
	}
}
