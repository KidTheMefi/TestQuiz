using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenVisualEffects : MonoBehaviour
{
    [SerializeField]
    private float _fadeOutDuration;
    [SerializeField]
    private float _fadeInDuration;
    [SerializeField]
    private float _bounceInDuration;
    [SerializeField]
    private float _bounceShakeDuration;
    [SerializeField]
    private float _bounceScaleDuration;

    [SerializeField]
    private List<Sequence> _Sequances = new List<Sequence>();

    public void CleanTweens()
    {
        foreach (Sequence sequance in _Sequances)
        {
            sequance.Kill();
        }
        _Sequances.Clear();
    }

    public void FadeOut(SpriteRenderer objSpriteRenderer)
    {
        Fade(0, _fadeOutDuration, objSpriteRenderer);
    }
    public void FadeIn(SpriteRenderer objSpriteRenderer)
    {
        Fade(1, _fadeOutDuration, objSpriteRenderer);
    }

    private void Fade(float value, float duration, SpriteRenderer objSpriteRenderer)
    {
        objSpriteRenderer.DOFade(value, duration);
    }

    public void BounceIn(Transform objTransform)
    {
        Sequence bounceInSequence = CreateSequance();
        bounceInSequence.Append(objTransform.DOScale(0, 0));
        bounceInSequence.Append(objTransform.DOScale(1.2f, _bounceInDuration));
        bounceInSequence.Append(objTransform.DOScale(0.9f, _bounceInDuration));
        bounceInSequence.Append(objTransform.DOScale(1f, _bounceInDuration));
  
    }

    public void BounceScale(Transform objTransform)
    {
        Sequence bounceScaleSequence = CreateSequance();
        bounceScaleSequence.Append(objTransform.DOScale(0.3f, _bounceScaleDuration));
        bounceScaleSequence.Append(objTransform.DOScale(0.6f, _bounceScaleDuration));
        bounceScaleSequence.Append(objTransform.DOScale(0.4f, _bounceScaleDuration));
        bounceScaleSequence.Append(objTransform.DOScale(0.5f, _bounceScaleDuration));
    }

    public void BounceShake(Transform objTransform)
    {
        Sequence bounceShakeSequence = CreateSequance();
        bounceShakeSequence.Append(objTransform.DORotate(new Vector3(0, 0, -25), _bounceShakeDuration, RotateMode.Fast));
        bounceShakeSequence.Append(objTransform.DORotate(new Vector3(0, 0, 25), _bounceShakeDuration, RotateMode.Fast));
        bounceShakeSequence.Append(objTransform.DORotate(new Vector3(0, 0, -15), _bounceShakeDuration, RotateMode.Fast));
        bounceShakeSequence.Append(objTransform.DORotate(new Vector3(0, 0, 0), _bounceShakeDuration, RotateMode.Fast));
    }

    public Sequence CreateSequance()
    {
        Sequence bounceSequence = DOTween.Sequence();
        _Sequances.Add(bounceSequence);
        bounceSequence.OnComplete(() => _Sequances.Remove(bounceSequence));
        return bounceSequence;
    }
}
