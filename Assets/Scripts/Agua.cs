using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (0.30f, -1.29f, transform.position.z);
		
	}
}
