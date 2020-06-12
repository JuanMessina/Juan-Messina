using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorTotal : MonoBehaviour
{
    public void GenerarTodo()
    {
        foreach (var generadorHijo in  GetComponentsInChildren<GeneradorProceduralBase>())
        {
            generadorHijo.Generar();
        }
    }
}
