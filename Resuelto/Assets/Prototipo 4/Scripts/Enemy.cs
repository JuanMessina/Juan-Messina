using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Transform playerTransform;

    public Rigidbody rb = null;

    public float speed = 100, fuerzaEmpuje = 5;

    private void Awake()
    {
        if (null == playerTransform)
        {
            playerTransform = FindObjectOfType<SumoMover>().transform;
        }
    }

    private void Update()
    {
        // DondeVoy - DondeEstoy                                "Normalize" le saca la parte de distancia
        Vector3 irHacia = (playerTransform.position - transform.position).normalized;

        rb.AddForce(irHacia * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //                       DEST           -        ORIGEN
            Vector3 dir = (other.transform.position - transform.position).normalized;
            other.rigidbody.AddForce(dir * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}