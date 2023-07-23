using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadCollisionObserver : MonoBehaviour
{
    private BikeCharacter _character;
    
    public void Init(BikeCharacter character)
    {
        _character = character;
        _character.OnHeadCollision += OnHeadCollision;
    }

    private void OnHeadCollision()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy() 
    {
        _character.OnHeadCollision += OnHeadCollision;
    }
}
