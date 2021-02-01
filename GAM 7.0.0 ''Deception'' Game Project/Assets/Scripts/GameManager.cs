using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum GameState
{ InMainMenu, InGame, Paused, GunnerVictory, RunnerVictory, NPCVictory }; // add other states as needed

public class GameManager : MonoBehaviour
{
    //public GameState GameManagerState = GameState.InMainMenu;

    public string Level_Name;

    public static GameState state;

    public static bool gamePaused = false;


    private void Update()
    {
    }

    internal static void SetState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.InMainMenu:
                break;
            case GameState.InGame:
                Time.timeScale = 1f;
                gamePaused = false;
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                gamePaused = true;
                break;
            case GameState.RunnerVictory:
                SceneManager.LoadScene("FinishLevel");
                break;
            case GameState.GunnerVictory:
                SceneManager.LoadScene("FinishLevel");
                break;
            case GameState.NPCVictory:
                SceneManager.LoadScene("FinishLevel");
                break;
        }
    }
}