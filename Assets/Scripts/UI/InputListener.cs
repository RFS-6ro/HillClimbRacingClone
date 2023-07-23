using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
#if UNITY_EDITOR || DEBUG
    [SerializeField] private KeyCode _inputKey;
#endif

    public event Action OnPointerDown;
    public event Action OnPointerUp;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        OnPointerDown?.Invoke();
    }

#if UNITY_EDITOR || DEBUG
    private void Update() 
    {
        if (Input.GetKeyDown(_inputKey)) OnPointerDown?.Invoke();
        if (Input.GetKeyUp(_inputKey)) OnPointerUp?.Invoke();
    }
#endif

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        OnPointerUp?.Invoke();
    }
}
