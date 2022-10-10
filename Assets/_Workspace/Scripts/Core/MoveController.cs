using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(SpriteRenderer))]
public class MoveController : MonoBehaviour, IMoveable
{
    [SerializeField]
    private float _moveSpeed = 5f;

    private Transform _transform;
    private LineRenderer _lineRenderer;
    private SpriteRenderer _spriteRenderer;

    private Vector3 _targetPosition;

    private bool _isMove;

    private List<Vector3> _pathPool = new List<Vector3>();

    private void Awake()
    {
        _transform = transform;
        _lineRenderer = GetComponent<LineRenderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        _pathPool.Clear();
        _lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_isMove == true)
        {
            _transform.position = Vector3.MoveTowards(
                _transform.position, 
                _targetPosition, 
                _moveSpeed * Time.deltaTime);

            UpdatePath();
        }
    }

    private void CreatePath()
    {
        if (enabled == false)
            return;

        _lineRenderer.positionCount = _pathPool.Count + 1;
        _lineRenderer.SetPosition(0, _transform.position);

        for (int i = 1; i < _pathPool.Count + 1; i++)
            _lineRenderer.SetPosition(i, _pathPool[i-1]);
    }

    private void UpdatePath()
    {
        _lineRenderer.SetPosition(0, _transform.position);
        _targetPosition = _pathPool[0];

        if (_transform.position == _targetPosition)
        {
            _pathPool.RemoveAt(0);
            CreatePath();
        }

        if (_transform.position == _targetPosition && _pathPool.Count == 0)
            _isMove = false;
    }

    public void SetMovePosition(Vector2 position)
    {
        _pathPool.Add(position);
        _isMove = true;

        CreatePath();
    }

    public int GetSpritePixelSize()
    {
        return _spriteRenderer.sprite.texture.width;
    }
}
