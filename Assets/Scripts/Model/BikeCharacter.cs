using System;
using UnityEngine;

public class BikeCharacter : MonoBehaviour
{
    public event Action OnHeadCollision;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Head collision");
        OnHeadCollision?.Invoke();
    }
}