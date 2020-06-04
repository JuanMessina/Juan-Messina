using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    private Rigidbody miRigidbody = null;

    public Animator anim = null;

    public float fuerzaDeSalto = 10;
    public float modificadorGravedad = 1;

    public bool estaPisandoElSuelo = true;

    public bool gameOver = false;

    // ASTERISCO: ESTO ES MUY CARO, TRATAR DE EVITARLO
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();

        //Physics.gravity = Physics.gravity * modificadorGravedad;
        Physics.gravity *= modificadorGravedad;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaPisandoElSuelo)
        {
            miRigidbody.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
            estaPisandoElSuelo = false;
            anim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Piso"))
        {
            estaPisandoElSuelo = true;
        }
        else if (other.gameObject.CompareTag("Obstaculos"))
        {
            gameOver = true;
            Debug.Log("PERDISTEEEE!   :(");
        }
    }
}