using System;
using UnityEngine;

public class DistanceObserver : MonoBehaviour
{
    private BikeBody _body;

    private float _startPosition;
    private float _lastDisplayedPosition;

    public event Action<int> OnDistanceChanged;

    public void Init(BikeBody body)
    {
        _body = body;
        _startPosition = _body.transform.position.x;
    }

    private void Update()
    {
        float currentPosition = _body.transform.position.x;
        float deltaPosition = currentPosition - _lastDisplayedPosition;
        if (Mathf.Abs(deltaPosition) > 1f)
        {
            _lastDisplayedPosition = currentPosition;
            OnDistanceChanged?.Invoke((int)_lastDisplayedPosition);
        }
    }
}
