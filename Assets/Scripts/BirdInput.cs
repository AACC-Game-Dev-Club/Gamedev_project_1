using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInput : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]private float jumpForce = 200;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //increase velocity y
            Vector2 vel = rb2d.velocity;
            vel.y = jumpForce;
            rb2d.velocity = vel;
            

        }

    }
}
