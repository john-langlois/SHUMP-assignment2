using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Set in the Unity Inspector")]
    public float speed = 10f;      // The speed in m/s
    public float fireRate = 0.3f;  // Seconds/shot (Unused)
    public float health = 10;
    public int score = 100;      // Points earned for destroying this

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
   
    // Update is called once per frame
    void Update()
    {
        Move();
        if (bndCheck != null && bndCheck.offDown) {
            //Check to make sure it went off the bottom of the screen
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;

    }
}
