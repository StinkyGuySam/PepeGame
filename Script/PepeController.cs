using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// TO DO LIST

//create enemy for pepe to fight
//look into particle effects
//jumping and jumping attack animations
//make test ball for pepe to hit
// getcomponent vs getcomponents





public class PepeController : MonoBehaviour {

	public float runSpeed;
	public float jumpSpeed;
	public float attackDelay;
	public bool controlfree = true;
	public bool grounded = true;
	public float atkTimer = 0f;
	public float jumpHeight;


	private bool landing = false;
	private bool jumping = false;
	private float jumpStart;
	private float currentX;
	private float currentY;
	private Transform trans;
	private Rigidbody2D rb2d;
	private Animator animator;
	private EdgeCollider2D platforms;
	private GameObject platObj;
	private BoxCollider2D pepeHitbox;


	// Use this for initialization
	void Start () {

		rb2d = GetComponent <Rigidbody2D> ();
		animator = GetComponent <Animator> ();
		trans = GetComponent <Transform> ();
		pepeHitbox = GetComponent<BoxCollider2D>();

	//	platforms = GameObject.FindGameObjectWithTag ("platform").GetComponents<


	}



	void FixedUpdate () {

		//check current movement

		currentX = rb2d.velocity.x;
		currentY = rb2d.velocity.y;

		// player movement

		if (controlfree) {
		

			if (Input.GetAxis ("Horizontal") != 0) {

				if (Input.GetAxis ("Horizontal") > 0) {

					rb2d.velocity = new Vector2 (runSpeed, currentY);
					trans.localScale = Vector3.one;
					animator.SetTrigger ("right");

				}
				 
				if (Input.GetAxis ("Horizontal") < 0) {

					rb2d.velocity = new Vector2 (-runSpeed, currentY);
					trans.localScale = new Vector3 (-1, 1, 1);
					trans.rotation = Quaternion.identity;
					animator.SetTrigger ("left");

				}


			} else {

				rb2d.velocity = new Vector2 (0f, currentY);
				animator.SetTrigger ("stop");

			}
		
		


			//player attack

			if (Input.GetButton ("Shift") && atkTimer <= 0 && grounded) {

				rb2d.velocity = new Vector2 (0f, 0f);
				animator.SetTrigger ("attack");


				controlfree = false;


			}
				
			//player jump

			if (Input.GetButtonDown("Jump") && grounded) {

				jumpStart = rb2d.position.y;
				jumping = true;
				rb2d.velocity = new Vector2 (currentX, jumpSpeed);
				trans.rotation = Quaternion.identity;
				animator.SetTrigger ("jumpStart"); 
				grounded = false;


			}

			if ((rb2d.position.y - jumpStart >= jumpHeight) && jumping ) {

				rb2d.velocity = new Vector2 (currentX, -jumpSpeed);
				animator.SetTrigger ("jumpDown");
				trans.rotation = Quaternion.identity;
				landing = true;
				jumping = false;

			}





		}


			
		//starts ticking down from when attack starts

		if (atkTimer >= 0) {

			atkTimer -= Time.deltaTime;
		}

	}





	void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag("platform") && landing) {

			rb2d.velocity = new Vector2 (currentX, 0f);
			animator.SetTrigger ("jumpLand");
			trans.rotation = Quaternion.identity;
			grounded = true;
			landing = false;

		}

	}

}