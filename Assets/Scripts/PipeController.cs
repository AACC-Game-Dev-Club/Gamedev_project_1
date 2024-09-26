using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
        [SerializeField] private float speed = 7.0f;

    private void Update()
    {
        /*
        Move the pipe every frame with a speed modifier. Vector3.left is shorthand for a (-1, 0, 0) vector. 
        This must be Vector3.left since transform.position is Vector3.
        */
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
