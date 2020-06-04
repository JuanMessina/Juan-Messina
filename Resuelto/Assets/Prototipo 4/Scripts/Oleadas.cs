using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oleadas : MonoBehaviour
{
    public float radius = 20;

    public GameObject enemigo = null;

    public AnimationCurve crecimientoEnDificultad = AnimationCurve.Linear(0, 0, 1, 1);

    private int oleada = 1;

    public GameObject[] PUps;
    
    void Update()
    {
        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            int cantidadDeEnemigos = Mathf.RoundToInt(
                crecimientoEnDificultad.Evaluate(oleada * .1f - .1f) * 10 + 1);
            
            for (int i = 0; i < cantidadDeEnemigos; i++)
            {
                SpawnAlgo(enemigo);
            }
            
            SpawnAlgo(PUps[Random.Range(0,PUps.Length)]);

            oleada++;
        }
    }

    private void SpawnAlgo(GameObject khe)
    {
        Vector3 posicionDelEnemigo = new Vector3(Random.value, 0, Random.value) * radius;
        Instantiate(khe, posicionDelEnemigo, Quaternion.identity, transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, .1f);
        Gizmos.DrawSphere(transform.position, radius);
    }
}