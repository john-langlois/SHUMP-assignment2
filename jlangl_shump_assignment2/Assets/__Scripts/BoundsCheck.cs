using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Keeps a GameObject on Screen
///     Only works for orthographic Main Camera
/// </summary>

public class BoundsCheck : MonoBehaviour
{
    [Header("Set in Unity Inspector")]
    public float radius = 1f;
    public bool keepOnScreen = true;


    [Header("set dynamically")]
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;

    public bool offRight, offLeft, offUp, offDown;


    // Start is called before the first frame update
    void Start()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRight = true;
        }
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }

        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            offUp = true;
        }
        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            offDown = true;
        } 


            isOnScreen = !(offRight || offLeft || offUp || offDown);

            if (keepOnScreen && !isOnScreen)
            {
                transform.position = pos;
                isOnScreen = true;
            }
    }
}
