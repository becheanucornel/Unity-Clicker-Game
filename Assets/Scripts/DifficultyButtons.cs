using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    public Button m_EasyButton, m_NormalButton, m_HardButton;

    public DifficultyDatabase difficultyDB;

    private int difficultyOption = 0;
    private int selectedOption = 0;

    void Start()
    {
        UpdateDifficulty(difficultyOption);

        if (!PlayerPrefs.HasKey("difficultyOption"))
        {
            difficultyOption = 0;
        }
        else
        {
            Load();
        }

        m_EasyButton.onClick.AddListener(DifficultyEase);

        m_NormalButton.onClick.AddListener(DifficultyNormal);

        m_HardButton.onClick.AddListener(DifficultyHard);

        selectedOption = PlayerPrefs.GetInt("selectedoption");
        Debug.Log("On Diff Select " + selectedOption);
    }

    private void UpdateDifficulty(int difficultyOption)
    {
        Difficulty difficulty = difficultyDB.GetDifficulty(difficultyOption);
    }

    private void Load()
    {
        difficultyOption = PlayerPrefs.GetInt("difficultyOption");
    }


    private void Save()
    {
        PlayerPrefs.SetInt("difficultyOption", difficultyOption);
    }

    private void DifficultyEase()
    {
        difficultyOption = 0;

        UpdateDifficulty(difficultyOption);
        Save();
    }

    private void DifficultyNormal()
    {
        difficultyOption = 1;

        UpdateDifficulty(difficultyOption);
        Save();
    }

    private void DifficultyHard()
    {
        difficultyOption = 2;

        UpdateDifficulty(difficultyOption);
        Save();
    }
}
