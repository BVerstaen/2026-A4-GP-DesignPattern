using UnityEngine;
using UnityEngine.InputSystem;

public class ProgressInput : MonoBehaviour
{
    [SerializeField] private InputActionProperty _startInput;
    [SerializeField] private InputActionProperty _stopInput;

    private IProgressBar _progress => GetComponent<IProgressBar>();

    private void OnEnable()
    {
        _startInput.action.Enable();
        _stopInput.action.Enable();
    }

    private void OnDisable()
    {
        _startInput.action.Disable();
        _stopInput.action.Disable();
    }

    private void Update()
    {
        if (_startInput.action.WasPressedThisFrame())
            _progress.StartProgressBar();
        if (_stopInput.action.WasPressedThisFrame())
            _progress.StopProgressBar();
    }
}
