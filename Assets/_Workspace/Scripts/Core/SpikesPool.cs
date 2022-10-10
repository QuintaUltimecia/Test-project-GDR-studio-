using UnityEngine;

public class SpikesPool : MonoBehaviour
{
    [SerializeField]
    private Grid _grid;

    [SerializeField]
    private Spike _spikePrefab;

    [SerializeField]
    private int _count = 5;

    private Transform _transform;
    private Canvas _canvas;
    private Camera _camera;

    private void Awake()
    {
        _transform = transform;
        _canvas = FindObjectOfType<Canvas>();
        _camera = Camera.main;
    }

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            CreateSpike();
        }
    }

    private void CreateSpike()
    {
        Spike newSpike = Instantiate(_spikePrefab, _grid.GetRandomSlot());
        newSpike.Transform.localPosition = Vector3.zero;
    }
}
