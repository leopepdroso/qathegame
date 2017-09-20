using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

	//----------------------Combat
	public bool isAttacking;
	public float meleeCD;
	public float rangedCD;
	public Collider2D meleeTrigger;
	public rangedOrigin rO;
	public PlayerMovement moveSet;
	public float rangedDMG;
	public float meleeDMG;



	public void checkAttack(){

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("leftMouse");
			if (!isAttacking){
				moveSet.moveSpeed = 0;
				StartCoroutine (meleeRoutine ());
			}
		}

		if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("rightMouse");
			moveSet.moveSpeed = 0;
			StartCoroutine (rO.rangedRoutine ());
		}

	}

	IEnumerator meleeRoutine(){
		Debug.Log ("meleeRoutine started");
		isAttacking = true;
		meleeTrigger.enabled = true;
		StartCoroutine(meleeTrigger.GetComponent<meleeContact>().attackLifeTime());
		yield return new WaitForSeconds (meleeCD);
		isAttacking = false;
		StopCoroutine (meleeRoutine ());

	}
}
