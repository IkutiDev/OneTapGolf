using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class PointsCounter : MonoBehaviour
{
    [SerializeField, ReadOnly] private int score;

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        gameObject.GetComponent<Text>().text = score.ToString();
    }

    public void IncrementScore()
    {
        score++;
        gameObject.GetComponent<Text>().text = score.ToString();
    }
}
