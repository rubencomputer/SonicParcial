using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeeStats : MonoBehaviour {

	public Text topScoreText;
	public Text topEnemigosText;
	public Text topDistanciaText;
	public Text topCoinsText;
	// Use this for initialization
	void Start () 
	{
		GameManager.Cargar ();
		GameManager.InicializaDatos ();

		topScoreText.text = GameManager.score.ToString();
		topEnemigosText.text = GameManager.enemigos.ToString();
		topCoinsText.text = GameManager.coins.ToString();
		topDistanciaText.text = GameManager.distancia.ToString();
		
	}

}
