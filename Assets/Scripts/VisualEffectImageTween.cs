using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class VisualEffectImageTween : MonoBehaviour
{
    [SerializeField]
    private float _fadeInDuration;
    [SerializeField]
    private float _fadeOutDuration;

    private Image _objImage;
    private Tween _currentTween;

    private void Awake()
    {
        _objImage = GetComponent<Image>();
    }


    public void FadeOut()
    {
        Fade(0, _fadeOutDuration);
    }

    public void FadeOut(UnityEvent onComplete = null)
    {
        Fade(0, _fadeOutDuration, onComplete);
    }


    public void FadeIn()
    {
        _objImage.DOFade(0, 0);
        Fade(1, _fadeOutDuration);
    }

    public void FadeIn(UnityEvent onComplete = null)
    {
        _objImage.DOFade(0, 0);
        Fade(1, _fadeOutDuration, onComplete);
    }

    private void Fade(float value, float duration, UnityEvent onComplete = null)
    {
        _currentTween?.Kill();
        _currentTween = _objImage.DOFade(value, duration).OnComplete(() => onComplete?.Invoke());
    }

}
