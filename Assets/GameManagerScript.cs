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
    public static bool isGameOver = false;
    public static bool isGameWinner = false;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
       
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);

        if (playerController != null)
        {
            playerController.gameObject.SetActive(false);
        }
        Debug.Log("Game over screen shown.");
    }

    public void gameWinner()
    {
        gameWinnerUI.SetActive(true);

        if (playerController != null)
        {
            playerController.gameObject.SetActive(false);
        }
        Debug.Log("Game winner!!");
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart has been triggered.");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
