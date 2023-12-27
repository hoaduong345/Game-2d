using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public Sound[] soundsSFX, soundsMusic;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in soundsSFX)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
        foreach (Sound s in soundsMusic)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(soundsSFX, item => item.name == sound);
        s.source.Play();
    }
    public void Stop(string sound)
    {
        Sound s = Array.Find(soundsSFX, item => item.name == sound);
        s.source.Stop();
    }

    public void PlayMusic(string sound)
    {
        Sound s = Array.Find(soundsMusic, item => item.name == sound);
        s.source.Play();
    }
    public void StopMusic(string sound)
    {
        Sound s = Array.Find(soundsMusic, item => item.name == sound);
        s.source.Stop();
    }

}