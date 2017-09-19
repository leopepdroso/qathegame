using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth = 100f;
	public float curHealth = 0f;

	public Slider healthSlider; 

	public bool damaged;
	public bool isDead;

	void Awake () {
		curHealth = maxHealth;
	}

	void Update () {
		
	}

	public void TakeDamage (float amount)
	{
		damaged = true;
		curHealth -= amount;
		healthSlider.value = curHealth;
		if(curHealth <= 0 && !isDead)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;
	}      
}
