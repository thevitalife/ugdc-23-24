using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolumeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    [SerializeField]
    private AudioMixerGroup audioMixerGroup;

    private void OnEnable()
    {
        volumeSlider.SetValueWithoutNotify(AudioManager.Instance.GetVolume(audioMixerGroup));
        volumeSlider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(float newValue)
    {
        AudioManager.Instance.SetVolume(audioMixerGroup, newValue);
    }

    private void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveListener(OnValueChanged);
    }
}
