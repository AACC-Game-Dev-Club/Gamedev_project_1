using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]private float jumpForce = 200;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //increase velocity y
            rb2d.velocity = new Vector3(0, jumpForce);
           
            

        }

    }
}
