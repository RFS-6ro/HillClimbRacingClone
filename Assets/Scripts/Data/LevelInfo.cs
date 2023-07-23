using UnityEngine;
using UnityEngine.U2D;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "GravityClone/LevelInfo", order = 0)]
public class LevelInfo : ScriptableObject 
{
    public Vector3 spawnPoint;
    public Vector3 groundStartPoint;

    public SpriteShape spriteShapeProfile;

    [Range(1, 100)] public int length = 100;
    [Range(1, 50)] public float xM = 2f;
    [Range(1, 50)] public float yM = 2f;

    [Range(0f, 1f)] public float smoothness = 0.5f;
    [Range(0.1f, 1f)] public float noiseStep = 0.5f;

    [Range(1, 100)] public float depth = 10f;
}
