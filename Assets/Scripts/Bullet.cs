using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject lootKill;


    public Player myPlayer;


    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;

        myPlayer = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Instantiate(lootKill, collision.transform.position, collision.transform.rotation);
        myPlayer.score ++;
    }

}
