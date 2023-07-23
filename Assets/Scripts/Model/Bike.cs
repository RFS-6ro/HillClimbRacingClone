using UnityEngine;

public class Bike : AbstractBike
{   
    protected override void HandleBrake()
    {
        //That's the example of overriding logic.
        //In that example we can't move backwards

        int wheelsLength = _wheels.Length;
        float torque = _info.wheelTorque * Time.fixedDeltaTime;

        for (int i = 0; i < wheelsLength; i++)
        {
            if (_body.Velocity <= 0) continue;

            _wheels[i].ApplyAcceleration(torque);
        }

        _body.ApplyAcceleration(torque);
    }
}
