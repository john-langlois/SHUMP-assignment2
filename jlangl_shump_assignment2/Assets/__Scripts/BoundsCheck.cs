using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    private void Update()
    {

        //Restricts movement to a specific boundary
        transform.position = new Vector3
            (
            //x-coordinate
            Mathf.Clamp(transform.position.x, -14f, -14f),
            //y-coordinate
            Mathf.Clamp(transform.position.y, -17f, 17f),
            //z-coordinate
            transform.position.z
            );
        //if enemy leaves the boundary position towards the bottom of the screen
        //the enemy object is destroyed
        if(this.transform.position.y <= -17f && this.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
