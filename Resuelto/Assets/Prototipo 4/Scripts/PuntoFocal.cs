using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoFocal : MonoBehaviour
{
    public float velocidadRot = 5;

    void Update()
    {
        transform.Rotate(Vector3.up, velocidadRot * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
}