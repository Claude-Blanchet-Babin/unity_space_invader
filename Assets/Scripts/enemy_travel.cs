using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Transform limitL;
    public Transform limitR;

    public float speed;
    public float speedDown;
    public float tpDown;

    public bool goLeft = true;
    public bool goRight = false;

    public int numberEnemy = 18;

    public GameObject groupSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        if (goLeft == true)
        {
            transform.position += Vector3.left * speed;
        }

        if (goRight == true)
        {
            transform.position += Vector3.right * speed;
        }

        if (transform.position.x < limitL.position.x)
        {
            goLeft = false;
            goRight = true;
            transform.position += Vector3.down*tpDown;
        }
        if (transform.position.x > limitR.position.x)
        {
            goLeft = true;
            goRight = false;
            transform.position += Vector3.down * tpDown;

        }

        //transform.position += Vector3.down * speedDown;

        if (numberEnemy == 9 && groupSpawn == false)
        {
            Instantiate(groupSpawn, transform.position, transform.rotation);
        }

    }
}
