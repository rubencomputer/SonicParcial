using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class GameManager : MonoBehaviour {

	public static SaveData Progreso;
	public static string jsonString;
	public static JsonData itemData; 


	//VARIABLES A MODIFICAR MIENTRAS SE JUEGA
	public static int coins = 1999; 
	public static int distancia = 1000000;
	public static int enemigos = 1;
	public static int score = 1;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Cargar ();
			InicializaDatos ();

		}

	}
	

	//FUNCION QUE SOLO CARGA EL ARCHIVO JSON CONVIRTIENDOLO EN UN OBJETO PARA UNITY
	public static void Cargar()
	{
		jsonString = File.ReadAllText (Application.persistentDataPath + "Progreso.json");
		Progreso = JsonUtility.FromJson<SaveData> (jsonString);
		itemData = JsonMapper.ToObject (jsonString);
		Debug.Log (jsonString);
	}


	//FUNCION QUE GUARDA LOS VALORES DE LAS VARIABLES EN EL ARCHIVO JSON
	public static void Guardar()
	{

		Progreso.topCoins = coins;
		Progreso.topDistancia = distancia;
		Progreso.topEnemigos = enemigos;
		Progreso.topScore = score;

		print (Application.persistentDataPath);
		string ArchivoJson = JsonUtility.ToJson (Progreso);
		File.WriteAllText (Application.persistentDataPath + "Progreso.json", ArchivoJson);
		Debug.Log (ArchivoJson);

		if(ArchivoJson.Length > 0 && ArchivoJson != null) //Se asegura de que se haya creado el archivo JSON
			print ("Se ha guardado la partida");
		
	}

	/*AQUI SE HACE LA LECTURA DE DATOS, SE ASIGNAN LOS VALORES A LAS VARIABLES QUE VAMOS A INICIALIZAR
	 DEL JSON ANTERIORMENTE CONVERTIDO EN OBJETO */
	public static void InicializaDatos()
	{
		//Como el archivo es un JSON (String), hago la conversion de string al tipo de variable que necesitamos
		int.TryParse(itemData["topScore"].ToString(), out score) ;
		int.TryParse(itemData["topEnemigos"].ToString(), out enemigos) ;
		int.TryParse(itemData["topDistancia"].ToString(), out distancia) ;
		int.TryParse(itemData["topCoins"].ToString(), out coins) ;

		print ("Se han inicializado las variables");
	}

}
