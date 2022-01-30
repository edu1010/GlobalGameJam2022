using System;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource m_audioSurce;
    
    public List<AudioClip> songs;
    public static SoundController m_soundController = null;
    public Sounds[] sounds;

    void Awake()
    {
        if (m_soundController == null)
        {
            m_soundController = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(this);
        }

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Sounds s in sounds)
        {
            s.source.volume = s.volume;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
