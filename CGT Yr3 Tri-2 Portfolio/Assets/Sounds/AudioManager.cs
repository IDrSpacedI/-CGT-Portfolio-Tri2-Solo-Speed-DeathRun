using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //creates array and sets 1 instance of it
    public Sound[] sounds;

    public static AudioManager instance;

   
    //sets audio clip varibles 
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //plays main theme at start
    void Start()
    {
        Play("MainTheme"); 
    }


    //gets array of audio clips 
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound;" + name + " Not Found!");
            return;
        }
            
        s.source.Play();
    }
}
