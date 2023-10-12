using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField]
    private Animator animator;

    public override void Interact(PlayerInteractor interactor)
    {
        base.Interact(interactor);
        animator.SetBool("IsOpen", !animator.GetBool("IsOpen"));
    }

    public override void Deactivate(PlayerInteractor interactor)
    {
        base.Deactivate(interactor);
        animator.SetBool("IsOpen", false);
    }
}
