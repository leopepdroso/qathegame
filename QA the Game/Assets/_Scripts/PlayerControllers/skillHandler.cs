using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillHandler : MonoBehaviour {

	public AttributeController attHandler;
	//public PlayerCombat combatHandler;
	public PlayerMovement moveHandler;
	public float dodgeSpeed;
	public float dodgeDistance;
	public float currentDistance;
	Vector3 target;
	public bool notDodging;
	public bool underDodge;

	void Start(){
		underDodge = false;

	}

	void FixedUpdate(){
		checkInput ();
		checkDodge ();

	}

	//-----------------------------------------------Dodge
	public void checkInput(){
		if (Input.GetKeyDown(KeyCode.LeftShift) && notDodging){
			if (moveHandler.facingRight) {
				Debug.Log ("x = " + moveHandler.transform.position.x + " y = " + moveHandler.transform.position.y);
				Debug.Log ("x = " + target.x + " y = " + target.y);
				target = (moveHandler.transform.position + (Vector3.right * dodgeDistance));
				Debug.Log ("x = " + moveHandler.transform.position.x + " y = " + moveHandler.transform.position.y);
				Debug.Log ("x = " + target.x + " y = " + target.y);
			}
			if (!moveHandler.facingRight) {
				Debug.Log ("x = " + moveHandler.transform.position.x + " y = " + moveHandler.transform.position.y);
				Debug.Log ("x = " + target.x + " y = " + target.y);
				target = (moveHandler.transform.position - (Vector3.right * dodgeDistance));
				Debug.Log ("x = " + moveHandler.transform.position.x + " y = " + moveHandler.transform.position.y);
				Debug.Log ("x = " + target.x + " y = " + target.y);
			}
			Debug.Log ("Reached inputCheck for Dodge");
			notDodging = false;
			underDodge = true;
		}

	}

	void checkDodge(){
		if (underDodge == true) {
			if (currentDistance <= 1) {
				currentDistance += Time.deltaTime * dodgeSpeed;
				Debug.Log (currentDistance);
				moveHandler.transform.position = Vector3.Lerp (moveHandler.transform.position, target, currentDistance);
				attHandler.invulnerable = true;	

			} else {
				currentDistance = 0;
				underDodge = false;
				notDodging = true;
				attHandler.invulnerable = false;
			}
		}
	}


	IEnumerator dodgeCD(){
		yield return new WaitForSeconds (0.5f);
		notDodging = true;
		StopCoroutine (dodgeCD());
	}
		

}
