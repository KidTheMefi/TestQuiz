using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsSpawner : MonoBehaviour
{
    [SerializeField]
    private IconFabric _iconFabric;
    [SerializeField]
    private GridContent _gridContent;

    private List<IconData> _iconsToSpawn = new List<IconData>();

    public void InitIconSpawner(IconData[] iconBundleData)
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
        _gridContent.SetGridContent(spawnedIcons);
    }


}
