using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

	//Variables utilizadas para alojar los datos que se van a guardar
	//Posteriormente se utilizan en la funcion Guardar();
	//ESTAS VARIABLES SON LAS QUE SE ESCRIBEN EN EL ARCHIVO JSON
	public int topScore;
	public int topCoins;
	public int topEnemigos;
	public int topDistancia;


}
