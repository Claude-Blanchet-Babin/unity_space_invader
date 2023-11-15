using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_travel : MonoBehaviour
{

    public Transform limitL;
    public Transform limitR;
    public Transform spawn;

    public float speed;
    public float tpDown;

    public bool goLeft = true;
    public bool goRight = false;

    public int numberEnemy = 18;

    public float timer;

    public GameObject groupSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {

        // d�finir le d�placement du groupe d'ennemi
        if (goLeft == true)
        {
            transform.position += Vector3.left * speed;
        }

        if (goRight == true)
        {
            transform.position += Vector3.right * speed;
        }

        // faire en sorte que le groupe se d�place vers le bas lorsqu'il touche un bord de l'�cran
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




        // faire apparaitre une nouvelle vague 

        timer += Time.deltaTime;
        if (timer >= 10)
        {
            print("nouvelle vague");
            Instantiate(groupSpawn, spawn.position, spawn.rotation);
            timer = 0;
        }

    }
}
