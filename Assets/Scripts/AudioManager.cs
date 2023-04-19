using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public Slider volumeSlider;
    private float volumeFloat;
    public AudioSource backgroundAudio;
    

    void Start()
    {
        Play("Background Menu Music");

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            volumeFloat = .125f;
            volumeSlider.value = volumeFloat;
            PlayerPrefs.SetFloat(BackgroundPref, volumeFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            volumeFloat = PlayerPrefs.GetFloat(BackgroundPref);
            volumeSlider.value = volumeFloat;
        }
    }

    public void ChangeVolume()
    {
        backgroundAudio.volume = volumeSlider.value;
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, volumeSlider.value);
    }

    public void Play(string name)
    {
        backgroundAudio.Play();
    }

    private void OnApplicationFocus(bool infocus)
    {
        if(!infocus)
        {
            SaveSoundSettings();
        }
    }
}
