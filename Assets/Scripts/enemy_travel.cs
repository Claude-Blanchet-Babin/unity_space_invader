using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_travel : MonoBehaviour
{

    // déclaration des variables
    public Transform limitL;
    public Transform limitR;
    public Transform spawn;

    public float speed;
    public float tpDown;

    public bool goLeft = true;
    public bool goRight = false;

    public float timer;

    public GameObject groupSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {

        // définir le déplacement du groupe d'ennemi
        if (goLeft == true)
        {
            transform.position += Vector3.left * speed;
        }

        if (goRight == true)
        {
            transform.position += Vector3.right * speed;
        }

        // faire en sorte que le groupe se déplace vers le bas lorsqu'il touche un bord de l'écran
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

        // faire apparaitre une nouvelle vague à intervalle régulier
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            print("new wave");
            Instantiate(groupSpawn, spawn.position, spawn.rotation);
            timer = 0;
        }
    }
}
