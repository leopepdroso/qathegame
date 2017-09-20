using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeController : MonoBehaviour {


	public float maxHealth;
	public float curHealth;
	public float maxMana;
	public float curMana;
	bool hasStarted = false;
	public float maxEnergy;
	public float curEnergy;
	public PlayerCombat combatController;
	public PlayerStats savedStats;

	//----------------------UI Elements
	public HealthBar hpBar;
	public EnergyBar energyBar;



	void Awake(){
		
		setStartingPoint ();
		combatController.meleeTrigger.enabled = false;
		curHealth = savedStats.playerCURHP;
		maxHealth = savedStats.playerMAXHP;
		curMana = savedStats.playerCURMANA;
		maxMana = savedStats.playerMAXMANA;
		combatController.meleeDMG = savedStats.playerMDMG;
		combatController.rangedDMG = savedStats.playerRDMG;

	}

	//----------------------First Game Setting
	void setStartingPoint(){
		if (savedStats.hasStarted == false) {
			savedStats.playerMAXHP = 100;
			savedStats.playerCURHP = 100;
			savedStats.playerMAXMANA = 100;
			savedStats.playerCURMANA = 0;
			savedStats.playerMDMG = 10;
			savedStats.playerRDMG = 15;
			hasStarted = true;
			savedStats.hasStarted = true;
		}
	}

	//----------------------Takes Damage
	public void getDamage(float dmg){
		curHealth -= dmg;
		hpBar.updateHP();
	}


	//----------------------Gains Mana on Melee
	public void addMana(){
		curEnergy += maxEnergy / 20;
	}

}
