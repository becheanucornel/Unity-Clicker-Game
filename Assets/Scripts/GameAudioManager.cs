using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    private static readonly string GameFirstPlay = "GameFirstPlay";
    private static readonly string GameBackgroundPref = "GameBackgroundPref";
    private int firstPlayInt;
    public Slider volumeSlider;
    private float volumeFloat;
    public AudioSource backgroundAudio;


    void Start()
    { 
        firstPlayInt = PlayerPrefs.GetInt(GameFirstPlay);

        if (firstPlayInt == 0)
        {
            volumeFloat = .25f;
            volumeSlider.value = volumeFloat;
            PlayerPrefs.SetFloat(GameBackgroundPref, volumeFloat);
            PlayerPrefs.SetInt(GameFirstPlay, -1);
        }
        else
        {
            volumeFloat = PlayerPrefs.GetFloat(GameBackgroundPref);
            volumeSlider.value = volumeFloat;
        }
    }

    public void ChangeVolume()
    {
        backgroundAudio.volume = volumeSlider.value;
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(GameBackgroundPref, volumeSlider.value);
    }

    private void OnApplicationFocus(bool infocus)
    {
        if (!infocus)
        {
            SaveSoundSettings();
        }
    }
}
