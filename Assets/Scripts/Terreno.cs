using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Terreno : MonoBehaviour {
	
	public GameObject[] Bloques;
	public GameObject[] Puentes;
	public GameObject[] Puenques;
	public GameObject Vacio;
	public GameObject[] Obstaculos;
	public GameObject[] Items;
	private float dEntreBloques = 7.6175f;
	private float escenaZ = 83.7925f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			Instantiate (Bloques[3], new Vector3(0,0,dEntreBloques), Quaternion.identity);
			dEntreBloques+=7.6175f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (escenaZ < 100) {
			for (int i = 0; i < 5; i++) {
				Instantiate (Bloques [3], new Vector3 (0, 0, dEntreBloques), Quaternion.identity);
				dEntreBloques += 7.6175f;
			}	
		}
	}
}
