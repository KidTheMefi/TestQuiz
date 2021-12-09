using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class IconButton : MonoBehaviour, IPointerClickHandler
{
    public event Action<IconButton> ButtonPressed = delegate { };

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    /*[SerializeField]
    private Transform _iconTransform;*/

    public string IconId { get; private set; }
    public SpriteRenderer SpriteRender => _spriteRenderer;
    //public Transform iconTransform => _iconTransform;

    [SerializeField]
    private UnityEvent OnCorrectClick;
    [SerializeField]
    private UnityEvent OnWrongClick;
    [SerializeField]
    private UnityEvent OnFirstAppearance;

    private bool isActive = true;

    public void SetIcon(IconData iconData)
    {
        IconId = iconData.Identifier;
        _spriteRenderer.sprite = iconData.Sprite;
    }

    public void FirstAppearance()
    {
        OnFirstAppearance.Invoke();
    }

    public void CorrectClick()
    {
        OnCorrectClick.Invoke();
    }

    public void WrongClick() 
    {
        OnWrongClick.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isActive)
        {
            ButtonPressed(this);
        }
    }

    public void IsActive(bool active)
    {
        isActive = active;
    }

}
