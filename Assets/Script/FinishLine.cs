using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public float delayBeforeLoading = 2.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Parrot parrot = collision.GetComponent<Parrot>();
            Raccoon raccoon = collision.GetComponent<Raccoon>();
            if (parrot != null && parrot.HasItem)
            {
                StartCoroutine(LoadNextLevelAfterDelay());
            }
            else if (raccoon != null && raccoon.HasItem)
            {
                StartCoroutine(LoadNextLevelAfterDelay());
            }
        }
    }
    IEnumerator LoadNextLevelAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
        }
    }
}
