using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualEffectSpriteTween : MonoBehaviour
{
    [SerializeField]
    private float _fadeInDuration;
    [SerializeField]
    private float _fadeOutDuration;
    [SerializeField]
    private SpriteRenderer _objSpriteRenderer;

    private Tween _currentTween;

    public void FadeOut()
    {
        Fade(0, _fadeOutDuration);
    }

    public void FadeOut(SpriteRenderer spriteRenderer)
    {
        Fade(0, _fadeOutDuration);
    }

    public void FadeOut(Image image)
    {
        Fade(0, _fadeOutDuration);
    }
    public void FadeIn()
    {
        Fade(1, _fadeOutDuration);
    }

    private void Fade(float value, float duration)
    {
        _currentTween?.Kill();
        _currentTween = _objSpriteRenderer.DOFade(value, duration);
    }

}
