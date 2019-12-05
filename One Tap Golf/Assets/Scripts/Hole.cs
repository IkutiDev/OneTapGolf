using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private Score score;
    private GameManager gameManager;
    private void Start()
    {
        score = FindObjectOfType<Score>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GetComponent<Collider2D>().enabled = false;
        score.IncrementScore();
        AudioManager.instance.PlayHitSound();
        StartCoroutine(gameManager.ResetLevel());
    }

}
