using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractor : MonoBehaviour, IInteractor
{
    private const string Ground = "Ground";

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private PlayerInputProvider playerInputProvider;
    
    public string GetName()
    {
        return name;
    }

    private void Update()
    {
        var mouseButton0Down = Input.GetMouseButtonDown(0);
        Vector3 worldMousePosition = camera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
        if (Physics.Raycast(camera.transform.position, worldMousePosition - camera.transform.position, out RaycastHit raycastHit)
            && mouseButton0Down)
        {
            if (raycastHit.rigidbody != null && raycastHit.rigidbody.TryGetComponent(out Interactable interactable) )
            {
                playerInputProvider.SetTargetInteractable(interactable);
            }
            else if (raycastHit.collider.CompareTag(Ground))
            {
                playerInputProvider.SetTargetPoint(raycastHit.point);
            }
        }
      
    }
    
}
