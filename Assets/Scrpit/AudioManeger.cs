using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManeger : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManeger instance; 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
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
            s.source.loop = s.Loop;
        }
    }
    public void Start()
    {
        Play("Main");
    }
    public void Play(string name)
    {
        Sound s =Array.Find(sounds, sound  => sound.name == name);
        s.source.Play();
        if (s == null) 
        {
            Debug.LogWarning("sound: "+ name + " Not Found");
            return;
        }  
    }
}//class