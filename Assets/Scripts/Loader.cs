
using UnityEngine.Events;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField]
    private VisualEffectImageTween _loadingPanelPrefab;

    private VisualEffectImageTween _visualEffectImageTween;

    [SerializeField]
    private UnityEvent _onLoadStart;
    [SerializeField]
    private UnityEvent _onLoadEnd;

    public void StartLoading()
    {

        _onLoadStart.AddListener(LoadingDone);
        _visualEffectImageTween = Instantiate(_loadingPanelPrefab, gameObject.transform);
        _visualEffectImageTween.FadeIn(_onLoadStart);
    }

    private void LoadingDone()
    {
        _onLoadEnd.AddListener(DeleteLoadingPanel);
        _visualEffectImageTween.FadeOut(_onLoadEnd);
    }

    private void DeleteLoadingPanel()
    {
        Destroy(_visualEffectImageTween.gameObject);
    }
}
