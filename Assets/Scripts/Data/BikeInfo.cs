using UnityEngine;

[CreateAssetMenu(fileName = "BikeInfo", menuName = "GravityClone/BikeInfo", order = 0)]
public class BikeInfo : ScriptableObject 
{
    public float wheelTorque = 150f;

    public float bikeRotationSpeed = 300f;
}
