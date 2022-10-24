using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject _runButton;
    [SerializeField] private GameObject _stopButton;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private GameObject _losePanel;
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
        _stopButton.SetActive(newState == GameState.Running);

        _victoryPanel.SetActive(newState == GameState.Victory);
        _losePanel.SetActive(newState == GameState.Lose);
        _pausePanel.SetActive(newState == GameState.Pause);
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
}
