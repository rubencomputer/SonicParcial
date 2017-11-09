using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {

	public GameObject EsferaFuego;
	Terreno terreno;
	Animation_Test anima;
	GameObject sonic;
	ShakeCamara shake;

	// Use this for initialization
	void Start () 
	{
		shake = GameObject.FindObjectOfType<ShakeCamara> ();
		terreno = GameObject.FindObjectOfType<Terreno> ();		
		anima = GameObject.FindObjectOfType<Animation_Test> ();
		sonic = GameObject.Find ("Sonic").gameObject;
		StartCoroutine (SacaObstaculos ());
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (sonic.transform);
		transform.position = new Vector3 (transform.position.x, transform.position.y, sonic.transform.position.z+30);
	}

	IEnumerator SacaObstaculos ()
	{
		while (true)
		{
			shake.duracionShake = 1;
			GameObject obstaculo = Instantiate (EsferaFuego, transform.GetChild(0).Find("Spawner").position, Quaternion.identity);
		//	obstaculo.transform.position = Vector3.Lerp (obstaculo.transform.position, Terreno.jugador.transform.position, 1);
			anima.AttackAni();
			yield return new WaitForSeconds (3);
		}
	}
}
