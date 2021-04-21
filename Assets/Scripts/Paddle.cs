using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Initial Configurations
    [SerializeField] float screenWidthUnits = 32f;
    [SerializeField] float minX = 2f, maxX = 30f;

    // Cached reference
    GameSession theGameSession;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        paddlePos.x = Mathf.Clamp(xPos(), minX, maxX);
        transform.position = paddlePos;
        
    }

    private float xPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        } else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}
