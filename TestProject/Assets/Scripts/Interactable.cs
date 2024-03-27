using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Activate(IInteractor interactor)
    {
        Debug.Log(name + " activated by " + interactor.GetName());
    }

    public virtual void Interact(IInteractor interactor)
    {
        Debug.Log(name + " interacted by " + interactor.GetName());
    }

    public virtual void Deactivate(IInteractor interactor)
    {
        Debug.Log(name + " deactivated by " + interactor.GetName());
    }
}
