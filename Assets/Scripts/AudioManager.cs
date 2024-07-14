using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds, loopSounds;
    public AudioSource musicSource, sfxSource, loopSource;

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
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
        //Theme will play once the game starts. if not needed, delete Start().

    }



    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x=> x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x=> x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlayLoop(string name)
    {
        Sound s = Array.Find(loopSounds, x=> x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            loopSource.clip = s.clip;
            loopSource.Play();
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

     public void FXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
     public void LoopVolume(float volume)
    {
        loopSource.volume = volume;
    }
}
