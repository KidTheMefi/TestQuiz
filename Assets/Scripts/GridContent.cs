using System;
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
    private DisplayUI _displayUI;

    private string _idToFind;
    private bool _firstAppearance = true; 


    public void SetGridContent(List<IconButton> _spawnedIcons)
    {
        ClearGridContent();
        _iconsOnGrid = _spawnedIcons;

        foreach (IconButton iconButton in _iconsOnGrid)
        {
            iconButton.ButtonPressed += IconButtonPressed;
            if (_firstAppearance)
            {
                iconButton.FirstAppearance();
            }
        }

        _firstAppearance = false;
        SelectIdToFind();
        _displayUI.InitTaskText();
        _displayUI.SetTask(_idToFind);
    }

    private void ClearGridContent()
    {
        foreach (IconButton iconButton in _iconsOnGrid)
        {

            Destroy(iconButton.gameObject);
        }
        _iconsOnGrid.Clear();
    }

    public void ResetGrindContent()
    {
        ClearAlreadyFoundIcons();
        ClearGridContent();
        _firstAppearance = true;
    }

    private void ClearAlreadyFoundIcons()
    {
        _alreadyFoundIconsId.Clear();
    }

    private void SelectIdToFind()
    {
        List<IconButton> availableIcons = new List<IconButton>();

        foreach (IconButton iconButton in _iconsOnGrid)
        {
            availableIcons.Add(iconButton);
        }

        foreach (string foundId in _alreadyFoundIconsId)
        {
            availableIcons.Remove(availableIcons.Find(id => id.IconId == foundId));
        }

        _idToFind = availableIcons[UnityEngine.Random.Range(0, availableIcons.Count)].IconId;
        _alreadyFoundIconsId.Add(_idToFind);
    }

    private void OnDestroy()
    {
        foreach (IconButton iconButton in _iconsOnGrid)
        {
            iconButton.ButtonPressed -= IconButtonPressed;
        }
    }

    public void SetButtonsActivity(bool active)
    {
        foreach (IconButton iconButton in _iconsOnGrid)
        {
            iconButton.IsActive(active);
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
            iconButton.CorrectClick();
            OnCorrectAnswer.Invoke();
        }
        else
        {
            iconButton.WrongClick();
        }
    }
}
