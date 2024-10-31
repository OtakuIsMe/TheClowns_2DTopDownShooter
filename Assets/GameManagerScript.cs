using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinnerUI;
    public GameObject gamePauseUI;
    public Animator myAnimator;
    public PlayerController playerController;
    public static bool isGameOver;
    public static bool isGameWinner;
    public static bool isGamePause;
    private void Awake()
    {
        isGameOver = false;
        isGameWinner = false;
        isGamePause = false;
    }
    private void Update()
    {
        if (isGameOver)
        {
            gameOverUI.SetActive(true);
        }
        if (isGameWinner)
        {
            gameWinnerUI.SetActive(true);
        }
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void stop()
    {
        Time.timeScale = 0;
        gamePauseUI.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1;
        gamePauseUI.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
