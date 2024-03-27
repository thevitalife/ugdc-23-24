using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private AudioMixerGroup[] saveAbleGroups; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
    }

    private void Start()
    {
        foreach (var item in saveAbleGroups)
        {
            InitVolume(item);
        }
    }

    private void InitVolume(AudioMixerGroup audioMixerGroup)
    {
        float volume = PlayerPrefs.GetFloat($"AudioMixer/{audioMixerGroup.name}", 1);
        audioMixer.SetFloat($"{audioMixerGroup.name}/Volume", Mathf.Log10(volume) * 20);
    }

    public void SetVolume(AudioMixerGroup audioMixerGroup, float volume)
    {
        audioMixer.SetFloat($"{audioMixerGroup.name}/Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat($"AudioMixer/{audioMixerGroup.name}", volume);
    }

    public float GetVolume(AudioMixerGroup audioMixerGroup)
    {
        return PlayerPrefs.GetFloat($"AudioMixer/{audioMixerGroup.name}", 1);
    }
}
