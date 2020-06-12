using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GeneradorProceduralBase), true), CanEditMultipleObjects]
public class InspectorAMedida_Generador : Editor
{
    private GeneradorProceduralBase generador = null;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generar"))
        {
            if (generador == null)
                generador = target as GeneradorProceduralBase;

            generador.Generar();
        }
    }
}