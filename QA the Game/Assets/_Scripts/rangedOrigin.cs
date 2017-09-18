using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedOrigin : MonoBehaviour {

	public PlayerMovement pm;
	public LayerMask whatIsEnemy;

	void Awake (){
	}


	public IEnumerator rangedRoutine(){
		Debug.Log ("rangedRoutine started");
		pm.isAttacking = true;
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector3.right, whatIsEnemy);
		if (hit.collider.gameObject.tag == "Enemy") {
			Debug.Log ("RANGED HAS HIT ENEMY!!");
			DestroyObject (hit.collider.gameObject);
		}
		yield return new WaitForSeconds (pm.rangedCD);
		pm.isAttacking = false;
		StopCoroutine (rangedRoutine ());
	}

}
