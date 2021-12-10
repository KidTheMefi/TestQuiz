using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class IconButton : MonoBehaviour, IPointerClickHandler
{
    public event Action<IconButton> ButtonPressed = delegate { };

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRender => _spriteRenderer;
    public string IconId { get; private set; }
   
    [SerializeField]
    private UnityEvent _onCorrectClick;
    [SerializeField]
    private UnityEvent _onWrongClick;
    [SerializeField]
    private UnityEvent _onFirstAppearance;

    private bool _isActive = true;

    public void SetIcon(IconData iconData)
    {
        IconId = iconData.Identifier;
        _spriteRenderer.sprite = iconData.Sprite;
    }

    public void FirstAppearance()
    {
        _onFirstAppearance.Invoke();
    }

    public void CorrectClick()
    {
        _onCorrectClick.Invoke();
    }

    public void WrongClick() 
    {
        _onWrongClick.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isActive)
        {
            ButtonPressed(this);
        }
    }

    public void IsActive(bool active)
    {
        _isActive = active;
    }

}
