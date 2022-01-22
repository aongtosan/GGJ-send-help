using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound sound in sounds){
           sound.source =  gameObject.AddComponent<AudioSource>();
           sound.source.clip = sound.clip;
           sound.source.volume = sound.volume;
           sound.source.pitch = sound.pitch;
           sound.source.loop = sound.loop;
        }
    }

    private void Start() {
        Play("Theme");
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds,sounds => sounds.name == name);
        if(s == null)   return;
        s.source.Play();
        Debug.Log($"play {name}");
    }
}
