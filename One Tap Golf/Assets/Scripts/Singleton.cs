using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton _instance;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
