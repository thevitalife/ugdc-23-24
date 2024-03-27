using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour, ICharacterInteractor
{
    [SerializeField]
    private SimpleSampleCharacterControl characterControl;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Inventory inventory;
    
    private List<Interactable> interactables = new List<Interactable>();

    public Animator Animator
    {
        get
        {
            return animator;
        }
    }

    public Inventory Inventory 
    {
        get 
        { 
            return inventory; 
        }
    }


    public void ActivateCutsceneMode()
    {
        characterControl.enabled = false;
    }

    public void DeActivateCutsceneMode()
    {
        characterControl.enabled = true;
    }

    public string GetName()
    {
        return name;
    }

    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }

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
        interactables.RemoveAll(interactable => interactable == null);
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Interactable interactable in interactables)
            {
                interactable.Interact(this);
            }
        }
    }
}
