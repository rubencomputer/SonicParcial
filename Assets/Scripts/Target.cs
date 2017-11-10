using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	GameObject Sonic;

	void Start ()
	{
		Sonic = GameObject.Find ("Sonic").gameObject;

	}
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x, Sonic.transform.position.y, Sonic.transform.position.z);
		
	}
}
