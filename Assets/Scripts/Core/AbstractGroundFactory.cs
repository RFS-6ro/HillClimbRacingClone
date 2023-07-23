using UnityEngine;
using UnityEngine.U2D;

public abstract class AbstractGroundFactory : MonoBehaviour
{
    public static AbstractGroundFactory CreateFactory(AbstractGroundFactory factoryPrefab)
    {
        GameObject factoryInstance = Instantiate(factoryPrefab.gameObject, Vector3.zero, Quaternion.identity);

        AbstractGroundFactory groundFactory = factoryInstance.GetComponent<AbstractGroundFactory>();

        return groundFactory;
    }

    public abstract SpriteShapeController CreateGround(Vector3 position);
}
