using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputData
{
    public bool accelerateDown;
    public bool brakeDown;
}

public class InputScreen : UIRoot
{
    [SerializeField] private InputListener _leftPart;
    [SerializeField] private InputListener _rightPart;

    private InputData _inputData;

    public void Init(InputData inputData)
    {
        _inputData = inputData;
        base.Init();
    }

    public override void Show()
    {
        base.Show();
        _leftPart.OnPointerDown += OnBreakDown;
        _leftPart.OnPointerUp += OnBreakUp;
        _rightPart.OnPointerDown += OnAccelerateDown;
        _rightPart.OnPointerUp += OnAccelerateUp;
    }

    private void OnAccelerateUp() => _inputData.accelerateDown = false;
    private void OnAccelerateDown() => _inputData.accelerateDown = true;

    private void OnBreakUp() => _inputData.brakeDown = false;
    private void OnBreakDown() => _inputData.brakeDown = true;

    public override void Hide()
    {
        _leftPart.OnPointerDown -= OnBreakDown;
        _leftPart.OnPointerUp -= OnBreakUp;
        _rightPart.OnPointerDown -= OnAccelerateDown;
        _rightPart.OnPointerUp -= OnAccelerateUp;
        base.Hide();
    }
}
