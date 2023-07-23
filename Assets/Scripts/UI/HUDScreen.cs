using UnityEngine;

public class HUDScreen : UIRoot
{
    private WheelieObserver _wheelieObserver;
    private DistanceObserver _distanceObserver;

    [SerializeField] private UIText _wheelieText;
    [SerializeField] private UIText _distanceText;

    public void Init(WheelieObserver wheelieObserver, DistanceObserver distanceObserver)
    {
        _wheelieObserver = wheelieObserver;
        _distanceObserver = distanceObserver;
        base.Init();
    }

    public override void Show()
    {
        base.Show();
        _wheelieObserver.OnWheelie += OnWheelie;
        _distanceObserver.OnDistanceChanged += OnDistanceChanged;
    }

    private void OnWheelie() => _wheelieText.Show("Wheelie!", 1000);
    private void OnDistanceChanged(int newDistance) => _distanceText.Show($"{newDistance} m");

    public override void Hide()
    {
        _wheelieObserver.OnWheelie -= OnWheelie;
        _distanceObserver.OnDistanceChanged -= OnDistanceChanged;
        base.Hide();
    }
}
