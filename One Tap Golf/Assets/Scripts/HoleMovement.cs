using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] private float minimumRange=0f;
    [SerializeField] private float maximumRange=7.7f;
    public void MoveHoleToRandomPosition()
    {
        var newPosition = Random.Range(minimumRange, maximumRange);
        transform.position=new Vector3(newPosition,transform.position.y);
    }
}
