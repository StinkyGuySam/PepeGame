using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustSpawnDirt : MonoBehaviour {

	public GameObject dust;

	void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag("Player")) {

		
			Instantiate (dust, new Vector3 (transform.position.x, -0.50f, 0f),Quaternion.identity);
	

		}
	}
}
