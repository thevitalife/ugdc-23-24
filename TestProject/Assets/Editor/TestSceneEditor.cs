using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestSceneEditor : Editor
{
    /*void OnSceneGUI()
    {
        // Get the chosen GameObject
        DrawLine t = target as DrawLine;

        if (t == null || t.GameObjects == null)
            return;

        // Grab the center of the parent
        Vector3 center = t.transform.position;

        // Iterate over GameObject added to the array...
        for (int i = 0; i < t.GameObjects.Length; i++)
        {
            // ... and draw a line between them
            if (t.GameObjects[i] != null)
                Handles.DrawLine(center, t.GameObjects[i].transform.position);
        }
    }*/
}
