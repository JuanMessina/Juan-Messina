using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVehiculo : MonoBehaviour
{
    public float velocidadMovimiento = 15, velocidadDeGiro = 5;
    //public float velocidadDeGiro = 5;
    
    private float inputHorizontal;
    private float inputVertical;
    
    // Y ACA PUEDO ESCRIBIR UN COMENTARIO
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        
        transform.Translate(inputVertical * 
                            Vector3.forward * velocidadMovimiento * Time.deltaTime);
        
        
        /*
         transform.Translate(inputHorizontal *
                            // Direccion  x    escalable    x en funcion del tiempo
                            Vector3.right * velocidadDeGiro * Time.deltaTime);
       */
        
        // if(inputHorizontal == 1 || inputHorizontal == -1)
        if (inputVertical != 0) 
        {
            transform.Rotate(Vector3.up,inputHorizontal * velocidadDeGiro * Time.deltaTime);
        }
    }
}
