using UnityEngine;

public abstract class AbstractBikeFactory : MonoBehaviour
{
    public static AbstractBikeFactory CreateFactory(AbstractBikeFactory factoryPrefab)
    {
        GameObject factoryInstance = Instantiate(factoryPrefab.gameObject, Vector3.zero, Quaternion.identity);

        AbstractBikeFactory bikeFactory = factoryInstance.GetComponent<AbstractBikeFactory>();

        return bikeFactory;
    }

    public abstract AbstractBike SpawnBike(Vector3 position, BikeInfo info);
}
