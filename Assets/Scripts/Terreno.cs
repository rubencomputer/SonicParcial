using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Terreno : MonoBehaviour {
	[System.Serializable]
	public class Obstaculos2
	{
		public string tipoObjeto;
		public GameObject[] obs;
	}

	public Obstaculos2[] Todo;

	private float dEntreBloques = 7.6175f;
	private float escenaZ = 83.7925f;

	// Use this for initialization
	void Start () {
		/*for (int i = 0; i < 10; i++) {
			Instantiate (Bloques[3], new Vector3(0,0,dEntreBloques), Quaternion.identity);
			dEntreBloques+=7.6175f;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		/*if (escenaZ < 100) {
			for (int i = 0; i < 5; i++) {
				Instantiate (Bloques [3], new Vector3 (0, 0, dEntreBloques), Quaternion.identity);
				dEntreBloques += 7.6175f;
			}	
		}*/
	}
}
