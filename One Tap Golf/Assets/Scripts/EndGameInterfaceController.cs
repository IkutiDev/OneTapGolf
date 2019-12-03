using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameInterfaceController : MonoBehaviour
{
    [SerializeField] private Text currentRoundScore;
    [SerializeField] private Text bestScore;
    [SerializeField] private Score score;


    public void ShowScore()
    {
        currentRoundScore.text = "SCORE: " + score.GetScore();
        if (score.GetScore() > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score.GetScore());
            bestScore.text = "BEST: " + score.GetScore();
        }
        else
        {
            bestScore.text = "BEST: " + PlayerPrefs.GetInt("Score");
        }
    }
}
