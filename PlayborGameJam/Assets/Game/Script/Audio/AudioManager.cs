using System;
using UnityEngine.Audio;
using UnityEngine;

public struct GameSounds
{
    public const string Theme = "Theme";
    public const string LaneStep_0 = "Lane0";
    public const string LaneStep_1 = "Lane1";
    public const string LaneStep_2 = "Lane2";
    public const string LaneSound0 = "Lane0bg";
    public const string LaneSound1 = "Lane1bg";
    public const string LaneSound2 = "Lane2bg";
    public const string Warning = "Warning";
    public const string GameOver = "GameOver";
    public const string Victory = "Victory";
    public const string Hit = "Hit";
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
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

    //private void Start()
    //{
     //   Play(GameSounds.Theme);
    //}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void SetVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = volume;
    }
}
