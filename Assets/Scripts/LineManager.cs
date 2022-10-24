using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _linePrefab;

    private Line _currentLine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentLine = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity).GetComponent<Line>();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _currentLine.AddPoint(pos);
        }
    }
}
