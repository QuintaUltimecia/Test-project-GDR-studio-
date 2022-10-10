using UnityEngine;

public class Wallet
{
    private int _coinCount;

    public delegate void UpdateCoindHandler<T>(T obj);
    public event UpdateCoindHandler<int> OnUpdateCoin;

    public Wallet()
    {
        OnUpdateCoin?.Invoke(_coinCount);
    }

    public void CollectCoin(int value)
    {
        _coinCount += value;
        OnUpdateCoin?.Invoke(_coinCount);

        Debug.Log(_coinCount);
    }
}
