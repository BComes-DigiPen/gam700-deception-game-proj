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

    void Paused()
    {
        if(Input.GetMouseButton(0))
        {
            if(gamePaused)
            {
                state = GameState.InGame;
            }
            else
            {
                state = GameState.Paused;
            }
        }
    }
    void PlayGame()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("SampleScene");
            state = GameState.InGame;
        }
    }
}