using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallFlightCalculation : MonoBehaviour
{
    private float parabolaHeight=0.3f;
    private float parabolaWidth = 0.9f;
    [SerializeField] private float parabolaDistanceIncreaseIncrement;

    [SerializeField] private GameObject[] trajectoryDots;

    private float finalPosition;

    private bool showDots;

    private bool flying;

    private bool fallen;

    

    private Rigidbody2D ballRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public bool isFallen()
    {
        return fallen;
    }
    public void ResetFlight()
    {
        flying = false;
        showDots = false;
        parabolaHeight = 0.3f;
        parabolaWidth = 0.9f;
        fallen = false;
        parabolaDistanceIncreaseIncrement += 0.01f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKey && !flying)
        {
            parabolaHeight += parabolaDistanceIncreaseIncrement/3;
            parabolaWidth += parabolaDistanceIncreaseIncrement;
            ProjectTrajectory();
            if (trajectoryDots[trajectoryDots.Length - 1].transform.position.x >= 12.5f)
            {
                LaunchBall();
            }
            if (showDots == false)
            {
                showDots = true;
                foreach (var dot in trajectoryDots)
                {
                    dot.SetActive(true);
                }
            }
        }
        else if (showDots)
        {
            if (!fallen)
            {
                if (!flying)
                {
                    LaunchBall();
                }

                if (transform.position.x < finalPosition)
                {
                    CalculateFlight();
                }
                else
                {
                    fallen = true;
                }
            }
            else
            {
                ballRigidbody2D.velocity *= 0.9f;
            }
        }
    }

    private void LaunchBall()
    {
        ballRigidbody2D.constraints = RigidbodyConstraints2D.None;
        foreach (var dot in trajectoryDots)
        {
            dot.SetActive(false);
        }

        flying = true;

        finalPosition = trajectoryDots[trajectoryDots.Length - 1].transform.position.x;
        AudioManager.instance.PlayShootSound();
    }

    private void CalculateFlight()
    {
        var position = transform.position;
        var y = CalculateParabola(position.x);
        var x = position.x + (Time.fixedDeltaTime * 10f);
        position = new Vector2(x, y);
        transform.position = position;
    }

    private void ProjectTrajectory()
    {
        for (int i = 0; i < trajectoryDots.Length; i++)
        {
            var y = CalculateParabola(parabolaWidth * ((i + 1) / 10f));
            trajectoryDots[i].transform.localPosition = new Vector2(parabolaWidth*((i+1)/10f), y);
        }
    }

    private float CalculateParabola(float x)
    {
        var a = parabolaHeight / Mathf.Pow((parabolaWidth / 2), 2);
        var b = parabolaHeight;
        var c = parabolaWidth / 2;
        return -(a * Mathf.Pow((x - c), 2)) + b;
    }

}
