using UnityEngine;

public abstract class AbstractBike : MonoBehaviour
{
    [SerializeField] protected BikeInfo _info;
    [SerializeField] protected BikeBody _body;
    [SerializeField] protected BikeCharacter _character; //TODO: consider extracting character from bike.
    [SerializeField] protected Wheel[] _wheels;

    protected InputData _inputData;

    public Wheel[] Wheels => _wheels;
    public BikeBody Body => _body;
    public BikeCharacter Character => _character;


    public virtual void Init(BikeInfo info)
    {
        _info = info;
    }

    public void SetInput(InputData inputData)
    {
        _inputData = inputData;
    }

    private void FixedUpdate() 
    {
        //Here they are the same, but we can modify them in the parent
        if (_inputData.accelerateDown) HandleAcceleration();
        if (_inputData.brakeDown) HandleBrake();
    }

    protected virtual void HandleAcceleration()
    {
        //All of that could be configurable in the parent
        int wheelsLength = _wheels.Length;
        float torque = -1f * _info.wheelTorque * Time.fixedDeltaTime;

        for (int i = 0; i < wheelsLength; i++)
        {
            _wheels[i].ApplyAcceleration(torque);
        }

        _body.ApplyAcceleration(torque);
    }

    protected virtual void HandleBrake()
    {
        //All of that could be configurable in the parent
        int wheelsLength = _wheels.Length;
        float torque = _info.wheelTorque * Time.fixedDeltaTime;

        for (int i = 0; i < wheelsLength; i++)
        {
            _wheels[i].ApplyAcceleration(torque);
        }

        _body.ApplyAcceleration(torque);
    }

    protected virtual void OnValidate() 
    {
        _wheels = GetComponentsInChildren<Wheel>();
        _body = GetComponentInChildren<BikeBody>();
        _character = GetComponentInChildren<BikeCharacter>();
    }
}
