using NaughtyAttributes;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WheelView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField, AnimatorParam(nameof(_animator), AnimatorControllerParameterType.Float)] private string _animatorSpeedKey = "Speed";

    private int _animatorSpeedKeyHash;
    private Wheel _wheel;

    public void Init(Wheel wheel)
    {
        _wheel = wheel;
        _animatorSpeedKeyHash = Animator.StringToHash(_animatorSpeedKey);
    }

    public void Update()
    {
        transform.position = _wheel.transform.position;
        _animator.SetFloat(_animatorSpeedKey, _wheel.Torque);
    }

    private void OnValidate() 
    {
        _animator = GetComponent<Animator>();
    }
}
