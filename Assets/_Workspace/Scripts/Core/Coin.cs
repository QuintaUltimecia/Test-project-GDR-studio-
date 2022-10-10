using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Coin : MonoBehaviour
{
    [SerializeField]
    private int _count = 1;

    private GameObject _gameObject;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    public delegate void CollectHandler();
    public event CollectHandler OnCollect;

    private void Awake()
    {
        _gameObject = gameObject;
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        if (collision.TryGetComponent(out ICollect collect))
        {
            collect.CollectCoin(_count);
            _gameObject.SetActive(false);

            OnCollect?.Invoke();
        }
    }

    public int GetSpritePixelSize()
    {
        return _spriteRenderer.sprite.texture.width;
    }

    public Transform Transform { get => _transform; }
}
