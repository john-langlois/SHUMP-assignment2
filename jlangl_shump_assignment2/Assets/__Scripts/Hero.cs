using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S;

    [Header("Set in Unity Inspector")]
    //Fields control movement of ship
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Header("These fields are set dynamically")]
    public float shieldLevel = 1;

    private void Awake()
    {
        S = this;
    }
    // Update is called once per frame
    void Update()
    {
        //Pull information based on input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

            //Change transformation position based on the axes
        Vector3 pos = transform.position;

        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
       
        transform.position = pos;

        //rotate ship for dynamic feel

        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

    }
}
