using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

	public Transform jugador;
	private float velH=0;
	public int hilera = 0;
	public bool movimiento;
	public float velocidad = 20;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		GetComponent<Rigidbody> ().velocity = new Vector3 (velH, 0, velocidad);
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
	
	}
	IEnumerator detenerMovimientoH()
	{
		yield return new WaitForSeconds (.25f);
			velH = 0;
			movimiento = true;
	}
}
