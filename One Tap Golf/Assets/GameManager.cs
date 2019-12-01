using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay;
    [SerializeField] private BallFlightCalculation ball;
    [SerializeField] private HoleMovement hole;
    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(levelLoadDelay);
        ball.ResetBall();
        hole.MoveHoleToRandomPosition();
    }
}
