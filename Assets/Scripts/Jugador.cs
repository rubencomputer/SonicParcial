using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

	public Transform jugador;
	private float velH=0;
	public int hilera = 0;
	public bool movimiento;
	public float velocidad = 20;
	Rigidbody rigiPersonaje;
	public float fuerzaSalto;



	public float fuerza;
	// Use this for initialization
	void Start () {

		rigiPersonaje = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		GetComponent<Rigidbody> ().velocity = new Vector3 (velH,GetComponent<Rigidbody> ().velocity.y , velocidad);
		float vertical = 1.0f;


		/*
		if ((Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) && (hilera>-1) && (movimiento)) {
			movimiento = false;
			hilera -= 1;
			velH = -12.5f;
			StartCoroutine (detenerMovimientoH());
		}
		if ((Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) && (hilera<1) && (movimiento)) {
			movimiento = false;
			hilera += 1;
			velH = 12.5f;
			StartCoroutine (detenerMovimientoH ());
		}
		*/

		if (Input.GetKeyDown (KeyCode.Space))
		{
			rigiPersonaje.AddForce (Vector3.up * fuerzaSalto);
		}
	
	}
	IEnumerator detenerMovimientoH()
	{
		yield return new WaitForSeconds (.25f);
			velH = 0;
			movimiento = true;
	}
}
