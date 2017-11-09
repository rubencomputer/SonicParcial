using UnityEngine;
using System.Collections;

public class ShakeCamara : MonoBehaviour
{

	public Transform camTransform;
	public float duracionShake = 0f;

	public float amplitudShake = 0.7f;
	public float decremento = 1.0f;

	Vector3 posicionOriginal;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		posicionOriginal = camTransform.localPosition;
	}

	void Update()
	{
		if (duracionShake > 0)
		{
			camTransform.localPosition = posicionOriginal + Random.insideUnitSphere * amplitudShake;

			duracionShake -= Time.deltaTime * decremento;
		}
		else
		{
			duracionShake = 0f;
			camTransform.localPosition = posicionOriginal;
		}
	}
}