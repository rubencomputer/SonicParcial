using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cargar : MonoBehaviour {

	// Use this for initialization
	public void CargarEscena()
	{
		NextScene.nextScene = "Demo";
		SceneManager.LoadScene ("LoadingScene");
	}
}
