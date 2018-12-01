using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDust : MonoBehaviour {


	private float timer;

	void Start () {

		timer = 3;
	}
	

	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {

			Destroy (gameObject);
		}
	}
}
