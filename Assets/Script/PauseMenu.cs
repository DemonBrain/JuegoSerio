using UnityEngine;
using UnityEngine.SceneManagement; 
using System;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Assign this in the inspector

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pauses the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resumes the game
        isPaused = false;
    }

    public void LoadControls()
    {
        // Logic to display controls screen
        // Example: SceneManager.LoadScene("ControlScreen", LoadSceneMode.Additive);
    }

    public void OpenSettings()
    {
        // Logic to display settings
    }

    public void exitGame()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

