using UnityEngine;
using System.Collections;

public class CharachterController : MonoBehaviour {

	public float maxSpeed = 10f; 													//max speed player can moce
	bool facingRight = true; 														//lets us konw which way the character is facing
	private Vector3 origionalPosition; 												//holds the origional position of character
	Animator anim; 																	//reference to animator
	//-----------------------------------------------------------------
	bool grounded = false;  														//is the character on the ground
	public Transform groundCheck; 													//connects to another object to determine if on the ground
	float groundRadius = 0.2f;  													//how big is the object checking if the player is on the ground
	public LayerMask whatIsGround; 													// determines what is ground
	public float lifeCount = 3;
	public float Oxygenlvl = 100;
	//-----------------------------------------------------------------
	public float jumpForce = 700;													//jumpforce when player hits spacebar
	public float direction = 1;														//direction of gravity
	float rotSpeed = 18;															//rotation speed
	//-----------------------------------------------------------------
	public bool haspiece1 = false;
	public bool haspiece2 = false;
	public bool haspiece3 = false;
	public bool haspiece4 = false;



	


	//-----------------------------------------------------------------
	// 				Set up for code
	//-----------------------------------------------------------------
	void Awake(){
		origionalPosition = transform.position;  									//holds the charaters origional positon
		}

	//-----------------------------------------------------------------
	// 				Intitial update
	//-----------------------------------------------------------------
	void Start () {
		anim = GetComponent<Animator> (); 											// connects to the animator
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y); 							//determines how fast moivng up or down
		Physics2D.gravity = new Vector2(0, -30); 									// set gravity
	}


	//-----------------------------------------------------------------
	//				CHECKS COLLIDERS
	//-----------------------------------------------------------------
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Respawn") 														//If hit something that causes you to die
			StartCoroutine ("ReloadGame");															//Reset player				
		else if (col.gameObject.tag == "Spaceship"){ 												//If hit the egg and won
			if(haspiece1 == true && haspiece2 == true && haspiece3 == true && haspiece4 == true)	//If you have all the peices
				StartCoroutine ("WinGame");}													//Go to win routine
		else if (col.gameObject.tag == "SpaceshipPiece1")                           				//If you have the first spaceship piece
			haspiece1 = true;																		//Has Piece 1
		else if (col.gameObject.tag == "SpaceshipPiece2")                           				//If you have the second spaceship piece
			haspiece2 = true;																		//Has Piece 2
		else if (col.gameObject.tag == "SpaceshipPiece3")                           				//If you have the third spaceship piece
			haspiece3 = true;																		//Has Piece 3
		else if (col.gameObject.tag == "SpaceshipPiece4")                           				//If you have the final spaceship piece
			haspiece4 = true;																		//Has Piece 4

	}
	//-----------------------------------------------------------------
	//-----------------------------------------------------------------
	
	//-----------------------------------------------------------------
	//				Fixed update runs at same time as timestamp
	//				Where all the movement and resulting animations take place
	//-----------------------------------------------------------------
	void FixedUpdate () {
		Oxygenlvl -= Time.deltaTime;																	//Reduces the oxygen level by one every second
		if (Oxygenlvl <= 0) {																			//If out of oxygen
			Oxygenlvl +=1; 																				//buffer as delta time is bloody fast so you dont lose 2 lives 
			StartCoroutine ("ReloadGame");																//reload starting positioon
				}
	//-----------------------------------------------------------------
	//gavity towards ground or ceiling
	if (direction == 1 || direction == 3) {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); 			// check if the collider is hiting any other colliders, on the ground
		anim.SetBool ("Ground", grounded);
			if(!grounded) 																				//prevents you from moing in the air 
				return;
			anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		float moveX = Input.GetAxis ("Horizontal");				 										//How much are you moving
		anim.SetFloat ("Speed", Mathf.Abs (moveX)); 													//swaps between idle and non idle 
		rigidbody2D.velocity = new Vector2 (moveX *= maxSpeed, rigidbody2D.velocity.y); 				// moves you along on x axis
		if (moveX > 0 && !facingRight) 																	//flips to the right directiom
			Flip ();
		else if (moveX < 0 && facingRight) 																// flips to face direction moving
			Flip ();
				}
		//-----------------------------------------------------------------
		//left and right
		if (direction == 2 || direction == 4) {

			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); 		// check if the collider is hiting any other colliders, on the ground
			anim.SetBool ("Ground", grounded);
			if(!grounded)	 																			//prevents you from moing in the air 
				return;
			anim.SetFloat("vSpeed", rigidbody2D.velocity.x);
			float moveY = Input.GetAxis ("Vertical"); 													//How mcuh you are moving
			anim.SetFloat ("Speed", Mathf.Abs (moveY));													//swap between idle and non idle 
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x , moveY *= maxSpeed); 			//moves you along y axis
			if (moveY > 0 && !facingRight) 																//flips to the right directiom
				Flip ();
			else if (moveY < 0 && facingRight) 															// flips to face direction moving
				Flip ();
				}
	}
	//-----------------------------------------------------------------
	//				Update tracks input more accuretley
	//				Where jumping key and gravity switches occur
	//-----------------------------------------------------------------
	void Update(){ 
		//GRAVITY MOVEMENT
		Vector3 theScale = transform.localScale;
		if (Input.GetKeyDown (KeyCode.R) && direction == 1) { 						//gravity going into ground
			Physics2D.gravity = new Vector2(30, 0); 								//set gravity
			transform.Rotate(0,rotSpeed * Time.deltaTime, 90, Space.World);			//rotate charchter
			direction = 2;
				}
		//-----------------------------------------------------------------
		else if (Input.GetKeyDown (KeyCode.R) && direction == 2) { 					//gravity to the right
			theScale.x *= -1;														//reverses animation
			transform.localScale = theScale;										//reverse
			Physics2D.gravity = new Vector2(0, 30); 								// set gravity
			transform.Rotate(0,rotSpeed * Time.deltaTime, 90, Space.World); 		//rotate charchter
			direction = 3;
				}
		//-----------------------------------------------------------------
		else if (Input.GetKeyDown (KeyCode.R) && direction == 3) { 					//gravity to the ceiling
			Physics2D.gravity = new Vector2(-30, 0); 								// set gravity
			transform.Rotate(0,rotSpeed * Time.deltaTime, 90, Space.World); 		//rotate charchter
			direction = 4;
				}
		//-----------------------------------------------------------------
		else if (Input.GetKeyDown (KeyCode.R) && direction == 4) { 					//gravity to the left
			theScale.x *= -1;														//reverses animation
			transform.localScale = theScale;										//reverse
			Physics2D.gravity = new Vector2(0, -30); 								// set gravity
			transform.Rotate(0,rotSpeed * Time.deltaTime, 90, Space.World); 		//rotate charchter
			direction = 1;
				}
		//-----------------------------------------------------------------
		//-----------------------------------------------------------------
		//Allows for jump to happen even if gravity is reversed
		if (grounded && Input.GetKeyDown (KeyCode.Space) && direction == 1) {       // must be met in order to jump
			anim.SetBool("Ground", false);										    //sets you not on the ground so you cant keep jumping
			rigidbody2D.AddForce(new Vector2(0, jumpForce));					    //jump force applied
				}
		//-----------------------------------------------------------------
		else if (grounded && Input.GetKeyDown (KeyCode.Space) && direction == 2) {  // must be met in order to jump
			anim.SetBool("Ground", false);										    //sets you not on the ground so you cant keep jumping
			rigidbody2D.AddForce(new Vector2(-jumpForce,0)); 						//jump force applied
				}
		//-----------------------------------------------------------------
		else if (grounded && Input.GetKeyDown (KeyCode.Space) && direction == 3) {  // must be met in order to jump
			anim.SetBool("Ground", false);											//sets you not on the ground so you cant keep jumping
			rigidbody2D.AddForce(new Vector2(0, -jumpForce)); 						//jump force applied
				}
		//-----------------------------------------------------------------
		else if (grounded && Input.GetKeyDown (KeyCode.Space) && direction == 4) {  // must be met in order to jump
			anim.SetBool("Ground", false);											//sets you not on the ground so you cant keep jumping
			rigidbody2D.AddForce(new Vector2(jumpForce,0));							//jump force applied
				}
	}
	    //-----------------------------------------------------------------					
			



	
	//-----------------------------------------------------------------
	//flips your game object so animations works in both directions
	//-----------------------------------------------------------------
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	//-----------------------------------------------------------------
	//	 Next two functions reset the game depending if you dies or won
	//	 Called by OnCollisionEnter2D
	//-----------------------------------------------------------------
	IEnumerator ReloadGame(){
		yield return new WaitForSeconds (0);
		lifeCount = lifeCount -1;        											//reduces lifecount
		if (lifeCount < 0) {														//if no more lives go to menu screen
			Application.LoadLevel(5);
				}
		Vector3 theScale = transform.localScale;
		Oxygenlvl = 100;                  											//reset oxygen level
		transform.position = origionalPosition; 									//moves the charater to his origional position
		Physics2D.gravity = new Vector2(0, -30);									// reset gravity
		//------------------------------------------------------------------ 
		//reset rotation
		if (direction ==2)
			transform.Rotate(0,rotSpeed * Time.deltaTime, 270, Space.World);
		else if (direction ==3){
			transform.Rotate(0,rotSpeed * Time.deltaTime, 180, Space.World);
			theScale.x *= -1;
			transform.localScale = theScale;
				}
		else if (direction ==4){
			transform.Rotate(0,rotSpeed * Time.deltaTime, 90, Space.World);
			theScale.x *= -1;
			transform.localScale = theScale;
				}
		direction = 1;
		}
	//-----------------------------------------------------------------
	IEnumerator WinGame(){
		int currentScene = Application.loadedLevel ;
		yield return new WaitForSeconds (1);
		if(currentScene == 2)				//level1
			Application.LoadLevel(3);       //load level 2
		if(currentScene == 3)				//level2
			Application.LoadLevel(4);		//load level 3
		if(currentScene == 4)				//level3
			Application.LoadLevel(6);		//load level 4
		if(currentScene == 6)				//level4
			Application.LoadLevel(7);		//load level 5
		if(currentScene == 7)				//level5
			Application.LoadLevel(0);      	//load main menu
		if(currentScene == 9)				//tutoriallevel1
			Application.LoadLevel(10);			//tutlevel2
		if(currentScene == 10)				//tutlevel2
			Application.LoadLevel(11);         //tutlevel3    
		if(currentScene == 11)             //tutlevel3
			Application.LoadLevel(0);      //Main Menu
	
				}
}
