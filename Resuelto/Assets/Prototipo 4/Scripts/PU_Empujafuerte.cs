using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Empujafuerte : MonoBehaviour
{
    public Renderer rend;
    public Collider coll;
    
    public float duracion = 2, cuantoMasEmpujamos = 2;

    private SumoMover jugador = null;

    private void OnTriggerEnter(Collider other)
    {
        var posibleJugador = other.gameObject.GetComponent<SumoMover>();
        if (null != posibleJugador)
        {
            jugador = posibleJugador;
            jugador.GetComponent<Renderer>().material.color = Color.yellow;
            jugador.fuerzaEmpuje += cuantoMasEmpujamos;
            Invoke(nameof(DeshacerPU),duracion);

            rend.enabled = false;
            Destroy(coll);
        }
    }

    private void DeshacerPU()
    {
        jugador.GetComponent<Renderer>().material.color = Color.white;
        jugador.fuerzaEmpuje -= cuantoMasEmpujamos;
        Destroy(gameObject);
    }
}