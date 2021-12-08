using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Level")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private IconBundleData[] _possibleIconBundle;

    [SerializeField]
    private int _numberOfColumns;

    [SerializeField]
    private int _numberOfRows;

    public int NumberOfColums => _numberOfColumns;
    public int NumberOfRows => _numberOfRows;

    public IconBundleData[] IconBundle => _possibleIconBundle;
}
