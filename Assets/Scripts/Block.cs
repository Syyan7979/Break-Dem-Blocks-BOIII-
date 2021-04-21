using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config Param
    [SerializeField] AudioClip destructionSound;
    [SerializeField] GameObject destructionVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] AudioClip hitSound;

    // Cached Reference
    Level level;
    GameSession score;

    // State Variables
    int totalHits;


    private void Start()
    {
        if (tag == "Breakable")
        {
            ObjectsCounter();
        }
        score = FindObjectOfType<GameSession>();
    }

    private void ObjectsCounter()
    {
        level = FindObjectOfType<Level>();
        level.ObjectCount();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            int maxHits = hitSprites.Length + 1;
            totalHits++;
            if (maxHits <= totalHits)
            {
                Destroyed();
            } else
            {
                AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
                ShowNextSprite();
            }
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = totalHits - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void Destroyed()
    {
        AudioSource.PlayClipAtPoint(destructionSound, Camera.main.transform.position);
        level.numDeductOnDesturction();
        score.AddScore();
        TriggerVFX();
        Destroy(gameObject);
    }

    private void TriggerVFX()
    {
        GameObject vfx = Instantiate(destructionVFX, transform.position, transform.rotation);
        Destroy(vfx, 2f);
    }
}
