using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMusic : MonoBehaviour
{
    public CharacterDatabase characterDB;

    private int selectedOption = 0;

    public AudioSource audio;

    void Start()
    {
        

        if (!PlayerPrefs.HasKey("selectOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
        Debug.Log("On Music Load " + selectedOption);
    }

    void UpdateCharacter(int selectedOption)
    { 
        Character character = characterDB.GetCharacter(selectedOption);
        audio.clip = character.characterMusic;
        audio.Play();
    }

    private void Load()
    {

        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
