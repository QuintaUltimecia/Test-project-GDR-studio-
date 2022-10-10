using UnityEngine;

public class CoinsPool : MonoBehaviour
{
    [SerializeField]
    private Grid _grid;

    [SerializeField]
    private Coin _coinPrefab;

    [SerializeField]
    private int _count = 5;

    public delegate void CollectedAllCoinHandler();
    public event CollectedAllCoinHandler OnCollectedAllCoin;

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            CreateCoin().OnCollect += delegate ()
            {
                CheckCoinCount();
            };
        }
    }

    private void CheckCoinCount()
    {
        _count--;

        if (_count == 0)
            OnCollectedAllCoin?.Invoke();
    }

    private Coin CreateCoin()
    {
        Coin newCoin = Instantiate(_coinPrefab, _grid.GetRandomSlot());
        newCoin.Transform.localPosition = Vector3.zero;

        return newCoin;
    }
}
