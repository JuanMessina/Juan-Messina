using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverHaciaLaIzquierda : MonoBehaviour
{
    public float velocidad = 30;
    public float limiteIzquierda = -15;
    
    private ControladorJugador referenciaControladorJugador = null;
    private void Start()
    {
        referenciaControladorJugador = GameObject.Find("Jugador").GetComponent<ControladorJugador>();
    }

    void Update()
    {
        if (referenciaControladorJugador.gameOver == false)
        {
            transform.Translate( Time.deltaTime * velocidad * Vector3.left);
        }

        if (transform.position.x < limiteIzquierda && gameObject.CompareTag("Obstaculos"))
        {
            Destroy(gameObject);
        }
    }
}
