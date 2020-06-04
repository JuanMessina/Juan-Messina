using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SceneBuilder)), CanEditMultipleObjects]
public class SceneBuilderEditor : Editor
{
    private SceneBuilder builder;
    private SceneBuilder[] builders;

    private void Awake()
    {
        builder = (SceneBuilder) target;

        List<SceneBuilder> buildersList = new List<SceneBuilder>();
        foreach (var single in targets)
        {
            SceneBuilder maybeBuilder = (SceneBuilder) single;
            if (null != maybeBuilder)
                buildersList.Add(maybeBuilder);
        }

        builders = buildersList.ToArray();
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Crear!"))
            builder.Crear();
        
        if (GUILayout.Button("Crear PA TODOS!"))
            foreach (var sceneBuilder in builders)
                sceneBuilder.Crear();
    }
}