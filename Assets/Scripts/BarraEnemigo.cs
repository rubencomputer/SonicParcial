using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEnemigo : MonoBehaviour {

	Enemigo enemigo;
	int puntosMeta;

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;


	// Use this for initialization
	void Start () {

		enemigo = GameObject.FindObjectOfType<Enemigo> ();



	}

	// Update is called once per frame
	void Update ()
	{
		ControladorBarraSalud ();

	}


	private void ControladorBarraSalud()
	{
		content.fillAmount = ConversionDeFill(enemigo.vida, 100);
		puntosMeta = enemigo.vida;
	}

	private float ConversionDeFill(float valor, float inMax)
	{

		return valor / inMax;

	}
}