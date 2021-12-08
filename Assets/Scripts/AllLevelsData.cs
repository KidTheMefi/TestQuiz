using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsList")]
public class AllLevelsData : ScriptableObject
{
    [SerializeField]
    private LevelData[] _levelData;

    public LevelData[] LevelData => _levelData;


}
