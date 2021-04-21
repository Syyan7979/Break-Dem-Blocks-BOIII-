using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Conficguration Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelo = 3f, yVelo = 18f;
    [SerializeField] float randomFactor = 0.5f;
    //[SerializeField] AudioClip[] bounceSFX;

    // State
    Vector2 paddleToBall;
    bool hasStarted = false;

    // Cached Component Reference
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBall = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockOnPaddle();
            LaunchOnLeftClick();
        }
    }

    // Launches Ball on Left Mouse Click
    private void LaunchOnLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(xVelo, yVelo);
            hasStarted = true;
        }
        
    }

    // Locks ball on Paddle
    private void LockOnPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 veloTweak = new Vector2
            (UnityEngine.Random.Range(-randomFactor, randomFactor),
            UnityEngine.Random.Range(-randomFactor, randomFactor));
        
        if (hasStarted)
        {
            //AudioClip currentSFX = bounceSFX[UnityEngine.Random.Range(0, bounceSFX.Length)];
            myAudioSource.Play();
            myRigidBody.velocity += veloTweak;
            Debug.Log(myRigidBody.velocity);
        }
    }
}
