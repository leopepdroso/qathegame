using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCore : MonoBehaviour {

	public float enemyMaxHP;
	public float enemyCurHP;
	public float enemyArmor;




	void Awake (){
		enemyCurHP = enemyMaxHP;

	}


	public void takeDamage (float dmg){
		enemyCurHP = enemyCurHP - dmg;
		if (enemyCurHP <= 0) {
			DestroyObject (this.gameObject);
		}
	}

}
