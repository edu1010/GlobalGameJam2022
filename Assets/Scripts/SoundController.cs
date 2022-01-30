using System;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource m_audioSurce;
    
    //public List<AudioClip> songs;
    public static SoundController m_soundController = null;
    public AudioClip sounds;

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

       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name)
    {
    }
}
