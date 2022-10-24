using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Line _linePrefab;

    private List<GameObject> _lines = new List<GameObject>();

    private Line _currentLine;

    private bool _canEdit;

    private void OnEnable()
    {
        GameManager.instance.OnChangeState += OnChangeGameState;
    }
    private void OnDisable()
    {
        GameManager.instance.OnChangeState -= OnChangeGameState;
    }

    private void OnChangeGameState(GameState newState)
    {
        _canEdit = newState == GameState.Edit;
        if (newState == GameState.Reset)
        {
            for (int i = 0; i < _lines.Count; i++)
            {
                Destroy(_lines[i]);
            }
            _lines = new List<GameObject>();
        }
    }

    void Update()
    {
        if (!_canEdit)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            _currentLine = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity);
            _lines.Add(_currentLine.gameObject);
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _currentLine.AddPoint(pos);
        }
    }
}
