using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractor : MonoBehaviour, IInteractor
{
    [SerializeField]
    private Camera camera;

    private Interactable _current;

    public string GetName()
    {
        return name;
    }

    private void Update()
    {
        Vector3 worldMousePosition = camera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward);
        if (Physics.Raycast(camera.transform.position, worldMousePosition - camera.transform.position, out RaycastHit raycastHit))
        {
            if (raycastHit.rigidbody != null && raycastHit.rigidbody.TryGetComponent(out Interactable interactable))
            {
                if (_current != interactable)
                {
                    ActivateCurrent(interactable);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    _current.Interact(this);
                    
                }
            }
            else
            {
                DeactivateCurrent();
            }
        }
        else
        {
            DeactivateCurrent();
        }
    }

    private void ActivateCurrent(Interactable interactable)
    {
        DeactivateCurrent();
        _current = interactable;
        _current.Activate(this);
    }

    private void DeactivateCurrent()
    {
        if (_current != null)
        {
            _current.Deactivate(this);
            _current = null;
        }
    }
}
