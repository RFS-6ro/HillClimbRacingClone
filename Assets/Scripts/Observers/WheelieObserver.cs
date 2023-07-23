using System;
using UnityEngine;

public class WheelieObserver : MonoBehaviour
{
    private BikeBody _body;
    private Wheel[] _wheels;
    private int _wheelsLength;

    private bool isWheelieRecording;
    private Vector2 _lastRight;
    private Vector2 _currentRight;
    private float _angle;

    public event Action OnWheelie;

    public void Init(Wheel[] wheels, BikeBody body)
    {
        _wheels = wheels;
        _body = body;
        _wheelsLength = _wheels.Length;
        Subscribe();
    }

    private void Subscribe() 
    {
        for (int i = 0; i < _wheelsLength; ++i)
        {
            _wheels[i].OnGroundedFlagChanged += GroundedFlagChanged;
        }
    }

    private void GroundedFlagChanged()
    {
        for (int i = 0; i < _wheelsLength; ++i)
        {
            if (!_wheels[i].IsGrounded) continue;
            
            StopWheelieRecord();
            return;
        }

        StartWheelieRecord();
    }

    private void StartWheelieRecord()
    {
        isWheelieRecording = true;

        _lastRight = transform.right;
    }   

    private void Update()
    {
        if (!isWheelieRecording) return;

        _currentRight = transform.right;

        _angle += Vector2.SignedAngle(_lastRight, _currentRight);

        _lastRight = _currentRight;

        if (Mathf.Abs(_angle) >= 360f)
        {
            _angle -= 360f * Mathf.Sign(_angle);
            OnWheelie?.Invoke();
        }
    }

    private void StopWheelieRecord()
    {
        isWheelieRecording = false;
    }

    private void OnDestroy() 
    {
        for (int i = 0; i < _wheelsLength; ++i)
        {
            _wheels[i].OnGroundedFlagChanged -= GroundedFlagChanged;
        }
    }
}
