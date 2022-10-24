using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 _startPos;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }
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
        _rb.simulated = newState == GameState.Running;
        if (newState == GameState.Reset)
        {
            _rb.velocity = Vector2.zero;
            transform.position = _startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Trash"))
        {
            GameManager.instance.SetState(GameState.Victory);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("GameOver"))
        {
            GameManager.instance.SetState(GameState.Lose);
        }
    }
}
