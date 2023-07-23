using UnityEngine;

[RequireComponent(typeof(Camera))]
public abstract class UIRoot : MonoBehaviour
{
    [SerializeField] protected Camera _camera;
    [SerializeField] protected Canvas _canvas;

    public virtual void Init()
    {
        Show();
    }

    public virtual void Show()
    {
        _camera.enabled = true;
    }

    public virtual void Hide()
    {
        _camera.enabled = false;
    }

    protected virtual void OnValidate() 
    {
        _camera = GetComponent<Camera>();
        _canvas = GetComponentInChildren<Canvas>();
    }
}
