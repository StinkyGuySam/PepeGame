using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {



	private CapsuleCollider2D hitDetector;

	// Use this for initialization
	void Start () {

		hitDetector = GetComponent<CapsuleCollider2D> ();

		
	}


	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "playerattack") {

			Destroy (gameObject);
			
		} 		

	}

	// Update is called once per frame
	void Update () {
		
	}
}
