using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DisplayUI : MonoBehaviour
{

    [SerializeField]
    private UnityEvent OnGameWin;

    [SerializeField]
    private Text _taskTextPrefab;
    [SerializeField]
    private RectTransform _canvas;
    [SerializeField]
    private VisualEffectsTextTween visualEffectsTextTween;

    private Text _taskText;

    public void InitTaskText() 
    {
        if (_taskText == null)
        {
            _taskText = Instantiate(_taskTextPrefab, _canvas.transform);
            visualEffectsTextTween.FadeIn(_taskText);
        }
    }

    public void SetTask(string id)
    {
        _taskText.text = String.Format("Find {0}", id);
    }

    public void GameWin()
    {
        OnGameWin.Invoke();
    }

    public void DeleteText()
    {
        Destroy(_taskText.gameObject);
    }
}
