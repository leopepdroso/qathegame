using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public PlayerMovement player;
	public Image content;
	float curContent;
	float damageTaken;
	float maxContent;


	// Use this for initialization
	void Start () {
		curContent = player.curHealth/player.maxHealth ;
		content.fillAmount = curContent;
	}
	
	public void updateHP(){
		Debug.Log ("Reached updateHP");
		curContent = player.curHealth/player.maxHealth ;
		content.fillAmount = curContent;
		Debug.Log ("curContent= " + curContent);
		updateColor (curContent);
	}

	void updateColor(float spec){
		if (spec >= 0.6) {
			
		}
	}
}
