using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public Text skinName;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    void Start()
    {
        if(!PlayerPrefs.HasKey("selectOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();

        Debug.Log("On Next Option " + selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        skinName.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
        
    }

   
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
        
    }
}
