using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadGameScene(); 
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("level 1"); 
    }
}


