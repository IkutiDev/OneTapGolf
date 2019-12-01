using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private PointsCounter pointsCounter;
    private GameManager gameManager;
    private void Start()
    {
        pointsCounter = FindObjectOfType<PointsCounter>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        pointsCounter.IncrementScore();
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(gameManager.ResetLevel());
    }

}
