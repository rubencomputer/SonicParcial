using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    public Rigidbody jugador;
    bool onleft = false;
    bool oncenter = false;
    bool onright = false;
    bool jumping = false;
    bool sliding = false;
    float speed = 2.0f;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position == new Vector3(0.0f, 1.5f, -7.0f))
        {
            oncenter = true;
        }
        else
        { oncenter = false; }

        if (this.transform.position == new Vector3(-1.0f, 1.5f, -7.0f))
        {
            onleft = true;
        }
        else
        { onleft = false; }

        if (this.transform.position == new Vector3(1.0f, 1.5f, -7.0f))
        {
            onright = true;
        }
        else
        { onright = false; }


        if (Input.GetKey(KeyCode.A))
        {
                if(jugador.transform.position != new Vector3(1.0f, 1.5f, -7.0f))
                {
                    jugador.transform.position = Vector3.MoveTowards(jugador.transform.position, new Vector3(jugador.transform.position.x + 1, jugador.transform.position.y + 0, jugador.transform.position.z + 0), speed * Time.deltaTime);
                }
                
        

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (onright != true)
            {
                jugador.AddForce(Vector3.right);
            }

        }

    }
}
