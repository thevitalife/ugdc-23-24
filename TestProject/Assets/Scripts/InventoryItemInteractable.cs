using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemInteractable : Interactable
{
    [SerializeField]
    private string id;

    [SerializeField]
    private int count = 1;

    private bool isContextMenuCalled;

    public override void Interact(IInteractor interactor)
    {
        isContextMenuCalled = true;
        ContextMenuManager.Instance.Show(transform.position, new ContextMenuAction() { Title = "Collect", Callback =
            () =>
            {
                FinishInteract(interactor);
            }});
    }

    private void FinishInteract(IInteractor interactor)
    {
        base.Interact(interactor);
        if (interactor is ICharacterInteractor characterInteractor)
        {
            characterInteractor.Inventory.Add(id, count);
            Destroy(gameObject);
        }
    }

    public override void Deactivate(IInteractor interactor)
    {
        base.Deactivate(interactor);
        if (isContextMenuCalled)
        {
            isContextMenuCalled = false;
            ContextMenuManager.Instance.Hide();
        }
    }
}
