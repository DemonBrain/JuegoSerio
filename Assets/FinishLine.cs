using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PjMovimiento player = collision.GetComponent<PjMovimiento>();
            if (player != null && player.HasItem)
            {
                LoadNextLevel();
            }
        }
    }
    void LoadNextLevel()
    {
        Debug.Log("You've completed the level!");
        /*int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("You've completed the last level!");
            // Load main menu or end screen, for example:
            // SceneManager.LoadScene("MainMenu");
        }*/
    }
}
