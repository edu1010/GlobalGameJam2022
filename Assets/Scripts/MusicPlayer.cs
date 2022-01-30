using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject objMusic;
    AudioSource m_audioSurce;
    private float MusicVolume = 0;
    public List<AudioClip> songs;

    void Awake()
    {
        m_audioSurce.Play();

        MusicVolume = PLayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
    }

    // Start is called before the first frame update
    void Start()
    {
        objMusic = GameObject.FindWithTag("music");
        m_audioSurce = objMusic.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }
}
