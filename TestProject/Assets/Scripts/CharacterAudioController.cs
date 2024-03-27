using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] stepSources;

    [SerializeField]
    private AudioClip[] stepSounds;
    
    public void StepContact(int contactIndex)
    {
        stepSources[contactIndex].PlayOneShot(stepSounds[Random.Range(0, stepSounds.Length)]);
    }
}
