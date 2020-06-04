using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    public Transform transformDelAuto;

    public float distanciaSelfieStick = 6;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transformDelAuto.position.z - distanciaSelfieStick);
    }
}
