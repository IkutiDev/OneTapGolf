using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private PointsCounter pointsCounter;
    public void ShowBestScore()
    {
        if (pointsCounter.GetScore() > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score",pointsCounter.GetScore());
            GetComponent<Text>().text = "BEST: " + pointsCounter.GetScore();
        }
        else
        {
            GetComponent<Text>().text = "BEST: " + PlayerPrefs.GetInt("Score");
        }
    }
}
