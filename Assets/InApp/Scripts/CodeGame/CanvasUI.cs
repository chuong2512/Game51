using System.Collections;
using System.Collections.Generic;
using RObo;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasUI : Singleton<CanvasUI>
{
    public Button start, exit;
    public GameObject Sub;

    // Start is called before the first frame update
    void Start()
    {
        start?.onClick.AddListener(NewGame);
        exit?.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void NewGame()
    {
        if (GameDataManager.Instance.playerData.time > 0)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            Sub.SetActive(true);
        }
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
    }
}