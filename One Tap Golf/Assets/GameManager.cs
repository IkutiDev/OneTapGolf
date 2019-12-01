using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay;
    [SerializeField] private BallFlightCalculation ball;
    [SerializeField] private HoleMovement hole;
    [SerializeField] private CanvasManager canvasManager;
    private bool wonLevel;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score",0);
        }
    }

    public IEnumerator ResetLevel()
    {
        wonLevel = true;
        yield return new WaitForSeconds(levelLoadDelay);
        hole.gameObject.GetComponent<Collider2D>().enabled = true;
        ball.ResetBall();
        hole.MoveHoleToRandomPosition();
        wonLevel = false;
    }

    public void LooseGame()
    {
        if (!wonLevel)
        {
            Time.timeScale = 0f;
           canvasManager.EnableLooseGameCanvas();
        }
    }
    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
