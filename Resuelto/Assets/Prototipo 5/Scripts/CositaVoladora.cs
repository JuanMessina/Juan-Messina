using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CositaVoladora : MonoBehaviour
{
    public Rigidbody miRB = null;

    public int puntos = 1;
    
    private void OnValidate()
    {
        if (miRB == null)
            miRB = GetComponent<Rigidbody>();
    }

    public void Vuela(float fuerzaVertical, Vector3 fuerzaTorque)
    {
        miRB.AddForce(Vector3.up * fuerzaVertical, ForceMode.Impulse);
        miRB.AddTorque(fuerzaTorque, ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        if (CompareTag("CositaMala"))
        {
            // GameOver
            Debug.Log("PERDISTE!");
        }
        else if (CompareTag("CositaBuena"))
        {
            // Dar {puntos}
            Debug.Log($"+{puntos}");
        }
    }
}