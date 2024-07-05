using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAiming : MonoBehaviour
{
    private Camera main;
    private void Awake()
    {
        main = Camera.main;
    }

    private void Update()
    {
        transform.forward = main.transform.position - transform.position;
    }
}
