﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    [SerializeField] private HoleMovement hole;

    [SerializeField] private Score score;
    // Start is called before the first frame update
    void Start()
    {
        if (hole == null)
        {
            hole = FindObjectOfType<HoleMovement>();
        }
        score.SetScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) // [N]ext level
        {
            hole.MoveHoleToRandomPosition();
        }
        else if (Input.GetKeyDown(KeyCode.M)) // [M]ore score
        {
            score.IncrementScore();
        }
    }
}
