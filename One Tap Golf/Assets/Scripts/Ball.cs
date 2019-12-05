using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private BallFlightCalculation ballFlight;
    private Rigidbody2D ballRigidbody2D;
    private Vector2 startPosition;
    [SerializeField] private float minimalVelocity;


    private void Start()
    {
        ballFlight = GetComponent<BallFlightCalculation>();
        ballRigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    public void ResetBall()
    {
        ballRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        ballRigidbody2D.velocity = Vector2.zero;
        var transform1 = transform;
        transform1.rotation = Quaternion.identity;
        transform1.position = startPosition;
        gameObject.layer = 0;
        ballFlight.ResetFlight();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
        if (ballFlight.isFallen() &&GetComponent<Rigidbody2D>().velocity.sqrMagnitude < minimalVelocity)
        {
            FindObjectOfType<GameManager>().LooseGame();
        }
    }

}
