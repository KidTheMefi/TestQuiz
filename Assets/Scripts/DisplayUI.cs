using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DisplayUI : MonoBehaviour
{

    [SerializeField]
    private UnityEvent _onGameWin;

    [SerializeField]
    private Text _taskTextPrefab;
    [SerializeField]
    private RectTransform _canvas;
    [SerializeField]
    private VisualEffectsTextTween _visualEffectsTextTween;

    private Text _taskText;

    public void InitTaskText() 
    {
        if (_taskText == null)
        {
            _taskText = Instantiate(_taskTextPrefab, _canvas.transform);
            _visualEffectsTextTween.FadeIn(_taskText);
        }
    }

    public void SetTask(string id)
    {
        _taskText.text = String.Format("Find {0}", id);
    }

    public void GameWin()
    {
        _onGameWin.Invoke();
    }

    public void DeleteText()
    {
        Destroy(_taskText.gameObject);
    }
}
