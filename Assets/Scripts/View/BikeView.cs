using UnityEngine;

[RequireComponent(typeof(AbstractBike))]
public class BikeView : MonoBehaviour
{
    [SerializeField] private WheelView[] _wheelAnimators;

    private Wheel[] _wheels;
    private int _length;

    public void Init(Wheel[] wheels)
    {
        _wheels = wheels;

        Debug.Assert(_wheels.Length == _wheelAnimators.Length, 
            $"{nameof(BikeView)}:: Wheel animators length is not valid"
        );

        _length = _wheels.Length;
        for (int i = 0; i < _length; i++)
        {
            _wheelAnimators[i].Init(_wheels[i]);
        }
    }

    private void OnValidate() 
    {
        _wheelAnimators = GetComponentsInChildren<WheelView>();
    }
}
