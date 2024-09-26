using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInput : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]private float jumpForce = 10.0f;

    void Awake()
    {
        //Searches object for Rigidbody2D and assigns the reference to rb2d.
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //If space is pressed then jump. Velocity is Vector2 so need to use Vector2.up
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb2d.velocity = Vector2.up * jumpForce; 
        }

    }
}
