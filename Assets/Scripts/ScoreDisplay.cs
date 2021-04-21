using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    // Config Parameters
    [SerializeField] TextMeshProUGUI scoreDisplay;

    // Cache
    GameSession currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = FindObjectOfType<GameSession>();
        scoreDisplay.text = $"SCORE: {currentScore.PassScore()}";
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = $"SCORE: {currentScore.PassScore()}";
    }
}
