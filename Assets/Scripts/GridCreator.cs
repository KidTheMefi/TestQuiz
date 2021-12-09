using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    [SerializeField]
    private AllLevelsData _levelsData;

    private List<Vector3> _positionsInGrid = new List<Vector3>();

    [SerializeField]
    private IconsSpawner _iconsSpawner;

    [SerializeField]
    private float _gridInterval;

    private int _currentLevel;

    private void Start()
    {
        _currentLevel = 0;

        StartCoroutine(PreInit());
        //InitialiseGrid(_levelsData.LevelData[_currentLevel]);

    }

    private IEnumerator PreInit() 
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitForEndOfFrame();
        InitialiseGrid(_levelsData.LevelData[_currentLevel]);
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
            EndGame();
        }
    }

    private void InitialiseGrid(LevelData levelData)
    {
        _positionsInGrid.Clear();
        _iconsSpawner.InitGridSpawner(levelData.IconBundle[Random.Range(0, levelData.IconBundle.Length)].IconData);
        UpdateGridPosition(levelData.NumberOfColums, levelData.NumberOfRows);

        for (int x = 0; x < levelData.NumberOfColums; x++)
        {
            for (int y = 0; y < levelData.NumberOfRows; y++)
            {
                _positionsInGrid.Add(new Vector3(x * _gridInterval, y * _gridInterval, 0));
            }
        }

        SpawnIcons();
    }

    private void SpawnIcons()
    {
        _iconsSpawner.SpawnIcons(_positionsInGrid);

    }

    private void UpdateGridPosition(int column, int row)
    {
        float newPositionX = -column / 2 * _gridInterval;
        float newPositionY = -row / 2 * _gridInterval;

        if (column % 2 == 0)
        {
            newPositionX += _gridInterval / 2;
        }
        if (row % 2 == 0)
        {
            newPositionY += _gridInterval / 2;
        }

        gameObject.transform.position = new Vector3(newPositionX, newPositionY);
    }

    private void EndGame()
    {

    }
}
