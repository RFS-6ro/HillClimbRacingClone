using NaughtyAttributes;
using UnityEngine;
using UnityEngine.U2D;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _groundShapeController;
    [SerializeField, Expandable] private LevelInfo _levelInfo;

    private Vector3 _lastGeneratedPosition;

    public void Init(SpriteShapeController groundShapeController, LevelInfo levelInfo)
    {
        _groundShapeController = groundShapeController;
        _levelInfo = levelInfo;
    }

    //TODO: consider async Task for heavy terrains.
    [Button]
    public void Generate()
    {
        Spline spline = _groundShapeController.spline;
        spline.Clear();

        for (int step = 0; step < _levelInfo.length; ++step)
        {
            _lastGeneratedPosition = GenerateNextPoint(step);
            spline.InsertPointAt(step, _lastGeneratedPosition);

            //skip edges
            if (step == 0 || step == _levelInfo.length - 1) continue;
            
            ConfigureMidPoint(step, spline);
        }

        SetupEndPoint(spline);
    }

    private Vector3 GenerateNextPoint(int step)
    {
        return _groundShapeController.transform.position + new Vector3
        (
            step * _levelInfo.xM, 
            Mathf.PerlinNoise(0, step * _levelInfo.noiseStep) * _levelInfo.yM
        );
    }

    private void ConfigureMidPoint(int step, Spline spline)
    {
        spline.SetTangentMode(step, ShapeTangentMode.Continuous);
        float smoothness = _levelInfo.xM * _levelInfo.smoothness;

        spline.SetLeftTangent(step, Vector3.left * smoothness);
        spline.SetRightTangent(step, Vector3.right * smoothness);
    }

    private void SetupEndPoint(Spline spline)
    {
        spline.InsertPointAt(_levelInfo.length, new Vector3(_lastGeneratedPosition.x, _groundShapeController.transform.position.y - _levelInfo.depth));
        spline.InsertPointAt(_levelInfo.length + 1, new Vector3(_groundShapeController.transform.position.x, _groundShapeController.transform.position.y - _levelInfo.depth));
    }
    
    public static GroundGenerator CreateGroundGenerator()
    {
        GameObject groundGeneratorInstance = new GameObject("GroundGenerator");

        GroundGenerator groundGenerator = groundGeneratorInstance.AddComponent<GroundGenerator>();

        return groundGenerator;
    }

    #if UNITY_EDITOR
    private void OnValidate()
    {
        if (Application.isPlaying) return;
        
        Generate();
    }
    #endif
}