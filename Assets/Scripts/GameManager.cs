using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //State Machine Pattern
    private GameState _currentState;
    private GameState _prevState;
    //Singleton Pattern
    public static GameManager instance;

    //Observer Pattern
    public Action<GameState> OnChangeState;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetState(GameState.Edit);
    }

    public void SetState(GameState newState)
    {
        OnChangeState?.Invoke(newState);
        if (newState == GameState.Resume)
        {
            SetState(_prevState);
        }
        else if (newState == GameState.Reset)
        {
            SetState(GameState.Edit);
        }
        else
        {
            _prevState = _currentState;
            _currentState = newState;
        }
    }

}

public enum GameState
{
    Reset,
    Edit,
    Running,
    Victory,
    Lose,
    Pause,
    Resume
}
