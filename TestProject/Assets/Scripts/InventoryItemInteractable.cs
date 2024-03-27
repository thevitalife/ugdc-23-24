using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemInteractable : Interactable
{
    [SerializeField]
    private string id;

    [SerializeField]
    private int count = 1;

    public override void Interact(IInteractor interactor)
    {
        base.Interact(interactor);
        if (interactor is ICharacterInteractor characterInteractor)
        {
            characterInteractor.Inventory.Add(id, count);
            Destroy(gameObject);
        }
    }
}
