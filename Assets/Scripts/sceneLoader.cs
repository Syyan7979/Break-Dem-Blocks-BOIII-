using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    GameSession scoreReset;
    private void Start()
    {
        scoreReset = FindObjectOfType<GameSession>();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadPreviusScene()
    {
        SceneManager.LoadScene(1);
        scoreReset.ResetGame();
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        scoreReset.ResetGame();
    }
}
