using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;

    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        score = 0;
        text.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        text.text = score.ToString();
    }

    public void IncrementScore()
    {
        score++;
        text.text = score.ToString();
    }
}
