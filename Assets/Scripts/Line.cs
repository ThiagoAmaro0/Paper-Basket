using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private EdgeCollider2D _collider;
    private List<Vector2> _points = new List<Vector2>();
    private const float RESOLUTION = 0.1f;

    public void AddPoint(Vector2 pos)
    {
        if (!CheckPos(pos)) return;

        _renderer.SetPosition(_renderer.positionCount++, pos);
        _points.Add(pos);
        _collider.points = _points.ToArray();

    }

    private bool CheckPos(Vector2 pos)
    {
        if (_renderer.positionCount == 0) return true;

        return Vector2.Distance(_points[_points.Count - 1], pos) > RESOLUTION;
    }
}
