using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {

	GameObject Enemigo;
	Vector3 posicionInicial;
	// Use this for initialization
	void Start () {
		Enemigo = GameObject.FindWithTag ("Enemigo").gameObject;
		posicionInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, new Vector3(Enemigo.transform.position.x, Enemigo.transform.position.y+10, Enemigo.transform.position.z), 6.0f * Time.deltaTime); 

	}

	void OnCollisionEnter (Collision _col)
	{
		if (_col.gameObject.CompareTag ("Enemigo"))
		{
			print ("Colision Con enemigo-bomba");
			Animation_Test a;
			Enemigo b = GameObject.FindObjectOfType<Enemigo> ();
			b.vida -= 5;
			a = GameObject.FindObjectOfType<Animation_Test> ();
			a.DamageAni ();
			Destroy (gameObject);
		}
	}
}
