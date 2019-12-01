﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlightCalculation : MonoBehaviour
{
    private float parabolaHeight=0.3f;
    private float parabolaWidth = 0.9f;
    [SerializeField] private float parabolaDistanceIncreaseIncrement;

    [SerializeField] private GameObject[] trajectoryDots;

    private float finalPosition;

    private bool started;

    private bool flying;

    private bool fallen;

    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && !flying)
        {
            parabolaHeight += parabolaDistanceIncreaseIncrement/3;
            parabolaWidth += parabolaDistanceIncreaseIncrement;
            ProjectTrajectory();
            if (trajectoryDots[trajectoryDots.Length - 1].transform.position.x >= 12.5f)
            {
                foreach (var dot in trajectoryDots)
                {
                    dot.SetActive(false);
                }
                flying = true;
                finalPosition = trajectoryDots[trajectoryDots.Length - 1].transform.position.x;
                Debug.Log("Went off the game border");
            }
            if (started == false)
            {
                started = true;
                foreach (var dot in trajectoryDots)
                {
                    dot.SetActive(true);
                }
            }
           // Debug.Log(parabolaHeight+" "+parabolaWidth);
        }
        else if (started)
        {
            if (!fallen)
            {
                if (!flying)
                {
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    foreach (var dot in trajectoryDots)
                    {
                        dot.SetActive(false);
                    }

                    flying = true;

                    finalPosition = trajectoryDots[trajectoryDots.Length - 1].transform.position.x;
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
                gameObject.GetComponent<Rigidbody2D>().velocity =
                    gameObject.GetComponent<Rigidbody2D>().velocity * 0.9f;
            }
        }
    }

    private void CalculateFlight()
    {
        var y = CalculateParabola(transform.position.x);
        var x = transform.position.x + (Time.fixedDeltaTime * 10f);
        transform.position = new Vector2(x, y);
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

    public void ResetBall()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Rigidbody2D>().velocity=Vector2.zero;
        transform.rotation=Quaternion.identity;
        transform.position = startPosition;
        flying = false;
        started = false;
        fallen = false;
        gameObject.layer = 0;
        parabolaHeight = 0.3f;
        parabolaWidth = 0.9f;
        parabolaDistanceIncreaseIncrement += 0.01f;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
        if (fallen && GetComponent<Rigidbody2D>().velocity.sqrMagnitude<Mathf.Epsilon)
        {
            FindObjectOfType<GameManager>().LooseGame();
        }
    }

}
