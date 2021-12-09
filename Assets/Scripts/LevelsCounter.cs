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

    [SerializeField]
    private float _levelStartDelay;

    [SerializeField]
    private UnityEvent OnGameWin; 

    private int _currentLevel = 0;

    void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        StartCoroutine(PreInit());
    }

    private IEnumerator PreInit()
    {
        yield return new WaitForSeconds(_levelStartDelay);
        yield return new WaitForEndOfFrame();
        _gridCreator.InitialiseGrid(_levelsData.LevelData[_currentLevel]);
    }

    public void NextLevel()
    {
        _currentLevel++;
        if (_currentLevel < _levelsData.LevelData.Length)
        {
            StartCoroutine(PreInit());
        }
        else
        {
            _currentLevel = 0;
            OnGameWin.Invoke();
        }
    }

}
