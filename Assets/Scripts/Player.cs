using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;

    public float speed = 0.2f;

    public int score;
    public int money;

    public TextMeshProUGUI moneyUI;
    public TextMeshProUGUI scoreUI;

    //public enemy_travel numberEnemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, parent.position, parent.rotation);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && money >= 5)
        {
            Instantiate(bullet, parent.position, parent.rotation);
            Instantiate(bullet, parent.position + new Vector3(1,0,0), parent.rotation);
            Instantiate(bullet, parent.position - new Vector3(1, 0, 0), parent.rotation);
            money -= 5;
            moneyUI.text = "Money : " + money;
        }

        if (transform.position.x < limitL.position.x)
        {
            transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > limitR.position.x)
        {
            transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
        }

        scoreUI.text = "Score : " + score;
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "money")
        {

            Destroy(col.gameObject);
            money++;

            moneyUI.text = "Money : " + money;
        }
        
    }
}
