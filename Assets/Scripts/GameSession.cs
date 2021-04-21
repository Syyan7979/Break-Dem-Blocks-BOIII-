using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Configuration Parameters
    [Range(0.1f, 15f)] [SerializeField] float gameSpeed;
    [SerializeField] int pointsPerBlock = 69;
    [SerializeField] bool isAutoplayEnabled;

    // State
    [SerializeField] int currentScore;

    // Update is called once per frame
    private void Awake()
    {
        int currentGameSpeedCount = FindObjectsOfType<GameSession>().Length;
        if (currentGameSpeedCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddScore()
    {
        currentScore += pointsPerBlock;
    }

    public int PassScore()
    {
        return currentScore;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoplayEnabled;
    }
}
