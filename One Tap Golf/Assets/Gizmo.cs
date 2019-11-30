using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.cyan;
        Gizmos.DrawSphere(transform.position,.1f);
        //Gizmos.DrawIcon(transform.position,"Circle");
    }
}
