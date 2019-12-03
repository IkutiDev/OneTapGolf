using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffGround : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask=8;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            col.gameObject.layer = LayermaskToLayer(layerMask);
        }
    }
    public static int LayermaskToLayer(LayerMask layerMask)
    {
        int layerNumber = 0;
        int layer = layerMask.value;
        while (layer > 0)
        {
            layer = layer >> 1;
            layerNumber++;
        }
        return layerNumber - 1;
    }
}
