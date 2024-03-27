using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CartInteractable : Interactable
{
    [SerializeField]
    private PlayableDirector director;

    private ICharacterInteractor currentInteractor;
    private TrackAsset track;

    private void Awake()
    {
        track = (director.playableAsset as TimelineAsset).GetOutputTrack(0);
    }

    public override void Interact(IInteractor interactor)
    {
        base.Interact(interactor);
        if (interactor is ICharacterInteractor characterInteractor)
        {
            InteractWithCharacter(characterInteractor);
        }
    }

    private void InteractWithCharacter(ICharacterInteractor interactor)
    {
        interactor.ActivateCutsceneMode();
        director.SetGenericBinding(track, interactor.Animator);
        director.Play();
        interactor.SetParent(transform);
        currentInteractor = interactor;
    }

    public void FinishInteraction()
    {
        currentInteractor.SetParent(null);
        currentInteractor.DeActivateCutsceneMode();
        director.ClearGenericBinding(track);
    }
}
