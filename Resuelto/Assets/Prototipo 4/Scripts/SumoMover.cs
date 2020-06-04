using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoMover : MonoBehaviour
{
    public Rigidbody rb = null;

    public float speed = 5, fuerzaEmpuje = 5;

    public Transform puntoFocalTransform = null;

    private void Update()
    {
        rb.AddForce(puntoFocalTransform.forward * (Input.GetAxis("Vertical") * (speed * Time.deltaTime)));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            //                       DEST           -        ORIGEN
            Vector3 dir = (other.transform.position - transform.position).normalized;
            other.rigidbody.AddForce(dir * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}