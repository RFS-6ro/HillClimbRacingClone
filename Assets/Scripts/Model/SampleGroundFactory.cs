using UnityEngine;
using UnityEngine.U2D;

public class SampleGroundFactory : AbstractGroundFactory
{
    [SerializeField] private SpriteShapeController _groundPrefab;

    public override SpriteShapeController CreateGround(Vector3 position)
    {
        GameObject groundInstance = Instantiate(_groundPrefab.gameObject, position, Quaternion.identity);

        SpriteShapeController bikeLogic = groundInstance.GetComponent<SpriteShapeController>();

        return bikeLogic;
    }
}
