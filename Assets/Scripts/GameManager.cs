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
    public int level;

    //Observer Pattern
    public Action<GameState> OnChangeState;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            level = 1;
            instance = this;
        }

    }

    private void Start()
    {
        // sceneHandler.LoadAssync("Level" + level);
        SetState(GameState.Menu);
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
        else if (newState == GameState.LoadLevel)
        {
            SceneHandler.instance.LoadAsync("Level" + GameManager.instance.level, LoadDone);
        }
        else if (newState == GameState.Victory)
        {
            if (PlayerPrefs.GetInt("HighLevel") < level)
                PlayerPrefs.SetInt("HighLevel", level);
        }
        else
        {
            _prevState = _currentState;
            _currentState = newState;
        }
    }

    private void LoadDone(AsyncOperation obj)
    {
        SetState(GameState.Reset);
    }
}

public enum GameState
{
    Menu,
    LevelSelect,
    LoadLevel,
    Reset,
    Edit,
    Running,
    Victory,
    Lose,
    Pause,
    Resume,
}
