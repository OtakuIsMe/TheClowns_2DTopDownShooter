using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public Animator myAnimator;
    public PlayerController playerController;
    public static bool isGameOver = false;
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
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true); 

        if (playerController != null)
        {
            Destroy(playerController);
            playerController = null;
        }
        Debug.Log("Game over screen shown.");
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        myAnimator = playerController.GetComponent<Animator>();
        Debug.Log("Restart has used.");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
