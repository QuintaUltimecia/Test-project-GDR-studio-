using UnityEngine;
using UnityEngine.EventSystems;

public class MovePanel : MonoBehaviour, IPointerClickHandler
{
    private Camera _camera;
    private Canvas _canvas;

    private float _offset;

    private IMoveable _targetMovement;

    private PointerEventData _eventData;

    private void Awake()
    {
        _camera = Camera.main;
        _canvas = FindObjectOfType<Canvas>();
    }

    private void MoveTarget()
    {
        if (_targetMovement == null)
        {
            Debug.LogWarning($"{nameof(_targetMovement)} is null!");
            return;
        }
        else _offset = _targetMovement.GetSpritePixelSize();

        Vector2 position = _eventData.pressPosition;

        if (position.x + _offset > _canvas.renderingDisplaySize.x)
            position = new Vector2(position.x - _offset, position.y);

        if (position.x - _offset < 0)
            position = new Vector2(position.x + _offset, position.y);

        if (position.y + _offset > _canvas.renderingDisplaySize.y)
            position = new Vector2(position.x, position.y - _offset);

        if (position.y - _offset < 0)
            position = new Vector2(position.x, position.y + _offset);

        _targetMovement.SetMovePosition(_camera.ScreenToWorldPoint(position));
    }

    public void InitTargetMoveable(IMoveable target)
    {
        _targetMovement = target;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _eventData = eventData;
        MoveTarget();
    }
}
