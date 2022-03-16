using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    private float frequency = 2.0f;
    private float amplitude = 6.0f;
    private float cycleSpeed = 2.0f;


    private Vector3 pos;
    private Vector3 axis;

    private void Start()
    {
        pos = transform.position;

        if (Random.Range(0, 2) == 1)
        {
            axis = transform.right;
        }
        else
        {
            axis = -transform.right;
        }
    }
    public override void Move()
    {
        Vector3 tempPos = pos;
        tempPos += Vector3.down * Time.deltaTime * cycleSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * amplitude;
        pos = tempPos;
    }
}

