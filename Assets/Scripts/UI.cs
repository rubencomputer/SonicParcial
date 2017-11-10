using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour {


	public Text distancia;
	public Text CoinsT;
	public GameObject pantallaNegra;
	public GameObject pantallaGameOver;
	SimpleCharacterControl personaje;
	public int metros = 0;
	public int coins = 0;
	bool yatemandoAlInicio=false;
	// Use this for initialization
	void Start () {
		SimpleCharacterControl.enjuego = true;
		personaje = GameObject.FindObjectOfType<SimpleCharacterControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		metros += 1;
		distancia.text = metros.ToString();
		CoinsT.text = coins.ToString();

		if (personaje.vidas < 1)
		{
			if (yatemandoAlInicio == false)
				StartCoroutine (YaPerdio());
		}

	}
	IEnumerator YaPerdio()
	{
		SimpleCharacterControl.enjuego = false;
		yatemandoAlInicio = true;
		yield return new WaitForSeconds (1.5f);
		pantallaGameOver.SetActive (true);
		pantallaNegra.SetActive (true);
		yield return new WaitForSeconds (2.8f);
		NextScene.nextScene = "Demo";
		SceneManager.LoadScene ("LoadingScene");
	}
}
