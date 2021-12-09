using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsSpawner : MonoBehaviour
{
    [SerializeField]
    private IconFabric _iconFabric;

    [SerializeField]
    private GridContent _gridContent;

    private bool _firstAppearance;

    private List<IconData> _iconsToSpawn = new List<IconData>();
    //private List<IconButton> _spawnedIcons = new List<IconButton>();

    private void Awake() 
    {
        _firstAppearance = true;
    }

    public void InitGridSpawner(IconData[] iconBundleData)
    {
        _iconsToSpawn.Clear();

        foreach (IconData ID in iconBundleData)
        {
            _iconsToSpawn.Add(ID);
        }
    }

    public void SpawnIcons(List<Vector3> positionOnGrid)
    {
        List<IconButton> spawnedIcons = new List<IconButton>();

        foreach (Vector3 position in positionOnGrid)
        {
            IconData iconToSpawn = _iconsToSpawn[Random.Range(0, _iconsToSpawn.Count)];
            IconButton iconButton = _iconFabric.Create(iconToSpawn);
            iconButton.transform.SetParent(gameObject.transform);
            _iconsToSpawn.Remove(iconToSpawn);
            spawnedIcons.Add(iconButton);
            iconButton.transform.localPosition = position;
        }

        if (_firstAppearance)
        {
            foreach (IconButton iconButton in spawnedIcons)
            {
                iconButton.FirstAppearance();
            }
            _firstAppearance = false;
        }
        _gridContent.SetGridContent(spawnedIcons);
    }


}
