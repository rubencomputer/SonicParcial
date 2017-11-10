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
	public static List<GameObject> pool = new List<GameObject> ();

	public  List<GameObject> poolCopia = new List<GameObject> ();

	public List<GameObject> posItem = new List<GameObject>();

	public GameObject objetos;
	public GameObject spawnItem;
	public GameObject PALMERA;
	public GameObject BOMBA;
	public GameObject COIN;
	public GameObject CORAZON;

	public static Transform jugador;
	public static float dEntreBloques = 0f;
	private float startZ = 83.7925f;
	private float spawnLeft = -4.0f;
	private float spawnMiddle = 0.0f;
	private float spawnRight = 4.0f;
	private float spawndist = 100.0f;
	private int randomTipo;
	private int randomPosicion;
	public int randomItem;
	private int randomItemSelect;
	public GameObject suelo;
	// Use this for initialization

	SimpleCharacterControl jugadorStats;
	void Start () {
		jugadorStats = GameObject.FindObjectOfType<SimpleCharacterControl> ();
		pool.Add (suelo); 
		pool.Add (suelo); 
		pool.Add (suelo);
		pool.Add (suelo);
		poolCopia = pool;

		jugador = GameObject.FindWithTag ("Player").transform;

		ColectaTransforms ();

	}
	// Update is called once per frame
	void Update () {
		randomTipo = Random.Range (0, 2);
		randomItem = Random.Range (1, 75);
		randomItemSelect = Random.Range (1, 100);
		if (randomItemSelect == 30) {
			if(spawnItem !=null)
				Instantiate (spawnItem,  new Vector3(posItem [randomItem].transform.position.x ,posItem [randomItem].transform.position.x,posItem [randomItem].transform.position.z+50), Quaternion.identity);
		}

		if (randomItemSelect == 1) {
			if(spawnItem !=null)
				Instantiate (PALMERA, new Vector3(posItem [randomItem].transform.position.x-30 ,-5,posItem [randomItem].transform.position.z+50), Quaternion.identity);
		}

		if (randomItemSelect == 2) {
			if(spawnItem !=null)
				Instantiate (PALMERA, new Vector3(posItem [randomItem].transform.position.x+30 ,-5,posItem [randomItem].transform.position.z+50), Quaternion.identity);
		}

		if (randomItemSelect == 50) {
			if(spawnItem !=null)
				Instantiate (BOMBA, new Vector3(posItem [randomItem].transform.position.x ,posItem [randomItem].transform.position.y+1,posItem [randomItem].transform.position.z+50), Quaternion.identity);
		}
		if (randomItemSelect == 60) {
			if(spawnItem !=null)
				Instantiate (COIN, new Vector3(posItem [randomItem].transform.position.x ,posItem [randomItem].transform.position.y+1,posItem [randomItem].transform.position.z+50), Quaternion.identity);
		}

		if (randomItemSelect == 99 && jugadorStats.vidas < 3) {
			if(spawnItem !=null)
				Instantiate (CORAZON, new Vector3(posItem [randomItem].transform.position.x ,posItem [randomItem].transform.position.y+1,posItem [randomItem].transform.position.z+50), Quaternion.identity);
		}

	}
	void OnTriggerEnter(Collider _col)
	{
		
		if (_col.gameObject.CompareTag("Untagged"))
		{
			print("Colision con pared");
			GenerarSuelo ();
			_col.gameObject.GetComponent<BoxCollider> ().enabled = false;
			for (int i = 0; i < _col.transform.childCount-1; i++)
			{
				_col.transform.GetChild (i).transform.GetChild (0).GetChild (1).gameObject.SetActive (true);
				_col.transform.GetChild (i).transform.GetChild (0).GetChild (1).gameObject.SetActive (true);
				_col.transform.GetChild (i).transform.GetChild (0).GetChild (1).gameObject.SetActive (true);


			}
			_col.gameObject.SetActive (false);
			/*
			Instantiate(Todo[0].obs[randomTipo], new Vector3 (0,0,236.1425f+dEntreBloques),Quaternion.identity, objetos);
			dEntreBloques += 114.2625f;
			Destroy (_col.gameObject, 3.0f);
*/
		}
	}

	public static GameObject GenerarSuelo()
	{
		for (int i = 0; i < pool.Count; i++)
		{
			if (pool [i].activeSelf == false)
			{
				pool [i].SetActive (true);
				pool [i].transform.position = new Vector3 (0, 0, jugador.position.z);
				pool [i].GetComponent<BoxCollider> ().enabled = true;
				return pool [i];
			}
		}

	//	GameObject nuevoSuelo = Instantiate(Todo[0].obs[randomTipo], new Vector3 (0,0,236.1425f+dEntreBloques),Quaternion.identity);
		GameObject nuevoSuelo = Instantiate(pool[1], new Vector3 (0,0,114.2625f),Quaternion.identity) as GameObject;

		pool.Add (nuevoSuelo);
		return nuevoSuelo;
	}


	public void ColectaTransforms()
	{
		for (int i = 0; i < suelo.transform.childCount-1; i++)
		{
			posItem.Add(suelo.transform.GetChild(i).transform.GetChild(0).GetChild(1).gameObject);
			posItem.Add(suelo.transform.GetChild(i).transform.GetChild(0).GetChild(2).gameObject);
			posItem.Add(suelo.transform.GetChild(i).transform.GetChild(0).GetChild(3).gameObject);
						
					
		}
	}
}
