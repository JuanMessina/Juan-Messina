using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FueraDeLimites : MonoBehaviour
{

    public float limiteSuperior = 30;

    public float limiteInferior = -10;
    
    void Update()
    {
        if (transform.position.z > limiteSuperior)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < limiteInferior)
        {
            Destroy(gameObject);
            Debug.Log("Perdiste :(");
        }
    }
}
