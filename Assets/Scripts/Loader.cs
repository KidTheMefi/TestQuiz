
using UnityEngine.Events;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField]
    VisualEffectImageTween _visualEffectImageTween;

    [SerializeField]
    private UnityEvent OnLoadStart;
    [SerializeField]
    private UnityEvent OnLoadEnd; 
     
    private void OnEnable() 
    {
        _visualEffectImageTween.FadeIn(OnLoadStart);
    }

    public void LoadingDone()
    {
        _visualEffectImageTween.FadeOut(OnLoadEnd); 
    }

}
