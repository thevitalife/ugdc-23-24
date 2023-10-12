using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Activate(PlayerInteractor interactor)
    {
        Debug.Log(name + " activated");
    }

    public virtual void Interact(PlayerInteractor interactor)
    {
        Debug.Log(name + " interacted");
    }

    public virtual void Deactivate(PlayerInteractor interactor)
    {
        Debug.Log(name + " deactivated");
    }
}
