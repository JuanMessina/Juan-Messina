using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneradorProceduralBase : MonoBehaviour
{
    public GameObject[] prefabs = null;

    public float radio = 1;

    public Vector2Int minMaxElementosGenerador = new Vector2Int(1, 3);

    public float distanciaMinimaAleatoria = 1;

    public int intentosMaximos = 10;
    
    private void Start()
    {
        Generar();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    public void Generar()
    {
        Limpiar();

        int generarNCantidad = Random.Range(minMaxElementosGenerador.x, minMaxElementosGenerador.y);

        List<int> indicesAleatoriosElegidos = new List<int>();
        List<Vector2> posicionesUtilizadas = new List<Vector2>();


        for (int i = 0; i < generarNCantidad; i++)
        {
            int indiceGenerado = 0;

            if (prefabs.Length >= generarNCantidad)
            {
                do
                {
                    indiceGenerado = Random.Range(0, prefabs.Length);
                } while (indicesAleatoriosElegidos.Contains(indiceGenerado));

                indicesAleatoriosElegidos.Add(indiceGenerado);
            }

            var objetoCreado = Instantiate(prefabs[indiceGenerado], transform);

            Vector2 positionAleatoria = Vector2.zero;

            
            bool noHayNingunoMasCerca;
            int contadorIntentos = 0;
            
            do
            {
                noHayNingunoMasCerca = true;
                positionAleatoria = Random.insideUnitCircle * radio;
                
                foreach (var posicionGuardada in posicionesUtilizadas)
                {
                    if (Vector2.Distance(positionAleatoria,posicionGuardada) < distanciaMinimaAleatoria)
                    {
                        noHayNingunoMasCerca = false;
                        break;
                    }
                }

                contadorIntentos++;
            } while (!noHayNingunoMasCerca && contadorIntentos < intentosMaximos);

            posicionesUtilizadas.Add(positionAleatoria);

            objetoCreado.transform.localPosition = new Vector3(positionAleatoria.x, 0, positionAleatoria.y);
        }
    }

    private void Limpiar()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}