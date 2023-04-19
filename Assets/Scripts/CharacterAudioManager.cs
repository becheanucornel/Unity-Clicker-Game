using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine;

public class CharacterAudioManager : MonoBehaviour
{
    private static readonly string CharacterFirstPlay = "CharacterFirstPlay";
    private static readonly string CharacterBackgroundPref = "CharacterBackgroundPref";
    private int firstPlayInt;
    public Slider volumeSlider;
    private float volumeFloat;
    public AudioSource backgroundAudio;


    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(CharacterFirstPlay);

        if (firstPlayInt == 0)
        {
            volumeFloat = .125f;
            volumeSlider.value = volumeFloat;
            PlayerPrefs.SetFloat(CharacterBackgroundPref, volumeFloat);
            PlayerPrefs.SetInt(CharacterFirstPlay, -1);
        }
        else
        {
            volumeFloat = PlayerPrefs.GetFloat(CharacterBackgroundPref);
            volumeSlider.value = volumeFloat;
        }
    }

    public void ChangeVolume()
    {
        backgroundAudio.volume = volumeSlider.value;
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(CharacterBackgroundPref, volumeSlider.value);
    }

    private void OnApplicationFocus(bool infocus)
    {
        if (!infocus)
        {
            SaveSoundSettings();
        }
    }
}

