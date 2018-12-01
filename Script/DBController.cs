using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBController : MonoBehaviour {

	private Animator animator;
	private Animator camAnim;

    private float timer1;

	private Rigidbody2D rb2d;

    private bool chargeReady = false;
    private bool screaming = false;

    private Transform chargeHitBox;



	public bool charging = false;
	public Camera cam;

	public float chargeSpeed;
    public float openingScreamTime;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();
		camAnim = cam.GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

        chargeHitBox = transform.Find("ChargeCollider");

        timer1 = openingScreamTime;

	}
	



	public void OpeningScream(){

		animator.SetTrigger ("Scream");
		camAnim.SetTrigger("shake");
        timer1 = openingScreamTime;
        screaming = true;

	}

    //Called every frame
	void Update () {
        timer1 -= Time.deltaTime;

        if (timer1 <= 0 && screaming)
        {
            EndScream();
            screaming = false;
        }

        if (timer1 <= 0 && chargeReady)
        {
            Charge();
            chargeReady = false;
            
        }

	}


    public void EndScream()
    {
        camAnim.SetTrigger("shakedone");
        animator.SetTrigger("ScreamOver");
        chargeReady = true;
        timer1 = 0.5f;

    }



	public void Charge (){

		animator.SetTrigger ("Charge");
        chargeHitBox.gameObject.SetActive(true);
		charging = true;

	}

    public void WallCollide()
    {
        // called by chargehitbox when it collides with wall

    }

	void FixedUpdate(){

		while (charging) {
			rb2d.velocity = new Vector2 (chargeSpeed, 0);	
		}

	}


}
