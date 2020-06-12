using System.Collections;
using Unity.Collections;
using UnityEngine;

public class Creador : MonoBehaviour
{
    public bool enJuego = true;

    public Vector2 alturaMinMax = new Vector2(5, 10);

    [Range(1, 2)]
    public float escalarFuerzaVertical = 1.8f;

    public float anchoLineas = 7;

    public Vector2 torqueMinMax = new Vector2(5, 15);

    public CositaVoladora[] prefabsBuenos, prefabsMalos;

    [Range(.1f, 1.5f)]
    public float crearCositaCadaInicial = 1;

    public float crearCadaActual = 1;

    [Range(0, 1)]
    public float porcentajeCosaMala = .3f;

    public AnimationCurve incrementoEnDificultad;

    public float tiempoParaMaxDificultad = 10;

    private void Start()
    {
        StartCoroutine(CrearCadaXSegundosRoutine());
    }

    IEnumerator CrearCadaXSegundosRoutine()
    {
        while (enJuego)
        {
            CrearCositaVoladora();

            crearCadaActual =
                incrementoEnDificultad.Evaluate(Time.realtimeSinceStartup / tiempoParaMaxDificultad);

            yield return new WaitForSeconds(Mathf.Max(crearCositaCadaInicial - crearCadaActual, .9f));
        }
    }

    private void CrearCositaVoladora()
    {
        var alturaRandom = Random.Range(alturaMinMax.x, alturaMinMax.y);


        CositaVoladora prefabAInstanciar = null;

        if (Random.value <= porcentajeCosaMala)
            prefabAInstanciar = prefabsMalos[Random.Range(0, prefabsMalos.Length)];
        else
            prefabAInstanciar = prefabsBuenos[Random.Range(0, prefabsBuenos.Length)];


        CositaVoladora nuevaCosita = Instantiate(prefabAInstanciar, transform);

        nuevaCosita.transform.localPosition = Vector3.right * Random.Range(-anchoLineas, anchoLineas);

        nuevaCosita.Vuela(
            alturaRandom * escalarFuerzaVertical,
            new Vector3(
                Random.Range(torqueMinMax.x, torqueMinMax.y),
                Random.Range(torqueMinMax.x, torqueMinMax.y),
                Random.Range(torqueMinMax.x, torqueMinMax.y)
            ));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CrearCositaVoladora();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Vector3 origenLineaIzquierda = transform.position - Vector3.right * anchoLineas;
        Vector3 origenLineaDerecha = transform.position + Vector3.right * anchoLineas;

        Gizmos.DrawLine(origenLineaIzquierda, origenLineaIzquierda + Vector3.up * alturaMinMax.x);
        Gizmos.DrawLine(origenLineaDerecha, origenLineaDerecha + Vector3.up * alturaMinMax.y);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(origenLineaIzquierda, origenLineaDerecha);
    }
}