using UnityEngine;

public class GameConstructor : MonoBehaviour
{
    [SerializeField]
    private MovePanel _movePanel;

    [SerializeField]
    private MoveController _moveController;

    private void Awake()
    {
        _movePanel.InitTargetMoveable(_moveController);
    }
}
