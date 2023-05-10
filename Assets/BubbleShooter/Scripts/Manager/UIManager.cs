

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text _centerText;
    public Text _score;
    
    public StateGame currentState = StateGame.Pause;

    public GameObject lose;
    public GameObject win;


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
        _centerText.gameObject.SetActive(true);
        _centerText.text = "Game Over";
    }

    public void DisplayWin()
    {
        _centerText.gameObject.SetActive(true);
        _centerText.text = "Win";
    }

    public void UpdateScore(int score)
    {
        _score.text = score.ToString();
    }

    public void DisableText()
    {
        _centerText.gameObject.SetActive(false);
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

}