using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject _runButton;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _pausePanel;
    // Start is called before the first frame update
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
        _runButton.SetActive(newState == GameState.Edit);

        _losePanel.SetActive(newState == GameState.Lose);
        _pausePanel.SetActive(newState == GameState.Pause);
        if (newState == GameState.Victory)
        {
            if (SceneHandler.instance.SceneExist("Level" + (GameManager.instance.level + 1)))
            {
                _gameOverPanel.SetActive(false);
                _victoryPanel.SetActive(true);
            }
            else
            {
                _gameOverPanel.SetActive(true);
                _victoryPanel.SetActive(false);
            }
        }
        else
        {
            _gameOverPanel.SetActive(false);
            _victoryPanel.SetActive(false);
        }
    }

    public void RunButton()
    {
        GameManager.instance.SetState(GameState.Running);
    }
    public void PauseButton()
    {
        GameManager.instance.SetState(GameState.Pause);
    }
    public void ResumeButton()
    {
        GameManager.instance.SetState(GameState.Resume);
    }
    public void ResetButton()
    {
        GameManager.instance.SetState(GameState.Reset);
    }
    public void NextLevel()
    {
        SceneHandler.instance.UnLoadScene("Level" + GameManager.instance.level);
        GameManager.instance.level++;
        GameManager.instance.SetState(GameState.LoadLevel);
    }
    public void MenuButton()
    {
        SceneHandler.instance.LoadScene("Menu");
    }
}
