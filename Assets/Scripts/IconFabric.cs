using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconFabric : MonoBehaviour
{
    [SerializeField]
    private IconButton _iconPrefab;

    public IconButton Create(IconData iconData)
    {
        IconButton newIcon = Instantiate(_iconPrefab);
        newIcon.SetIcon(iconData);
        return newIcon;
    }

}
