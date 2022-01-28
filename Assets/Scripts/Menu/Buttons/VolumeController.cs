using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void audioMixerMaster(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void audioMixerMusic(float volume)
    {

        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SFXMixerMusic(float volume)
    {

        audioMixer.SetFloat("Sfx", Mathf.Log10(volume) * 20);
    }
}
