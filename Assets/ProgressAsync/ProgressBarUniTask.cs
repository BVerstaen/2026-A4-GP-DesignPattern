using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ProgressBarUniTask : MonoBehaviour, IProgressBar, IProgress<float>
{
    [SerializeField] private float _delay;

    [Header("UI")]
    [SerializeField] private Slider _slider;

    private UniTask currentProgressTask;
    private CancellationTokenSource cts;

    public void StartProgressBar()
    {
        if (currentProgressTask.Status == UniTaskStatus.Pending)
            return;

        cts = new CancellationTokenSource();
        currentProgressTask = ProgressAsync(cts.Token);
    }

    public void StopProgressBar()
    {
        cts.Cancel();
    }

    async UniTask ProgressAsync(CancellationToken ct)
    {
        float timeElapsed = 0.0f;
        while (timeElapsed < _delay)
        {
            float progress = timeElapsed / _delay;
            _slider.value = progress;

            bool wasCanceled = await UniTask.NextFrame(ct).SuppressCancellationThrow();
            if (wasCanceled)
            {
                _slider.value = 0.0f;
                return;
            }

            timeElapsed += Time.deltaTime;
        }
        _slider.value = 1.0f;
    }


    public void Report(float value)
    {
        throw new NotImplementedException();
    }
}
