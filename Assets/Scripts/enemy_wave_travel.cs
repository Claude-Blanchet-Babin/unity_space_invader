using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_wave_travel : MonoBehaviour
{

    public Transform limitL;
    public Transform limitR;


    public float speed;
    public float speedDown;
    public float tpDown;

    public bool goLeft = true;
    public bool goRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // déplacement de la vague
        if (goLeft == true)
        {
            transform.position += Vector3.left * speed;
        }

        if (goRight == true)
        {
            transform.position += Vector3.right * speed;
        }

        // faire descendre la vague
        if (transform.position.x < limitL.position.x)
        {
            goLeft = false;
            goRight = true;
            transform.position += Vector3.down * tpDown;
        }
        if (transform.position.x > limitR.position.x)
        {
            goLeft = true;
            goRight = false;
            transform.position += Vector3.down * tpDown;

        }

    }
}
