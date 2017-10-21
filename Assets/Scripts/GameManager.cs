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
	public static int coins = 0; 
	public static int distancia = 0;
	public static int enemigos = 0;
	public static int score = 0;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			Cargar ();
			InicializaDatos ();

		}

		if (Input.GetKeyDown (KeyCode.G)) 
			Guardar ();

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

		//Por el momento solo guarda 4 variables, 
		//en caso de querer guardar mas
		//1-Crear una variable en la clase SaveData Ej: public int edad
		//2-Crear otra variable en esta instancia Ej:  public static int _edad (Esta variable es la que se va a modificar durante el juego)
		//3-Finalmente igualarlas en esta funcion EJ:  Progreso.edad = _edad;
		Progreso.topCoins = coins;
		Progreso.topDistancia = distancia;
		Progreso.topEnemigos = enemigos;
		Progreso.topScore = score;

		print (Application.persistentDataPath); //Imprime la ruta donde se guarda el JSON
		string ArchivoJson = JsonUtility.ToJson (Progreso); //Convierte toda nuestra clase SaveData a un string 
		File.WriteAllText (Application.persistentDataPath + "Progreso.json", ArchivoJson); //Genera el archivo JSON con el string ArchivoJson en el directorio.
		Debug.Log (ArchivoJson);

		if (ArchivoJson.Length > 0 && ArchivoJson != null) //Se asegura de que se haya creado el archivo JSON
			print ("Se ha guardado la partida");
		else
			print ("Error al guardar");
		
	}

	/*AQUI SE HACE LA LECTURA DE DATOS, SE ASIGNAN LOS VALORES A LAS VARIABLES QUE VAMOS A INICIALIZAR
	 DEL JSON ANTERIORMENTE CONVERTIDO EN OBJETO */
	public static void InicializaDatos()
	{
		//Como el archivo es un JSON se convirtiío en objeto en la variable itemData, ahora para cargar el valor que queramos
		// solo hay que hacer la conversion especificandole la posicion (ya que el json es un arreglo) le indicamos itemData["nombreDelaVariable"].ToString()
		//y el out es donde se va a asignar ese valor.

		//Tipo de dato         NombreVariable a extraer   Nombre variable a asignar ese dato
		int.TryParse(itemData["topScore"].ToString(), out score) ;
		int.TryParse(itemData["topEnemigos"].ToString(), out enemigos) ;
		int.TryParse(itemData["topDistancia"].ToString(), out distancia) ;
		int.TryParse(itemData["topCoins"].ToString(), out coins) ;

		print ("Se han inicializado las variables");
	}

}
