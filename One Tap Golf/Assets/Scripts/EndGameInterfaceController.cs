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
    [SerializeField] private ParticleSystem confetti;
    private bool playParticles;

    public void ShowScore()
    {
        currentRoundScore.text = "SCORE: " + score.GetScore();
        if (score.GetScore() > PlayerPrefs.GetInt("Score"))
        {
            AudioManager.instance.PlayHighScoreSound();
            confetti.Play();
            playParticles = true;
            PlayerPrefs.SetInt("Score", score.GetScore());
            bestScore.text = "BEST: " + score.GetScore();
        }
        else
        {
            AudioManager.instance.PlayFailSound();
            bestScore.text = "BEST: " + PlayerPrefs.GetInt("Score");
        }
    }

    private void Update()
    {
        if (playParticles)
        {
            confetti.Simulate(Time.unscaledDeltaTime, true, false);
        }
    }
}
