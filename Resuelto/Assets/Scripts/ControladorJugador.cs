using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    private float horizontalInput;
    public float velocidad = 10;
    public float limite = 10;

    public GameObject prefabPizza;

    public Transform padreComida;

    public float margenVertical = 1;
    
    void Update()
    {
        #region Movimiento
        // Lo muevo
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate( horizontalInput * velocidad 
                            * Time.deltaTime * Vector3.right);

        // No lo dejo ir a la izquierda de la pantalla
        if (transform.position.x < -limite)
        {
            transform.position = new Vector3(
                -limite,
                transform.position.y,
                transform.position.z);
        }
        
        // No lo dejo ir a la derecha de la pantalla
        if (transform.position.x > limite)
        {
            transform.position = new Vector3(
                limite,
                transform.position.y,
                transform.position.z);
        }
        #endregion

        #region Proyectiles

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabPizza,transform.position + Vector3.up * margenVertical,prefabPizza.transform.rotation,padreComida);
        }

        #endregion
    }
}
