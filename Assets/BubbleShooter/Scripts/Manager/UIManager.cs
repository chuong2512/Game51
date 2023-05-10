using UnityEngine;
using System.Collections;
using RObo;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text _score;

    public StateGame currentState = StateGame.Pause;

    public GameObject lose;
    public TextMeshProUGUI textLose;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayGameOver()
    {
        textLose.text = $"Score : {_scoreInt}";
        lose.SetActive(true);
    }

    public void DisplayWin()
    {
    }

    int _scoreInt = 0;

    public void UpdateScore(int score)
    {
        _score.text = score.ToString();

        _scoreInt = score;
    }

    public void DisableText()
    {
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowLose()
    {
        currentState = StateGame.Pause;
    }

    public void ShowWin()
    {
        currentState = StateGame.Pause;
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
}