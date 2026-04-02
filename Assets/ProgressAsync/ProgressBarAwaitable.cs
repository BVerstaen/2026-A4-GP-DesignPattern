using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarAwaitable : MonoBehaviour, IProgressBar
{
    [SerializeField] private float _delay;

    [Header("UI")]
    [SerializeField] private Slider _slider;

    private bool _isRunning;
    private CancellationTokenSource cts;

    public void StartProgressBar()
    {
        cts = new CancellationTokenSource();
        CancellationToken ct = cts.Token;
        _ = ProgressAsync(ct);
    }

    public void StopProgressBar()
    {
        cts.Cancel();
    }

    async Awaitable ProgressAsync(CancellationToken ct)
    {
        if (_isRunning)
            return;

        float timeElapsed = 0.0f;
        _isRunning = true;

        while (timeElapsed < _delay)
        {
            float progress = timeElapsed  / _delay;
            _slider.value = progress;

            timeElapsed += Time.deltaTime;

            try
            {
                await Awaitable.NextFrameAsync(ct);
            }
            catch (OperationCanceledException e)
            {
                _slider.value = 0.0f;
                _isRunning = false;
                return;
            }
        }

        _slider.value = 1.0f;
        _isRunning = false;
    }
}
