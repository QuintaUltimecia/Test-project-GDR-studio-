using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Spike : MonoBehaviour
{
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _transform.DORotate(new Vector3(0, 0, 180), 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITakeDamage takeDamage))
        {
            takeDamage.ApplyDamage();
        }
    }

    public int GetSpritePixelSize()
    {
        return _spriteRenderer.sprite.texture.width;
    }

    public Transform Transform { get => _transform; }
}
