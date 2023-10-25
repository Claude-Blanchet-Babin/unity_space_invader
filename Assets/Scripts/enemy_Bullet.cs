using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Bullet : MonoBehaviour
{

    public Rigidbody2D monRigidBody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.down * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
