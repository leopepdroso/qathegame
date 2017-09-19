using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	public PlayerStats savedStats;
	//----------------------Movement
	public bool isGrounded;
	public float moveSpeed;
	public float maxSpeed;
	public float acceleration;
	public float jumpSpeed;

	//----------------------PlayerStats
	public float rangedDMG;
	public float meleeDMG;
	public float maxHealth;
	public float curHealth;
<<<<<<< HEAD
	public float maxMana;
	public float curMana;
	bool hasStarted = false;
=======
    public float maxEnergy;
    public float curEnergy;
>>>>>>> 2764717b1e39a4a7eb006a47218ba5f5f0e0c28e

    //----------------------Combat
    public bool isAttacking;
	public float meleeCD;
	public Collider2D meleeTrigger;
	public rangedOrigin rO;
	public float rangedCD;

	//----------------------Detection
	float groundRadius = 0.2f;
	Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	//----------------------Flip
	bool facingRight = true;

	//----------------------UI Elements
	public HealthBar hpBar;
    public EnergyBar energyBar;

<<<<<<< HEAD

	//----------------------Settings
	void Awake () {
		setStartingPoint ();
		meleeTrigger.enabled = false;
		curHealth = savedStats.playerCURHP;
		maxHealth = savedStats.playerMAXHP;
		curMana = savedStats.playerCURMANA;
		maxMana = savedStats.playerMAXMANA;
		meleeDMG = savedStats.playerMDMG;
		rangedDMG = savedStats.playerRDMG;

	}
=======
    //----------------------Settings
    void Awake () {
		meleeTrigger.enabled = false;
		curHealth = maxHealth;
    }
>>>>>>> 2764717b1e39a4a7eb006a47218ba5f5f0e0c28e

	void Start () {
		isGrounded = true;
		acceleration = 0.1f;
		maxSpeed = 5f;
		rb = GetComponent<Rigidbody2D> ();
	}

	//----------------------Non-physics
	void Update (){
		checkGround ();
	}

	//Physics
	void FixedUpdate () {
		
		inputMove ();
		inputJump ();
		checkMovement ();
		checkAttack ();

	}

	//----------------------Horizontal movement
	void inputMove () {
		if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {

			if (facingRight) {
				Flip ();
			}
			if (moveSpeed <= maxSpeed) {
				moveSpeed += acceleration;
			}
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
			Debug.Log ("pressing move left");
		}

		if (Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
			if (!facingRight) {
				Flip ();
			}
			if (moveSpeed <= maxSpeed) {
				moveSpeed += acceleration;
			}

			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			Debug.Log ("pressing move right");
		}

	
	}

	//----------------------Checks to stop horizontal movement
	void checkMovement (){

		if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
			moveSpeed = 0;
			Debug.Log ("reset speed");
		}
	}

	//----------------------Vertical movement
	void inputJump () {
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			rb.AddForce (new Vector2(0, jumpSpeed));
			isGrounded = false;
			Debug.Log ("jumped");
		}
	
	}

	//----------------------Checks to see if able to jump
	void checkGround(){
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

	}

	//----------------------Checks and inputs attack commands
	void checkAttack(){

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("leftMouse");
			if (!isAttacking){
			moveSpeed = 0;
				StartCoroutine (meleeRoutine ());
			}
		}

		if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("rightMouse");
			moveSpeed = 0;
			StartCoroutine (rO.rangedRoutine ());
		}
			
	}
		

	//----------------------Starts melee attack process
	IEnumerator meleeRoutine(){
		Debug.Log ("meleeRoutine started");
		isAttacking = true;
		meleeTrigger.enabled = true;
		StartCoroutine(meleeTrigger.GetComponent<meleeContact>().attackLifeTime());
		yield return new WaitForSeconds (meleeCD);
		isAttacking = false;
		StopCoroutine (meleeRoutine ());

	}

	//----------------------Takes Damage
	public void getDamage(float dmg){
		curHealth -= dmg;
		hpBar.updateHP();
	}

<<<<<<< HEAD
	//----------------------Gains Mana on Melee
	public void getMana(){
		curMana += maxMana / 20;
	}
=======
    public void addMana(float dmg)
    {
        curEnergy += dmg;
        energyBar.updateEnergy();
    }
>>>>>>> 2764717b1e39a4a7eb006a47218ba5f5f0e0c28e


    //----------------------Flips character sprite
    void Flip()
	{
		facingRight = !facingRight;
		Vector3 flipScale = transform.localScale;
		flipScale.x *= -1;
		transform.localScale = flipScale;
	}

	//----------------------Set Characters initial attribute
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

}