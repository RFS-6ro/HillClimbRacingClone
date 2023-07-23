using Cysharp.Threading.Tasks;
using System.Threading;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UIText : MonoBehaviour 
{
    [SerializeField] private TMP_Text _textContainer;

    private CancellationTokenSource _cts;

    private void Awake() 
    {
        _textContainer.text = "";
    }

    public void Show(string text, int fadeOutDelay = -1)
    {
        _textContainer.text = text;

        if (fadeOutDelay <= 0) return;

        _cts?.Cancel();
        _cts = new CancellationTokenSource();
        ClearTextContainerAsync(fadeOutDelay, _cts.Token).Forget();
    }

    private async UniTaskVoid ClearTextContainerAsync(int fadeOutDelay, CancellationToken token)
    {
        await UniTask.Delay(fadeOutDelay, true, PlayerLoopTiming.Update, token);

        if (token.IsCancellationRequested) return;

        _textContainer.text = "";
    }

    private void OnDestroy() 
    {
        _cts?.Cancel();
    }

    private void OnValidate() 
    {
        _textContainer = GetComponent<TMP_Text>();
    }
}