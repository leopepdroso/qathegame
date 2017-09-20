using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public AttributeController playerAttributes;
	public Image content;
	float curContent;
	float damageTaken;
	float maxContent;


	// Use this for initialization
	void Start () {
		curContent = playerAttributes.curHealth/playerAttributes.maxHealth ;
		content.fillAmount = curContent;
	}
	
	public void updateHP(){
		Debug.Log ("Reached updateHP");
		curContent = playerAttributes.curHealth/playerAttributes.maxHealth ;
		content.fillAmount = curContent;
		Debug.Log ("curContent= " + curContent);
		updateColor (curContent);
	}

	void updateColor(float spec){
		if (spec >= 0.6) {
			
		}
	}
}
