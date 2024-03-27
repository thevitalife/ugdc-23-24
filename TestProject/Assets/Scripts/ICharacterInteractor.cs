using UnityEngine;

public interface ICharacterInteractor : IInteractor
{
    Inventory Inventory {get;}
    Animator Animator { get; }
    void ActivateCutsceneMode();
    void DeActivateCutsceneMode();
    void SetParent(Transform parent);
}