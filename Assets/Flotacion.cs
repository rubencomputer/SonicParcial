using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotacion : MonoBehaviour {

	public float amplitud;          //Set in Inspector 
	public float velocidad;                  //Set in Inspector 
	private float tempVal;
	private Vector2 tempPos;
	public float altura;
	public float velocidadRotacion;                  //Set in Inspector 

	// Update is called once per frame
	void Update ()
	{
		tempPos.y = tempVal + amplitud * Mathf.Sin (velocidad * Time.time);
		transform.position = new Vector3(transform.position.x, tempPos.y + altura, transform.position.z);

		transform.Rotate (Quaternion.Euler (new Vector3 (0, 0, 10 * velocidadRotacion)).eulerAngles);
		
	}
}
