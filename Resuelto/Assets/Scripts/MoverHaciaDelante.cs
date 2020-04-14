using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverHaciaDelante : MonoBehaviour
{
    public float velocidad = 20;
    
    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }
}
