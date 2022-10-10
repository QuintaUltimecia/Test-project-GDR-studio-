using UnityEngine;

public class FailedPanel : Panel
{
    [SerializeField]
    private Player _player;

    private void OnEnable()
    {
        _player.OnDeath += delegate ()
        {
            ActivePanel();
        };
    }

    private void OnDisable()
    {
        _player.OnDeath -= delegate ()
        {
            ActivePanel();
        };
    }

    private void ActivePanel()
    {
        _gameObject.SetActive(true);
    }
}
