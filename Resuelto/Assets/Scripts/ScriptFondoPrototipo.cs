using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFondoPrototipo : MonoBehaviour
{
    public float velocidad = 10;

    private float laMitadDelSprite;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;

        laMitadDelSprite = GetComponent<BoxCollider2D>().size.x / 2;
    }

    void Update()
    {
        // Muevo el fondo entero hacia la izq
        transform.Translate(Vector3.left * (velocidad * Time.deltaTime));

        // Si me pase para la izq, reseteo el fondo
        if (transform.position.x <= posicionInicial.x - laMitadDelSprite)
            transform.position = posicionInicial;
    }
}