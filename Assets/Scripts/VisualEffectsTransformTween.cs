using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEffectsTransformTween : MonoBehaviour
{
    [SerializeField]
    private float _bounceShakeDuration;
    [SerializeField]
    private float _bounceInDuration;
    [SerializeField]
    private float _bounceScaleDuration; 

    private Sequence _currentSequence;

    public void BounceShake(Transform gameObjTransform)
    {
        InitSequence();

        _currentSequence.Append(gameObjTransform.transform.DORotate(new Vector3(0, 0, -25), _bounceShakeDuration, RotateMode.Fast));
        _currentSequence.Append(gameObjTransform.transform.DORotate(new Vector3(0, 0, 25), _bounceShakeDuration, RotateMode.Fast));
        _currentSequence.Append(gameObjTransform.transform.DORotate(new Vector3(0, 0, -15), _bounceShakeDuration, RotateMode.Fast));
        _currentSequence.Append(gameObjTransform.transform.DORotate(new Vector3(0, 0, 0), _bounceShakeDuration, RotateMode.Fast));
    }

    public void BounceScale(Transform gameObjTransform)
    {
        InitSequence();

        _currentSequence.Append(gameObjTransform.DOScale(0.3f, _bounceScaleDuration));
        _currentSequence.Append(gameObjTransform.DOScale(0.6f, _bounceScaleDuration));
        _currentSequence.Append(gameObjTransform.DOScale(0.4f, _bounceScaleDuration));
        _currentSequence.Append(gameObjTransform.DOScale(0.5f, _bounceScaleDuration));
    }

    public void BounceIn(Transform gameObjTransform)
    {
        InitSequence();
        
        _currentSequence.Append(gameObjTransform.DOScale(0, 0));
        _currentSequence.Append(gameObjTransform.DOScale(1.2f, _bounceInDuration));
        _currentSequence.Append(gameObjTransform.DOScale(0.9f, _bounceInDuration));
        _currentSequence.Append(gameObjTransform.DOScale(1f, _bounceInDuration));       
    }

    private void InitSequence()
    {
        _currentSequence?.Kill();
        _currentSequence = DOTween.Sequence();
    }

    private void OnDestroy()
    {
        _currentSequence?.Kill();
    }
}
