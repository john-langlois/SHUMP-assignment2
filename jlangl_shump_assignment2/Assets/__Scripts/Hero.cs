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

<<<<<<< HEAD
<<<<<<< HEAD
    private GameObject lastTriggerGo = null;

    private float hitCount = 0;

=======
>>>>>>> parent of 2d6854c (Working Game)
=======
>>>>>>> parent of 2d6854c (Working Game)
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
<<<<<<< HEAD
<<<<<<< HEAD
        DeadPlayer();
    
    }


    private void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        if(go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;

        if(go.tag == "Enemy")
        {
            hitCount++;
            Destroy(go);
            
        }
    }

    public void DeadPlayer()
    {
        if (hitCount == 1)
        { 
            Destroy(this.gameObject);
            Main.S.DelayedRestart(gameRestartDelay);
        }
      
=======

>>>>>>> parent of 2d6854c (Working Game)
=======

>>>>>>> parent of 2d6854c (Working Game)
    }
}
