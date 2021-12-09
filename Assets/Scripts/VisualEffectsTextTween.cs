using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualEffectsTextTween : MonoBehaviour
{
    [SerializeField]
    private float _fadeInDuration;
    [SerializeField]
    private float _fadeOutDuration;

    private Tween _currentTween;


    public void FadeOut(Text objText)
    {
        Fade(0, _fadeOutDuration, objText);
    }

    public void FadeIn(Text objText)
    {
        Fade(1, _fadeOutDuration, objText);
    }

    private void Fade(float value, float duration, Text objText)
    {
        _currentTween?.Kill();
        _currentTween = objText.DOFade(value, duration);
    }

}
