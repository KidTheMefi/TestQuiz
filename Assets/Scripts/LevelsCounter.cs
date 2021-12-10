using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelsCounter : MonoBehaviour
{
    [SerializeField]
    private GridCreator _gridCreator;
    [SerializeField]
    private AllLevelsData _levelsData;
    [SerializeField, Range(0f, 5f)]
    private float _levelStartDelay;
    [SerializeField]
    private UnityEvent _onGameWin;

    private int _currentLevel = 0;

    private void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        StartCoroutine(StartLevelWithDelay());
    }

    private IEnumerator StartLevelWithDelay(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        yield return new WaitForEndOfFrame();
        _gridCreator.InitialiseGrid(_levelsData.LevelData[_currentLevel]);
    }

    public void NextLevel()
    {
        _currentLevel++;
        if (_currentLevel < _levelsData.LevelData.Length)
        {
            StartCoroutine(StartLevelWithDelay(_levelStartDelay));
        }
        else
        {
            _currentLevel = 0;
            _onGameWin.Invoke();
        }
    }

}
