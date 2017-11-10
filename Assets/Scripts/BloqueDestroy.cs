using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueDestroy : MonoBehaviour {

	public GameObject BloqueBye;

	// Use this for initialization
	void Start () {
		StartCoroutine (boom ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator boom()
	{
		yield return new WaitForSeconds (7.5f);
		Destroy(BloqueBye);
	}
}
