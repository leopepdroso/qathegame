using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float starting_health = 100f;
	public float current_health = 0f;

	public Slider healthSlider; 

	public boolean damaged;
	public boolean isDead;

	// Use this for initialization
	void Start () {
		current_health = starting_health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TakeDamage (int amount)
	{
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;
	}      
}
