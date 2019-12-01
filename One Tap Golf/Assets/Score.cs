using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private PointsCounter pointsCounter;
    public void ShowScore()
    {
        GetComponent<Text>().text = "SCORE: " +pointsCounter.GetScore();
    }
}
