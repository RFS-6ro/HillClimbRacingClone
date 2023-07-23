using UnityEngine;

public class SampleBikeFactory : AbstractBikeFactory
{
    [SerializeField] private GameObject _bikePrefab;
    [SerializeField] private float _circleCastRadius = 1f;
    [SerializeField] private float _circleCastStep = 1f;
    [SerializeField] private int _groundLayer = 7;

    private RaycastHit2D[] _results = new RaycastHit2D[2];

    public override AbstractBike SpawnBike(Vector3 position, BikeInfo info)
    {
        GameObject bikeInstance = Instantiate(_bikePrefab, ValidatePosition(position), Quaternion.identity);

        AbstractBike bikeLogic = bikeInstance.GetComponent<AbstractBike>();
        bikeLogic.Init(info);

        return bikeLogic;
    }

    private Vector3 ValidatePosition(Vector3 position)
    {
        while (Physics2D.CircleCastNonAlloc(position, _circleCastRadius, Vector2.down, _results, _circleCastRadius, 1 << _groundLayer) > 0)
        {
            position += new Vector3(0f, _circleCastStep, 0f);
        }

        return position;
    }
}
