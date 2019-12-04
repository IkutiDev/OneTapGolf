using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameInterface;

    [SerializeField] private CanvasGroup endGameInterface;
    // Start is called before the first frame update
    void Start()
    {
        endGameInterface.alpha = 0f;
        endGameInterface.interactable = false;
    }

    public void EnableLooseGameCanvas()
    {
        gameInterface.alpha = 0f;
        gameInterface.interactable = false;
        endGameInterface.alpha=1f;
        endGameInterface.interactable = true;
        endGameInterface.GetComponent<EndGameInterfaceController>().ShowScore();
    }

}
