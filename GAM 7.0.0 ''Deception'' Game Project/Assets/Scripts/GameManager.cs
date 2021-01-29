using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameState GameManagerState = GameState.InMainMenu;

    public enum GameState
    { InMainMenu, InGame, Paused, GunnerVictory, RunnerVictory }; // add other states as needed

    private GameState state;

    public static bool gamePaused = false;

    int buildIndex;

    private void Awake()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        Paused();
        PlayGame();

        switch (state)
        {
            case GameState.InMainMenu:
                break;
            case GameState.InGame:
                Time.timeScale = 1f;
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                break;
        }
    }

    public void Paused()
    {
        if(buildIndex == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gamePaused)
                {
                    state = GameState.InGame;
                    gamePaused = false;
                }
                else
                {
                    state = GameState.Paused;
                    gamePaused = true;
                }
            }
        }
    }
    public void PlayGame()
    {
        if(buildIndex == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("SandboxE");
            }
        }
    }
}