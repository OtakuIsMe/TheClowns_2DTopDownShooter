using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    private void Awake()
    {
        instance = this;
    }

    public void Playthisound(string clipname, float Multiplier)
    {
        AudioSource audiosource = this.gameObject.AddComponent<AudioSource>();
        audiosource.volume *= Multiplier;
        audiosource.PlayOneShot((AudioClip)Resources.Load("Sound/" + clipname, typeof(AudioClip)));
               
    }

    
}

//      SoundController.instance.Playthisound("hit", 5f);
//      SoundController.instance.Playthisound("Explosions", 5f);
//      SoundController.instance.Playthisound("shoot", 5f);