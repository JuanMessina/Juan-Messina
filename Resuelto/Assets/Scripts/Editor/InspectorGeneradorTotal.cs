using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GeneradorTotal), true), CanEditMultipleObjects]
public class InspectorGeneradorTotal : Editor
{
    private GeneradorTotal generador = null;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generar Todo"))
        {
            if (generador == null)
                generador = target as GeneradorTotal;

            generador.GenerarTodo();
        }
    }
}