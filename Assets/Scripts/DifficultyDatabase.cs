using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DifficultyDatabase : ScriptableObject
{
    public Difficulty[] difficulty;

    public Difficulty GetDifficulty(int index)
    {
        return difficulty[index];
    }
}
