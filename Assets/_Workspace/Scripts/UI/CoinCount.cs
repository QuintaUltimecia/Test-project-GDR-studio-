using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    private Player _player;

    private string _description = "Coins: ";

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void OnDisable()
    {
        _player.Wallet.OnUpdateCoin -= delegate (int value)
        {
            UpdateText(value);
        };
    }

    private void OnEnable()
    {
        if (_player != null)
        {
            _player.Wallet.OnUpdateCoin += delegate (int value)
            {
                UpdateText(value);
            };
        }
    }

    private void UpdateText(int value)
    {
        _text.text = _description + value.ToString();
    }

    public void InitPlayer(Player value)
    {
        _player = value;

        _player.Wallet.OnUpdateCoin += delegate (int value)
        {
            UpdateText(value);
        };
    }
}
