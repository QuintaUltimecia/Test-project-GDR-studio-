using UnityEngine;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour, ICollect, ITakeDamage
{
    private Wallet _wallet = new Wallet();

    private MoveController _moveController;
    private SpriteRenderer _spriteRenderer;

    public delegate void DeathHandler();
    public event DeathHandler OnDeath;

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        OnDeath += delegate ()
        {
            OnDeathEvent();
        };
    }

    private void OnDisable()
    {
        OnDeath -= delegate ()
        {
            OnDeathEvent();
        };
    }

    private void OnDeathEvent()
    {
        _moveController.enabled = false;
        _spriteRenderer.enabled = false;
    }

    public void CollectCoin(int value) =>
        _wallet.CollectCoin(value);

    public void ApplyDamage()
    {
        OnDeath?.Invoke();
    }

    public Wallet Wallet { get => _wallet; }
}
