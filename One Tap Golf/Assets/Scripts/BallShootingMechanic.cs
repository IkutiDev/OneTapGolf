using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class BallShootingMechanic : MonoBehaviour
{
    [SerializeField] private GameObject trajectoryDot;
    private float powerOfProjectile;
    [SerializeField]private float projectilePowerIncreaseIncrement;
    private bool launching;
    private bool launched;
    private void Start()
    {
        powerOfProjectile = 0f;
        //projectilePowerIncreaseIncrement = 0.1f;
    }

    private void FixedUpdate()
    {
        if (!launched)
        {
            if (Input.GetMouseButton(0))
            {
                launching = true;
                powerOfProjectile += projectilePowerIncreaseIncrement;
                ShowProjectileTrajectory();
            }
            else if (launching)
            {
                
                launching = false;
                ShootProjectile();
            }
        }
    }

    private void ShootProjectile()
    {
        Debug.Log("Kapow!");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1,1)*powerOfProjectile);
        launched = true;
        powerOfProjectile = 0f;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (launched)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void ShowProjectileTrajectory()
    {
        Debug.Log(powerOfProjectile);
    }
}
