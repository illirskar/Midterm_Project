using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Dead,
        Won,
    }

    public GameObject LoserPanel;
    public GameObject WinnerPanel;

    public Controls Controls;
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = GameState.Playing;
    }

    public GameState CurrentState { get; private set; }

    // Update is called once per frame
    void Update()
    {
        if (CurrentState == GameState.Won) WinnerPanel.gameObject.SetActive(true);
        if (CurrentState == GameState.Dead) LoserPanel.gameObject.SetActive(true);

        if (CurrentState == GameState.Playing)
        {
            WinnerPanel.gameObject.SetActive(false);
            LoserPanel.gameObject.SetActive(false);
        }
    }

    public void OnPlayerDeath()
    {
        if (CurrentState != GameState.Playing) return;

        CurrentState = GameState.Dead;
        Controls.enabled = false;
    }

    public void OnPlayerFinish()
    {
        if (CurrentState != GameState.Playing) return;

        Controls.StopMove();
        CurrentState = GameState.Won;
        Controls.enabled = false;
    }

}
