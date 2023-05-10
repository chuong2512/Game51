using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RObo;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameUI : Singleton<GameUI>
{
    public StateGame currentState = StateGame.Pause;

    public GameObject lose;
    public GameObject win;

    void Start()
    {
        currentState = StateGame.Playing;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowLose()
    {
        currentState = StateGame.Pause;
        lose.SetActive(true);
    }

    public void ShowWin()
    {
        currentState = StateGame.Pause;
        win.SetActive(true);
    }

    public void RestartGame()
    {
        GameDataManager.Instance.ResetLevel();
        SceneManager.LoadScene("Game");
    }

    public void UpLevel()
    {
        GameDataManager.Instance.playerData.NextLevel();
        SceneManager.LoadScene("Game");
    }

    public void PlayAgain()
    {
        if (GameDataManager.Instance.playerData.intDiamond > 0)
        {
            GameDataManager.Instance.playerData.SubDiamond(1);
        }

        SceneManager.LoadScene("Game");
    }

    private Checker[] checkers;

    public void Check()
    {
        if (CheckWin())
        {
            ShowWin();
        }
    }

    public bool CheckWin()
    {
        for (int i = 0; i < checkers.Length; i++)
        {
            if (!checkers[i].CheckTrue())
            {
                return false;
            }
        }

        return true;
    }

    public void Hint()
    {
        if (GameDataManager.Instance.playerData.intDiamond >= 10)
        {
            GameDataManager.Instance.playerData.SubDiamond(10);

            for (int i = 0; i < checkers.Length; i++)
            {
                if (!checkers[i].CheckTrue())
                {
                    checkers[i].Hint();
                    return;
                }
            }
        }
    }
}