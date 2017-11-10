using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemigo : MonoBehaviour {

	public GameObject EsferaFuego;
	Terreno terreno;
	Animation_Test anima;
	GameObject sonic;
	ShakeCamara shake;
	UI uiparametros;
	bool moviendoIzq;
	bool moviendoDer;
	bool moviendoCentro = true;
	public static bool enemigovivo = true;
	public int vida;
	bool yasereproduciomuerte = false;
	public GameObject TextoYouWin;
	public GameObject PantallaNegra;
	// Use this for initialization
	void Start () 
	{
		shake = GameObject.FindObjectOfType<ShakeCamara> ();
		terreno = GameObject.FindObjectOfType<Terreno> ();		
		uiparametros = GameObject.FindObjectOfType<UI> ();		

		anima = GameObject.FindObjectOfType<Animation_Test> ();
		sonic = GameObject.Find ("Sonic").gameObject;
		StartCoroutine (SacaObstaculos ());
		vida = 100;
		
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (vida < 0)
		{
			if (yasereproduciomuerte == false)
			StartCoroutine (MuestraPantallaGanar ());
		}
		if (moviendoIzq)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (26.0f, transform.position.y, transform.position.z), 2.0f*Time.deltaTime);
		}

		if (moviendoDer)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (-36.0f, transform.position.y, transform.position.z), 2.0f*Time.deltaTime);
		}
		if (moviendoCentro)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (0.0f, transform.position.y, transform.position.z), 2.0f*Time.deltaTime);
		}
		transform.LookAt (sonic.transform);
		transform.position = new Vector3 (transform.position.x, transform.position.y, sonic.transform.position.z+40);
	}

	IEnumerator SacaObstaculos ()
	{
		while (true && enemigovivo)
		{
			shake.duracionShake = 1;
			anima.AttackAni();
			yield return new WaitForSeconds (0.5f);
			GameObject obstaculo = Instantiate (EsferaFuego, transform.GetChild(0).Find("Spawner").position, Quaternion.identity);
		//	obstaculo.transform.position = Vector3.Lerp (obstaculo.transform.position, Terreno.jugador.transform.position, 1.0f*Time.deltaTime);
			if (moviendoCentro)
			{
				moviendoIzq = true;
				moviendoCentro = false;
			}
			yield return new WaitForSeconds (1.0f);

			if (moviendoIzq)
			{
				moviendoIzq = false;
				moviendoCentro = true;
			}
			yield return new WaitForSeconds (1.5f);

			anima.AttackAni();
			yield return new WaitForSeconds (0.5f);
			GameObject obstaculo2 = Instantiate (EsferaFuego, transform.GetChild(0).Find("Spawner").position, Quaternion.identity);

			yield return new WaitForSeconds (1.0f);
			moviendoDer = true;
			yield return new WaitForSeconds (1.0f);

			anima.AttackAni();
			yield return new WaitForSeconds (0.5f);
			GameObject obstaculo3 = Instantiate (EsferaFuego, transform.GetChild(0).Find("Spawner").position, Quaternion.identity);
			if (moviendoDer)
			{
				moviendoDer = false;
				moviendoCentro = true;
			}
			yield return new WaitForSeconds (1.0f);

		}
	}

	IEnumerator MuestraPantallaGanar()
	{
		SimpleCharacterControl.enjuego = false;
		yasereproduciomuerte = true;
		enemigovivo = false;
		anima.DeathAni ();
		yield return new WaitForSeconds (1.5f);
		TextoYouWin.SetActive (true);
		PantallaNegra.SetActive (true);
		yield return new WaitForSeconds (2.8f);
		NextScene.nextScene = "Demo";
		SceneManager.LoadScene ("LoadingScene");
	}
}
