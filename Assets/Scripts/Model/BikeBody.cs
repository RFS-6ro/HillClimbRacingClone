using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BikeBody : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public float Velocity => _rigidbody2D.velocity.x;
    public float Rotation => _rigidbody2D.rotation;

    public void ApplyAcceleration(float wheelTorque)
    {
        _rigidbody2D.AddTorque(wheelTorque);
    }

    private void OnValidate() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
