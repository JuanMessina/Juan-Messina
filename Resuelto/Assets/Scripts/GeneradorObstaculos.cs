using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObstaculos : MonoBehaviour
{
    public GameObject prefabObstaculo = null;

    public float delay = 2, crearOstaculoCada = 2;
    
    private Vector3 posicion = new Vector3(25,0,0);
    
    private ControladorJugador referenciaControladorJugador = null;

    void Start()
    {
        InvokeRepeating( nameof(CrearObstaculo) ,delay,crearOstaculoCada);
        referenciaControladorJugador = GameObject.Find("Jugador").GetComponent<ControladorJugador>();
    }

    void CrearObstaculo()
    {
        if (!referenciaControladorJugador.gameOver)
        {
            Instantiate(prefabObstaculo, posicion, prefabObstaculo.transform.rotation);
        }
    }
}
