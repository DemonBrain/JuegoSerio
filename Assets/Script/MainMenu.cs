using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TutorialScreen"); // Show tutorial screen before playing
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        Debug.Log("Settings clicked");
    }
}


