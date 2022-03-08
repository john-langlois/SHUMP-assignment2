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
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;

    [Header("These fields are set dynamically")]
    public float shieldLevel = 1;

    private GameObject lastTriggerGo = null;

    private float hitCount = 3;

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
        DeadPlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TempFire();
        }

    }

    void TempFire()
    {
        GameObject projGo = Instantiate<GameObject>(projectilePrefab);
        projGo.transform.position = transform.position;

        Rigidbody rb = projGo.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * projectileSpeed;
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
            hitCount--;
            Destroy(go);
            
            print("triggered by enemy " + hitCount + " time(s)");
            
        }
        else
        {
            print("Triggered by non-enemy" + go.name);
        }
    }

    public void DeadPlayer()
    {
        if (hitCount < 0)
        {
            print("all lives lost");
            Destroy(this.gameObject);
            Main.S.DelayedRestart(gameRestartDelay);
        }
      
    }
}
