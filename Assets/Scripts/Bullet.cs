using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject lootKill;
    public GameObject explosion;


    public PlayerManager myPlayer;

    //public enemy_travel infoEnemy;


    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;

        myPlayer = FindObjectOfType<PlayerManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<enemy_travel>().numberEnemy--;
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Instantiate(lootKill, collision.transform.position, collision.transform.rotation);
        Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        myPlayer.score ++;

    }

}
