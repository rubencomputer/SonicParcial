using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BolaFuego : MonoBehaviour {

	Transform target1;
	Transform target2;
	Transform target3;
	Transform[] targets;
	int targetElegido;
	public Transform targetFinal;
	Transform posicionincial;
	// Use this for initialization
	void Start () {
		posicionincial = transform;
		target1 = GameObject.Find ("Target1").transform;
		target2 = GameObject.Find ("Target2").transform;
		target3 = GameObject.Find ("Target3").transform;

		targetElegido = Random.Range (1, 3);

		if (targetElegido == 1)
			targetFinal = target1;
		
		if (targetElegido == 2)
			targetFinal = target2;

		if (targetElegido == 3)
			targetFinal = target3;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp(transform.position, targetFinal.position,9);
		
	}
}
