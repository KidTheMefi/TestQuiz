using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconButton : MonoBehaviour, IPointerClickHandler
{
    public event Action<IconButton> ButtonPressed = delegate { };

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Transform _iconTransform;

    public string IconId { get; private set; }
    public SpriteRenderer SpriteRender => _spriteRenderer;
    public Transform iconTransform => _iconTransform;

    public void SetIcon(IconData iconData)
    {
        IconId = iconData.Identifier;
        _spriteRenderer.sprite = iconData.Sprite;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonPressed(this);
    }

}
