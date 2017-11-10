using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palmera : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Destroy (gameObject, 7);
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, -1.93f, transform.position.z), 1 * Time.deltaTime);
		
	}
}
