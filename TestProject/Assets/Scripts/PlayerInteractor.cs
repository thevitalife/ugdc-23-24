using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private List<Interactable> interactables = new List<Interactable>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out Interactable interactable))
        {
            interactable.Activate(this);
            interactables.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out Interactable interactable))
        {
            interactable.Deactivate(this);
            interactables.Remove(interactable);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Interactable interactable in interactables)
            {
                interactable.Interact(this);
            }
        }
    }
}
