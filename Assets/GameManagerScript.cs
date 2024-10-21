using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinnerUI;
    public Animator myAnimator;
    public PlayerController playerController;
    public static bool isGameOver;
    public static bool isGameWinner;
    private void Awake()
    {
        isGameOver = false;
        isGameWinner = false;
    }
    private void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //if (gameOverUI.activeInHierarchy)
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None;
        //}
        //else
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
        if (isGameOver)
        {
            gameOverUI.SetActive(true);
        }
    }

    //public void gameOver()
    //{
    //    gameOverUI.SetActive(true); 

    //    if (playerController != null)
    //    {
    //        Destroy(playerController);
    //        playerController = null;
    //    }
    //    Debug.Log("Game over screen shown.");
    //}

    //public void gameWinner()
    //{
    //    gameWinnerUI.SetActive(true);

    //    if (playerController != null)
    //    {
    //        Destroy(playerController);
    //        playerController = null;
    //    }
    //    Debug.Log("Game winner!!");
    //}

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
