using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] int numBreakableObj;

    // Cached Reference
    sceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<sceneLoader>();
    }
    public void ObjectCount()
    {
        numBreakableObj++;
    }

    public void numDeductOnDesturction()
    {
        numBreakableObj--;
        if (numBreakableObj == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
