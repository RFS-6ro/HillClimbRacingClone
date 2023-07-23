using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Wheel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [Space]
    [Header("Grounded check")]
    [SerializeField] private bool _isGrounded;
    [SerializeField] private float _groundCheckDistance = 0.4f;
    [SerializeField] private int _groundLayer = 7;

    private RaycastHit2D[] _resultsCache = new RaycastHit2D[2];

    public float Torque => _rigidbody2D.angularVelocity;

    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
            OnGroundedFlagChanged?.Invoke();
        }
    }

    public event Action OnGroundedFlagChanged;

    public void ApplyAcceleration(float wheelTorque)
    {
        _rigidbody2D.AddTorque(wheelTorque);
    }

    private void FixedUpdate() 
    {
        int hitsCount = Physics2D.RaycastNonAlloc(transform.position, Vector2.down, _resultsCache, _groundCheckDistance, 1 << _groundLayer);
        
        //Invoke only if changed
        if (hitsCount == 0 && IsGrounded) IsGrounded = false;
        else if (hitsCount > 0 && !IsGrounded) IsGrounded = true;
    }

    private void OnValidate() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
