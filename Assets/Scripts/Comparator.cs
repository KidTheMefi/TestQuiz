using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CompareCheckEvent : UnityEvent<string> { }

public class Comparator : MonoBehaviour
{
    private string _idToFind;

    public CompareCheckEvent WrightClick;
    public CompareCheckEvent WrongClick;

    private void Start()
    {
        SetIdToFind("1");
        Compare("1");
    }

    public void SetIdToFind(string id)
    {
        _idToFind = id;
    }

    public void Compare(string iconData)
    {
        if (_idToFind == iconData)
        {
            WrightClick.Invoke(iconData);
        }
        else
        {
            WrongClick.Invoke(iconData);
        }
    }

    /*public void Compare(IconData iconData)
    {
        if(_idToFind == iconData.Identifier)
        {
            WrightClick.Invoke(iconData);
        }
        else
        {
            WrongClick.Invoke(iconData);
        }
    }*/
}
