using UnityEngine;

public class WinPanel : Panel
{
    [SerializeField]
    private CoinsPool _coinsPool;

    private void OnEnable()
    {
        _coinsPool.OnCollectedAllCoin += delegate ()
        {
            ActivePanel();
        };
    }

    private void OnDisable()
    {
        _coinsPool.OnCollectedAllCoin -= delegate ()
        {
            ActivePanel();
        };
    }

    private void ActivePanel()
    {
        _gameObject.SetActive(true);
    }
}
