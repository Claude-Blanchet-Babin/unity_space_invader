using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerManager : MonoBehaviour
{
    // déclaration des variables
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;

    public float speed = 0.2f;

    public int score;
    public int money;

    public TextMeshProUGUI moneyUI;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI infoUI;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // définition des déplacements du joueur
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*speed;
        }

        // définition des commandes pour tirer un projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, parent.position, parent.rotation);
        }
        
        // vérification des prérequis pour le projectile spécial
        if (Input.GetKeyDown(KeyCode.LeftShift) && money >= 5)
        {
            // multiplication du nombre de projectile
            Instantiate(bullet, parent.position, parent.rotation);
            Instantiate(bullet, parent.position + new Vector3(0.5f,0,0), parent.rotation);
            Instantiate(bullet, parent.position - new Vector3(0.5f,0,0), parent.rotation);
            // diminution de la quantité d'argent
            money -= 5;
            // mise à jour de la quantité d'argent
            moneyUI.text = "Money : " + money;
        }

        // faire en sorte que le joueur se déplace d'un bord à l'autre de l'écran
        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }

        // mise à jour du score
        scoreUI.text = "Score : " + score;

        // information sur la disponibilité du tir spécial
        if(money>=5)
        {
            infoUI.text = "Special shot available (SHIFT)";
        }

        if (money < 5)
        {
            infoUI.text = " ";
        }
    }

    // vérification d'une collision entre le joueur et un loot
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "money")
        {
            // destruction du loot
            Destroy(col.gameObject);
            // augmentation de la quantité d'argent
            money++;
            // mise à jour de l'affichage d'argent disponible
            moneyUI.text = "Money : " + money;
        }
        
    }
}
