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

	public Transform jugador;
	private float dEntreBloques = 7.6175f;
	private float startZ = 83.7925f;
	private float spawnLeft = -4.0f;
	private float spawnRight = 4.0f;
	private float spawndist = 100.0f;
	private int randomTipo;
	private int randomPosicion;
	// Use this for initialization
	void Start () {
		Instantiate (Todo[0].obs[0], new Vector3 (0, 0, dEntreBloques), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		randomTipo = Random.Range (0, 3);
		randomPosicion = Random.Range (0, 5);
	}
	void OnTriggerEnter(Collider _col)
	{
		Instantiate(Todo[randomTipo].obs[randomPosicion], new Vector3 (0,0,236.1425+dEntreBloques),Quaternion.identity);
		dEntreBloques += 7.6175;
	}
}
