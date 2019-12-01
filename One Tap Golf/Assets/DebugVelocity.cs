using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugVelocity : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = FindObjectOfType<BallFlightCalculation>().gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude.ToString();
    }
}
