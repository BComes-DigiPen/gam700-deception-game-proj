using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public string Level_Name;

    public GameObject textObj;

    private TextMeshProUGUI textTMP;

    public GameObject pauseUI;

    private void Start()
    {
        if (pauseUI != null)
        {
            pauseUI.SetActive(false);
        }

        if (textObj != null)
        {
            textTMP = textObj.GetComponent<TextMeshProUGUI>();
        }

        if (GameManager.state == GameState.GunnerVictory)
        {
            textTMP.text = "Gunner Won!";
        }

        if (GameManager.state == GameState.RunnerVictory)
        {
            textTMP.text = "Runner Won!";
        }

        if (GameManager.state == GameState.NPCVictory)
        {
            textTMP.text = "An NPC won...";
        }
    }

    public void Paused()
    {
        if (GameManager.gamePaused) //then unpause on click
        {
            GameManager.SetState(GameState.InGame);
            textTMP.text = "Pause";
            pauseUI.SetActive(false);

        }
        else //then pause on click
        {
            GameManager.SetState(GameState.Paused);
            textTMP.text = "Unpause";
            pauseUI.SetActive(true);
        }

    }

    public void MenuPlay()
    {
        SceneManager.LoadScene(Level_Name);
    }

    public void MenuQuit()
    {
        Application.Quit();
    }
    
}
