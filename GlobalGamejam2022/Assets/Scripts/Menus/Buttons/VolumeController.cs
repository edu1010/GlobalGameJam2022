using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void audioMixerMaster(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void audioMixerMusic(float volume)
    {

        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        //audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SFXMixerMusic(float volume)
    {

        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
