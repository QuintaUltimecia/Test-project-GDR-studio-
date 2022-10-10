using UnityEngine;

public class DIContainer : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private CoinCount _coinCount;

    private void Awake()
    {
        _coinCount.InitPlayer(_player);
    }
}
