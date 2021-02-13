using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{

    public AudioMixerGroup audioMixerGroup;

    private AudioSource source;
    public string clipName;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(0f, 3f)]
    public float pitch;

    public bool loop = false;


    public bool playOnAwake = false;

    public void setSource(AudioSource _souce)
    {
        source = _souce;
        source.clip = clip;
        source.pitch = pitch;
        source.volume = volume;
        source.loop = loop;
        source.playOnAwake = playOnAwake;
        source.outputAudioMixerGroup = audioMixerGroup;
    }



    public void Play()
    {
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }

     void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].clipName);
            _go.transform.SetParent(this.transform);
            sounds[i].setSource(_go.AddComponent<AudioSource>());
        }


        PlaySound("action_theme");
    }


    public void PlaySound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].clipName == _name)
            {
                sounds[i].Play();
                return;
            } 
        }
    }
}
