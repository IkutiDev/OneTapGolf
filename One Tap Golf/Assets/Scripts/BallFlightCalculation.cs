using System;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && !flying)
        {
            parabolaHeight += parabolaDistanceIncreaseIncrement/3;
            parabolaWidth += parabolaDistanceIncreaseIncrement;
            ProjectTrajectory();
            if (started == false)
            {
                started = true;
                foreach (var dot in trajectoryDots)
                {
                    dot.SetActive(true);
                }
            }
            Debug.Log(parabolaHeight+" "+parabolaWidth);
        }
        else if (started)
        {
            if (!flying)
            {
                
                foreach (var dot in trajectoryDots)
                {
                    dot.SetActive(false);
                }
                flying = true;
                finalPosition = trajectoryDots[trajectoryDots.Length-1].transform.position.x;
            }

            if (transform.position.x < finalPosition)
            {
                CalculateFlight();
            }
            else
            {
                started = false;
            }
        }
    }

    private void CalculateFlight()
    {
        transform.position = new Vector2(transform.position.x+(Time.deltaTime*2f),transform.position.y);
    }

    private void ProjectTrajectory()
    {
        for (int i = 0; i < trajectoryDots.Length; i++)
        {
            var y = CalculateParabola(i);
            trajectoryDots[i].transform.localPosition = new Vector2(parabolaWidth*((i+1)/10f), y);
        }
    }

    private float CalculateParabola(float x)
    {
        var a = parabolaHeight / Mathf.Pow((parabolaWidth / 2), 2);
        var b = parabolaHeight;
        var c = parabolaWidth / 2;
        return -(a * (Mathf.Pow((parabolaWidth * ((x + 1) / 10f) - c), 2))) + b;
    }
}
