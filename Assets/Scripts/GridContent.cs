﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridContent : MonoBehaviour
{
    private List<IconButton> _iconsOnGrid = new List<IconButton>();
    private List<string> _alreadyFoundIconsId = new List<string>();

    [SerializeField]
    private UnityEvent OnCorrectAnswer;
    [SerializeField]
    private UnityEvent OnWrongAnswer;

    private string _idToFind;

    public event Action LevelComplete = delegate { };

    public void SetGridContent(List<IconButton> _spawnedIcons)
    {
        CleanGrindContent();
        _iconsOnGrid = _spawnedIcons;

        foreach (IconButton iconButton in _iconsOnGrid)
        {
            iconButton.ButtonPressed += IconButtonPressed;
        }

        SelectIdToFind();
    }



    private void CleanGrindContent()
    {
        foreach (IconButton iconButton in _iconsOnGrid)
        {
            Destroy(iconButton.gameObject);
        }
        _iconsOnGrid.Clear();
    }

    private void SelectIdToFind()
    {
        List<IconButton> availableIcons = _iconsOnGrid;

        foreach (string foundId in _alreadyFoundIconsId)
        {
            availableIcons.Remove(availableIcons.Find(id => id.IconId == foundId));
        }

        _idToFind = availableIcons[UnityEngine.Random.Range(0, availableIcons.Count)].IconId;

        Debug.Log(_idToFind);
    }

    private void OnDestroy()
    {
        foreach (IconButton iconButton in _iconsOnGrid)
        {
            iconButton.ButtonPressed -= IconButtonPressed;
        }
    }


    private bool Compare(string iconID)
    {
        if (iconID == _idToFind)
        {
            return true;
        }
        return false;
    }

    private void IconButtonPressed(IconButton iconButton)
    {
        if (Compare(iconButton.IconId))
        {
            iconButton.WrightClick();
            OnCorrectAnswer.Invoke();
            LevelComplete();
        }
        else
        {           
            iconButton.WrongClick();
            OnWrongAnswer.Invoke();
        }
    }
}
