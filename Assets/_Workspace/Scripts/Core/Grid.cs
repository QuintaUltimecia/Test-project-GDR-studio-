using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    private List<Transform> _slots = new List<Transform>();

    private Transform _transform;

    private int _itaration;

    private void Awake()
    {
        _transform = transform;

        for (int i = 0; i < _transform.childCount; i++)
            _slots.Add(_transform.GetChild(i));
    }

    public Transform GetRandomSlot()
    {
        _itaration++;

        if (_itaration == _slots.Count)
        {
            Debug.Log($"Iteration for {GetRandomSlot()} is finish, because max iteration count = {_slots.Count}");

            return default;
        }

        int random = Random.Range(0, _slots.Count);

        if (_slots[random].childCount == 0)
            return _slots[random];
        else return GetRandomSlot();
    }
}
