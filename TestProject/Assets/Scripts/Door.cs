using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string accessInventoryItemKey = "DoorKey";

    public override void Interact(IInteractor interactor)
    {

        bool isOpen = animator.GetBool("IsOpen");

        if (isOpen || (interactor is ICharacterInteractor characterInteractor && characterInteractor.Inventory.Contains(accessInventoryItemKey)))
        {
            base.Interact(interactor);
            animator.SetBool("IsOpen", !isOpen);
        }
    }

    public override void Deactivate(IInteractor interactor)
    {
        base.Deactivate(interactor);
        animator.SetBool("IsOpen", false);
    }
}
