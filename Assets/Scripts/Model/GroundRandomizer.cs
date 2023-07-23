using UnityEngine;

public class GroundRandomizer
{
    public void Randomize(LevelInfo levelInfo)
    {
        levelInfo.length = Random.Range(50, 100);
        levelInfo.xM = Random.Range(3f, 10f);
        levelInfo.yM = Random.Range(3f, 10f);
        levelInfo.smoothness = Random.Range(0f, 1f);
        levelInfo.noiseStep = Random.Range(0.1f, 1f);
    }
}
