using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New IconBundleData")]
public class IconBundleData : ScriptableObject
{
    [SerializeField]
    private IconData[] _iconData;

    public IconData[] IconData => _iconData;
}
