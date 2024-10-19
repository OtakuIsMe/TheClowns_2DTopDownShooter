using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public Sound[] sounds;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Background");
    }

    public void Playthisound(string clipname, float Multiplier)
    {
        AudioSource audiosource = this.gameObject.AddComponent<AudioSource>();
        audiosource.volume *= Multiplier;
        audiosource.PlayOneShot((AudioClip)Resources.Load("Sound/" + clipname, typeof(AudioClip)));
               
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Play();
    }
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        s.source.Stop();
    }

}

//      SoundController.instance.Playthisound("hit", 5f);
//      SoundController.instance.Playthisound("Explosions", 5f);
//      SoundController.instance.Playthisound("shoot", 5f);