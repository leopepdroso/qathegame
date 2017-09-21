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


	//----------------------Combat
	public PlayerCombat combatController;
	public skillHandler spellHandle;

	//----------------------Detection
	float groundRadius = 0.2f;
	Rigidbody2D rb;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	//----------------------Flip
	public bool facingRight = true;

	//----------------------Settings
	void Awake () {

	}

	void Start () {
		isGrounded = true;
		spellHandle.notDodging = true;
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
		spellHandle.checkInput ();
		combatController.checkAttack ();

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


    //----------------------Flips character sprite
    void Flip()
	{
		facingRight = !facingRight;
		Vector3 flipScale = transform.localScale;
		flipScale.x *= -1;
		transform.localScale = flipScale;
	}



}