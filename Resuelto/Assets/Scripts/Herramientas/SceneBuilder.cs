using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    public GameObject prefab;

    public Vector3 direccion = Vector3.forward;
    public float cadaXUnidades = 2;

    public int cantidad = 1;

    public void Crear()
    {
        for (int i = 0; i < cantidad; i++)
        {
            var prefabRecienCreado = Instantiate(prefab, transform);

            var elTransform = prefabRecienCreado.transform;

            elTransform.localPosition = direccion * cadaXUnidades * i;
            
            float xRandom = Random.value >= .5f ? 1 : -1;
            float zRandom = Random.value >= .5f ? 1 : -1;
            
            elTransform.localScale = new Vector3(xRandom, 1, zRandom);
        }
    }
}