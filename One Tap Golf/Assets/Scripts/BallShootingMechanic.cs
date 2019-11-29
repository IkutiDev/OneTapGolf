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

    private void Start()
    {
        powerOfProjectile = 0f;
        //projectilePowerIncreaseIncrement = 0.1f;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            powerOfProjectile += projectilePowerIncreaseIncrement;
            ShowProjectileTrajectory();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        Debug.Log("Kapow!");
        powerOfProjectile = 0f;
    }

    private void ShowProjectileTrajectory()
    {
        Debug.Log(powerOfProjectile);
    }
}
