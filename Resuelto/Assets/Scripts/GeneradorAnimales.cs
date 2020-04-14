using UnityEngine;

public class GeneradorAnimales : MonoBehaviour
{
    public GameObject[] prefabsAnimales = null;

    public float margenAleatorioX = 15;

    public float crearCadaXSegundos = 1.5f;

    public void StartAnimalSpawn()
    {
        InvokeRepeating(nameof(CrearAnimalito), 1, crearCadaXSegundos);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CrearAnimalito();
        }
    }

    void CrearAnimalito()
    {
        GameObject animalRecienInstanciado = Instantiate(
            prefabsAnimales[Random.Range(0, prefabsAnimales.Length)],
            transform);

        animalRecienInstanciado.transform.localPosition =
            new Vector3(Random.Range(-margenAleatorioX, margenAleatorioX), 0, 0);
    }
}
