using Cinemachine;
using UnityEngine;
using UnityEngine.U2D;

public class CompositeRoot : MonoBehaviour
{
    [Header("Ground")]
    public AbstractGroundFactory groundFactory;
    public GroundGenerator groundGenerator;
    public LevelInfo levelInfo;
    [Space]
    [Header("Bike")]
    public BikeInfo bikeInfo;
    public AbstractBikeFactory bikeFactory;
    [Space]
    [Header("UI")]
    public HUDScreen hudScreen;
    public InputScreen inputScreen;
    [Space]
    [Header("Camera")]
    public CinemachineVirtualCamera vCam;

    private InputData _inputData;
    private AbstractBike _bikeLogic;
    private WheelieObserver _wheelieObserver;
    private DistanceObserver _distanceObserver;
    private HeadCollisionObserver _headCollisionObserver;


    private void Awake() 
    {
        InitGround();
        InitInput();
        InitBike();
        InitObservers();
        InitUI();
    }

    private void InitGround()
    {
        new GroundRandomizer().Randomize(levelInfo);

        SpriteShapeController groundShapeController = AbstractGroundFactory
            .CreateFactory(groundFactory)
            .CreateGround(levelInfo.groundStartPoint);

        if (groundGenerator == null) 
            groundGenerator = GroundGenerator.CreateGroundGenerator();

        groundGenerator.Init(groundShapeController, levelInfo);
        groundGenerator.Generate();
    }

    private void InitInput()
    {
        _inputData = new InputData();
    }

    private void InitBike()
    {
        _bikeLogic = AbstractBikeFactory
            .CreateFactory(bikeFactory)
            .SpawnBike(levelInfo.spawnPoint, bikeInfo);
        
        _bikeLogic.SetInput(_inputData);

        BikeView bikeView = _bikeLogic.GetComponent<BikeView>();
        bikeView.Init(_bikeLogic.Wheels);

        vCam.Follow = bikeView.transform;
        vCam.LookAt = bikeView.transform;
    }

    private void InitObservers()
    {
        _wheelieObserver = _bikeLogic.gameObject.AddComponent<WheelieObserver>();
        _wheelieObserver.Init(_bikeLogic.Wheels, _bikeLogic.Body);
        _distanceObserver = _bikeLogic.gameObject.AddComponent<DistanceObserver>();
        _distanceObserver.Init(_bikeLogic.Body);
        _headCollisionObserver = _bikeLogic.gameObject.AddComponent<HeadCollisionObserver>();
        _headCollisionObserver.Init(_bikeLogic.Character);
    }

    private void InitUI()
    {
        hudScreen.Init(_wheelieObserver, _distanceObserver);
        inputScreen.Init(_inputData);
    }
}
