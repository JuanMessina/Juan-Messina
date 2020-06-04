using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetirFondo : MonoBehaviour
{
    private Vector3 posicionInicial;

    private float anchoDeRepeticion;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        anchoDeRepeticion = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < posicionInicial.x - anchoDeRepeticion)
        {
            transform.position = posicionInicial;
        }
    }
}
