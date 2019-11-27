using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    public void MoveHoleToRandomPosition()
    {
        var newPosition = Random.Range(0f, 7.7f);
        transform.position=new Vector3(newPosition,transform.position.y);
    }
}
