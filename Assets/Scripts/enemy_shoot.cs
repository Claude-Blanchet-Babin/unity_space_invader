using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shoot : MonoBehaviour
{
    //public Transform limitR;
    public GameObject enemyBullet;
    //private float triggerShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //triggerShot = transform.position.y - limitR.position.y;

        if (transform.position.y <= -0.4)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);

        }

    }
}
