using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // déclaration des variables
    public Rigidbody2D myRigidBody;
    public float speed;
    public GameObject lootKill;
    public GameObject explosion;
    public PlayerManager myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // définir la vitesse de déplacement du projectile
        myRigidBody.velocity = Vector3.up*speed;

        myPlayer = FindObjectOfType<PlayerManager>();
    }

    // Détectetion d'une collision entre la balle et un ennemi
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destruction de l'ennemi
        Destroy(collision.gameObject);
        // destruction de la balle
        Destroy(gameObject);
        // faire apparaitre le loot
        Instantiate(lootKill, collision.transform.position, collision.transform.rotation);
        // faire apparaitre un effet visuel lors de la destruction de l'ennemi
        Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        // augmentation du score du joueur
        myPlayer.score ++;

    }

}
