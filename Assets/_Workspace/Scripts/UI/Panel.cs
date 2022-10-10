using UnityEngine;

public class Panel : MonoBehaviour
{
    protected GameObject _gameObject;

    private void Awake()
    {
        _gameObject = gameObject;
    }

    private void Start()
    {
        _gameObject.SetActive(false);
    }
}
