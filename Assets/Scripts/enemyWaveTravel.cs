using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWaveTravel : MonoBehaviour
{

    // déclaration des variables
    public Transform limitL;
    public Transform limitR;

    public float speed;
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
        // déplacement de la vague d'un bord à l'autre de l'écran
        if (goLeft == true)
        {
            transform.position += Vector3.left * speed;
        }

        if (goRight == true)
        {
            transform.position += Vector3.right * speed;
        }

        // faire descendre la vague à chaque fois qu'elle touche un rebord
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
