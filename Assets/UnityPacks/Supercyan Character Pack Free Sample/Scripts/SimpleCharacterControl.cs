﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class SimpleCharacterControl : MonoBehaviour {

    private enum ControlMode
    {
        Tank,
        Direct
    }
	public static bool enjuego=false;
	public GameObject[] vidasUI;

	UI jugadorStats;
    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;
    [SerializeField] private float m_jumpForce = 4;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    [SerializeField] private ControlMode m_controlMode = ControlMode.Direct;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 3.0f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();

	public int vidas = 3;

	public AudioClip[] sonidos;


	public void PlayAudio(int sonido)
	{
		AudioSource audiosurs = GetComponent<AudioSource> ();
		audiosurs.clip = sonidos[sonido];
		audiosurs.PlayOneShot(audiosurs.clip);
	}

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for(int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider)) {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }

		if (collision.gameObject.CompareTag ("Fuego")) 
		{
			collision.gameObject.GetComponent<SphereCollider> ().enabled = false;
			if(vidas > 0)
			vidas -= 1;
			PlayAudio(1);
		}

		if (collision.gameObject.CompareTag ("Bomb")) 
		{
			collision.gameObject.GetComponent<Bomba> ().enabled = true;
			PlayAudio(5);
		}

		if (collision.gameObject.CompareTag ("Moneda")) 
		{
			jugadorStats = GameObject.FindObjectOfType<UI> ();
			jugadorStats.coins += 1; 
			Destroy (collision.gameObject);
			PlayAudio(0);
		}

		if (collision.gameObject.CompareTag ("Vida")) 
		{
			jugadorStats = GameObject.FindObjectOfType<UI> ();
			if(vidas <3)
			vidas += 1;
			Destroy (collision.gameObject);
			PlayAudio(6);
		}
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if(validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        } else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

	void Update () {
		print ("Vidas " + vidas.ToString());
		if (enjuego)
		{
			if (vidas == 3) 
			{
				if(vidasUI[0]!= null)
					vidasUI [0].SetActive (true);
				if(vidasUI[1]!= null)
					vidasUI [1].SetActive (true);
				if(vidasUI[2]!= null)
					vidasUI [2].SetActive (true);
			}
			if (vidas == 2) 
			{			
				if(vidasUI[0]!= null)
					vidasUI [0].SetActive (true);
				if(vidasUI[1]!= null)
					vidasUI [1].SetActive (true);
				if(vidasUI[2]!= null)
					vidasUI [2].SetActive (false);
			}
			if (vidas == 1) 
			{
				if(vidasUI[0]!= null)
					vidasUI [0].SetActive (true);
				if(vidasUI[1]!= null)
					vidasUI [1].SetActive (false);
				if(vidasUI[2]!= null)
					vidasUI [2].SetActive (false);
			}
			if (vidas == 0) 
			{			if(vidasUI[0]!= null)
				vidasUI [0].SetActive (false);
				if(vidasUI[1]!= null)
					vidasUI [1].SetActive (false);
				if(vidasUI[2]!= null)
					vidasUI [2].SetActive (false);
			}

		}


		if(enjuego) ChecaMovimiento ();
        m_animator.SetBool("Grounded", m_isGrounded);

        switch(m_controlMode)
        {
            case ControlMode.Direct:
                DirectUpdate();
                break;

            case ControlMode.Tank:
                TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }

        m_wasGrounded = m_isGrounded;
    }

    private void TankUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool walk = Input.GetKey(KeyCode.LeftShift);

        if (v < 0) {
            if (walk) { v *= m_backwardsWalkScale; }
            else { v *= m_backwardRunScale; }
        } else if(walk)
        {
            v *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
        transform.Rotate(0, m_currentH * m_turnSpeed * Time.deltaTime, 0);

        m_animator.SetFloat("MoveSpeed", m_currentV);

        JumpingAndLanding();
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= m_walkScale;
            h *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if(direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

            m_animator.SetFloat("MoveSpeed", direction.magnitude);
        }

        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

	bool estaDerecha;
	bool estaIzquierda;
	bool estaCentro = true;
	public GameObject entrar;
	void OnTriggerStay(Collider _col)
	{
		if (_col.gameObject.CompareTag ("Door")) 
		{
			entrar.SetActive (true);
			if (Input.GetKeyDown (KeyCode.X)) 
			{
				StartCoroutine (teletransporta());
			}
		}
	}

	void OnTriggerExit(Collider _col)
	{
		if (_col.gameObject.CompareTag ("Door")) 
		{
			entrar.SetActive (false);
		}
	}

	public void ChecaMovimiento()
	{
		if ((Input.GetKeyDown (KeyCode.LeftArrow)) && estaCentro)
		{
			transform.position = new Vector3 (-4.0f, transform.position.y, transform.position.z);
			estaIzquierda = true;
			estaCentro = false;
		}

		if ((Input.GetKeyDown (KeyCode.LeftArrow)) && estaDerecha)
		{
			transform.position = new Vector3 (0.0f, transform.position.y, transform.position.z);
			estaDerecha = false;
			estaCentro = true;
		}

		if ((Input.GetKeyDown (KeyCode.RightArrow)) && estaCentro)
		{
			transform.position = new Vector3 (4.0f, transform.position.y, transform.position.z);
			estaDerecha = true;
			estaCentro = false;
		}

		if ((Input.GetKeyDown (KeyCode.RightArrow)) && estaIzquierda)
		{
			transform.position = new Vector3 (0.0f, transform.position.y, transform.position.z);
			estaCentro = true;
			estaIzquierda = false;
		}
	}

	IEnumerator teletransporta()
	{
		Enemigo.enemigovivo = true;
		Terreno.pool.Clear ();
		GameObject.FindObjectOfType<Flotacion> ().enabled = true;
		NextScene.nextScene = "Test";
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("LoadingScene");

	}

}
