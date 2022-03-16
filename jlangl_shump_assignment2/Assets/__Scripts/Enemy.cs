using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Set in the Unity Inspector")]
<<<<<<< HEAD
    public float speed = 20f;      // The speed in m/s
=======
    public float speed = 10f;      // The speed in m/s
    public float fireRate = 0.3f;  // Seconds/shot (Unused)
    public float health = 10;
    public int score = 100;      // Points earned for destroying this
>>>>>>> parent of 2d6854c (Working Game)

    private BoundsCheck bndCheck;
    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    // This is a Property: A method that acts like a field
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    
    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;

    }
<<<<<<< HEAD

=======
>>>>>>> parent of 2d6854c (Working Game)
}

